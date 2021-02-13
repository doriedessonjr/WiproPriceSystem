using System;
using Autofac;
using WiproPriceSystem.Domain.QueryData.Base;

namespace WiproPriceSystem.Application.Dispatcher
{
    public class QueryMessageDispatcher
    {
        private IContainer _container;

        public QueryMessageDispatcher(ContainerBuilder builder)
        {

            _container = builder.Build();
        }

        /// <summary>
        /// Trata a query recebida
        /// </summary>
        /// <typeparam name="TResult">Resultado do processamento</typeparam>
        /// <param name="query">Query Recebida</param>
        /// <returns>Resultado da Pesquisa</returns>
        public TResult Handle<TResult>(IQuery query)
        {
            Type _queryHandlerGenericType = typeof(IQueryHandler<,>);
            Type[] _queryHandlerTypeArgs = new[] { query.GetType(), typeof(TResult) };
            Type _queryHandlerType = _queryHandlerGenericType.MakeGenericType(_queryHandlerTypeArgs);

            dynamic _queryHandler = _container.Resolve(_queryHandlerType);
            TResult _result = _queryHandler.Handle((dynamic)query);
            return _result;
        }
    }
}