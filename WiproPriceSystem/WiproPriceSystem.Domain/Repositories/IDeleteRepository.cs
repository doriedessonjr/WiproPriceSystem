namespace WiproPriceSystem.Domain.Repositories
{
    public interface IDeleteRepository<TSourceObject> where TSourceObject : class
    {
        /// <summary>
        /// Deleta os dados do item passado
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        TSourceObject Deletar(TSourceObject source);
    }
}