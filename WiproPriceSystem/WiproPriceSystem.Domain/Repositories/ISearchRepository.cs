namespace WiproPriceSystem.Domain.Repositories
{
    public interface ISearchRepository<TParamObject, TResultObject>
    {

        /// <summary>
        /// Efetua a busca de dados através dos parametros
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ResultadoOperacaoRepostitory<TResultObject> LocalizarItem();
    }
}