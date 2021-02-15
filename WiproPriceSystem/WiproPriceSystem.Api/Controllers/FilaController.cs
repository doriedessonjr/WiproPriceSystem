using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WiproPriceSystem.Api.Dto;
using WiproPriceSystem.Application.Application;
using WiproPriceSystem.Application.Dispatcher;
using WiproPriceSystem.Domain.CommandData.Command;
using WiproPriceSystem.Domain.CommandData.Resultado;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Domain.QueryData.Queries;
using WiproPriceSystem.Ioc;

namespace WiproPriceSystem.Api.Controllers
{
    [RoutePrefix("api/v1/fila")]
    public class FilaController : ApiController
    {
        private BuscaDeFilaApplication _application;
        private CommandMessageDispatcher _commandDispatcher;
        private QueryMessageDispatcher _queryMessageDispatcher;

        public FilaController()
        {
            _commandDispatcher = new CommandMessageDispatcher(ContainerConfig.CreateBuilder());
            _queryMessageDispatcher = new QueryMessageDispatcher(ContainerConfig.CreateBuilder());
            _application = new BuscaDeFilaApplication(_queryMessageDispatcher);
        }

        /// <summary>
        /// Insere itens na fila
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddItemFila([FromBody] List<FilaDto> dto)
        {
            try
            {
                ListaFilaCommand _command = new ListaFilaCommand();
                 

                foreach (var item in dto)
                {
                    Fila _fila = new Fila();
                    _fila.Moeda = item.moeda;
                    _fila.DataInicio = DateTime.Parse(item.data_inicio);
                    _fila.DataFim = DateTime.Parse(item.data_fim);

                    _command.Root.Add(_fila);
                }

                ResultadoCommand _resultado = _commandDispatcher.Dispatch(_command) as ResultadoCommand;

                return Ok(_resultado);
            }
            catch
            {
                return InternalServerError(new Exception($"Ocorreu um erro durante o processamento"));
            }
        }

        /// <summary>
        /// Retorna o último item da fila
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("lastid/")]
        public IHttpActionResult GetItemFila()
        {

            FilaLastIdQuery _query = new FilaLastIdQuery();
            var _resultado = _application.ExecutarQuery(_query);
            if (_resultado.ExecutouComSucesso)

            {
                if (_resultado.Resultado != null && _resultado.Resultado.Count() > 0)
                {
                    return Ok(_resultado);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return InternalServerError(new Exception($"Ocorreu um erro durante o processamento {_resultado.Mensagem}"));
            }
        }
    }
}