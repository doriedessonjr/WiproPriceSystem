using Autofac;
using WiproPriceSystem.Application.Dispatcher;
using WiproPriceSystem.Domain.CommandData.Base;
using WiproPriceSystem.Domain.CommandData.Command;
using WiproPriceSystem.Domain.CommandData.CommandHandler;
using WiproPriceSystem.Domain.CommandData.Resultado;
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
            //_containerBuilder.RegisterType<BuscaDeFilaApplication>().AsSelf();
            
            //Geral
            _containerBuilder.RegisterType<CommandMessageDispatcher>().AsSelf();
            _containerBuilder.RegisterType<QueryMessageDispatcher>().AsSelf();
            _containerBuilder.RegisterType<LocalContext>().AsSelf();

            //Repositories
            _containerBuilder.RegisterType<FilaInsertRepository>().As<IInsertFilaRepository>();

            //Handlers
            _containerBuilder.RegisterType<CadastrarFilaCommandHandler>().As<ICommandHandler<ListaFilaCommand, ResultadoCommand>>();

            return _containerBuilder;
        }
    }
}