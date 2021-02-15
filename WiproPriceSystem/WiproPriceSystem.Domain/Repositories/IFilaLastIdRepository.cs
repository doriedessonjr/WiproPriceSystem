using WiproPriceSystem.Domain.QueryData.Queries;

namespace WiproPriceSystem.Domain.Repositories
{
    public interface IFilaLastIdRepository : ISearchRepository<FilaLastIdQuery, FilaQuery>
    {
    }
}