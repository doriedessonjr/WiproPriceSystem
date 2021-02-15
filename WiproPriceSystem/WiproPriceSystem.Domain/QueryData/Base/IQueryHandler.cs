
namespace WiproPriceSystem.Domain.QueryData.Base
{
    /// <summary>
    /// Manipulador para queries
    /// </summary>
    /// <typeparam name="TSourceObject">Query com a solicitação dos recuros</typeparam>
    /// <typeparam name="TResult">Resutlado do processamento</typeparam>
    public interface IQueryHandler<TSourceObject, TResult>
        where TSourceObject : IQuery
    {

        /// <summary>
        /// Recebe uma query efetuando o processamento e a pesquisa
        /// no banco retornando o resultado solicitado
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        TResult Handle(TSourceObject source);
    }
}