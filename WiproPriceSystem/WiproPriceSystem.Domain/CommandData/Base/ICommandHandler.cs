using WiproPriceSystem.Domain.CommandData.Resultado;

namespace WiproPriceSystem.Domain.CommandData.Base
{
    /// <summary>
    /// Tratador dos comandos
    /// </summary>
    /// <typeparam name="TSourceObject">Commando</typeparam>
    public interface ICommandHandler<TSourceObject, TResultObject>
        where TSourceObject : ICommand
        where TResultObject : IResultadoCommand
    {
        TResultObject Handle(TSourceObject command);
    }
}