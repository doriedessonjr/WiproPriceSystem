namespace WiproPriceSystem.Domain.Repositories
{
    public interface IInsertRepository<TSourceObject> where TSourceObject : class
    {
        /// <summary>
        /// Insere os dados do objeto no banco retornando o mesmo
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        TSourceObject Inserir(TSourceObject source);
    }
}