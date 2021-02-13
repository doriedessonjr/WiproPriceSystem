using System;
using System.Collections.Generic;
using System.Web.Http;
using WiproPriceSystem.Api.Dto;
using WiproPriceSystem.Application.Dispatcher;
using WiproPriceSystem.Domain.CommandData.Command;
using WiproPriceSystem.Domain.CommandData.Resultado;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Ioc;

namespace WiproPriceSystem.Api.Controllers
{
    [RoutePrefix("api/v1/fila")]
    public class FilaController : ApiController
    {
        //private BuscaDeAplicativoApplication _application;
        private CommandMessageDispatcher _commandDispatcher;
        private QueryMessageDispatcher _queryMessageDispatcher;

        public FilaController()
        {
            _commandDispatcher = new CommandMessageDispatcher(ContainerConfig.CreateBuilder());
            _queryMessageDispatcher = new QueryMessageDispatcher(ContainerConfig.CreateBuilder());
            //_application = new BuscaDeAplicativoApplication(_queryMessageDispatcher, applicationLogger);
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
    }
}