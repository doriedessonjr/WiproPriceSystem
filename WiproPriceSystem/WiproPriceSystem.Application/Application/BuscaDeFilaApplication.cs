using System;
using WiproPriceSystem.Application.Dispatcher;
using WiproPriceSystem.Domain.QueryData.Base;
using WiproPriceSystem.Domain.QueryData.Queries;

namespace WiproPriceSystem.Application.Application
{
    public class BuscaDeFilaApplication
    {
        private QueryMessageDispatcher _queryMessageDispatcher;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="queryMessageDispatcher"></param>
        public BuscaDeFilaApplication(QueryMessageDispatcher queryMessageDispatcher)
        {
            _queryMessageDispatcher = queryMessageDispatcher;
        }


        /// <summary>
        /// Executa a query passada
        /// </summary>
        /// <param name="query"></param>
        public ResultadoQuery<FilaQuery> ExecutarQuery(IQuery query)
        {
            ResultadoQuery<FilaQuery> _resultado = new ResultadoQuery<FilaQuery>();
            try
            {
                _resultado.ExecutouComSucesso = true;
                _resultado = _queryMessageDispatcher.Handle<ResultadoQuery<FilaQuery>>(query);
            }
            catch (Exception exp)
            {
                _resultado.ExecutouComSucesso = false;
                _resultado.Mensagem = "Ocorreu o seguinte erro ao buscar pelo último item da fila: "+exp.ToString();
            }

            return _resultado;
        }
    }
}