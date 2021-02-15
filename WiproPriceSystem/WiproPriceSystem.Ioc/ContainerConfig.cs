using Autofac;
using WiproPriceSystem.Application.Application;
using WiproPriceSystem.Application.Dispatcher;
using WiproPriceSystem.Domain.CommandData.Base;
using WiproPriceSystem.Domain.CommandData.Command;
using WiproPriceSystem.Domain.CommandData.CommandHandler;
using WiproPriceSystem.Domain.CommandData.Resultado;
using WiproPriceSystem.Domain.QueryData.Base;
using WiproPriceSystem.Domain.QueryData.Queries;
using WiproPriceSystem.Domain.QueryData.QueryHandlers;
using WiproPriceSystem.Domain.Repositories;
using WiproPriceSystem.Infra.EF.Context;
using WiproPriceSystem.Infra.Repositories;

namespace WiproPriceSystem.Ioc
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder _containerBuider = CreateBuilder();
            return _containerBuider.Build();
        }

        public static ContainerBuilder CreateBuilder()
        {
            ContainerBuilder _containerBuilder = new ContainerBuilder();

            //Application
            _containerBuilder.RegisterType<BuscaDeFilaApplication>().AsSelf();

            //Geral
            _containerBuilder.RegisterType<CommandMessageDispatcher>().AsSelf();
            _containerBuilder.RegisterType<QueryMessageDispatcher>().AsSelf();
            _containerBuilder.RegisterType<LocalContext>().AsSelf();

            //Repositories
            _containerBuilder.RegisterType<FilaInsertRepository>().As<IInsertFilaRepository>();
            _containerBuilder.RegisterType<FilaDeleteRepository>().As<IDeleteFilaRepository>();
            _containerBuilder.RegisterType<FilaLastIdRepository>().As<IFilaLastIdRepository>();

            //Handlers
            _containerBuilder.RegisterType<CadastrarFilaCommandHandler>().As<ICommandHandler<ListaFilaCommand, ResultadoCommand>>();
            _containerBuilder.RegisterType<DeletarFilaCommandHandler>().As<ICommandHandler<FilaCommand, ResultadoCommand>>();
            _containerBuilder.RegisterType<FilaLastIdQueryHandler>().As<IQueryHandler<FilaLastIdQuery, ResultadoQuery<FilaQuery>>>();

            return _containerBuilder;
        }
    }
}