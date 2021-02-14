using System;
using System.Data.SqlClient;
using WiproPriceSystem.Domain.QueryData.Queries;
using WiproPriceSystem.Domain.Repositories;

namespace WiproPriceSystem.Infra.Repositories
{
    public class FilaLastIdRepository : RepositoryBase<FilaLastIdQuery, FilaQuery>, IFilaLastIdRepository
    {
        /// <summary>
        /// Retorna a query a ser executada
        /// </summary>
        /// <returns></returns>
        public override string Query()
        {
            #region query
            String _query = @"SELECT Top 1 FilaId
                                          ,Moeda
                                          ,DataInicio
                                          ,DataFim
                                      FROM Wipro.dbo.Fila
                                      Order By FilaId Desc";
            #endregion query            
            return _query;
        }

        /// <summary>
        /// Converte o Reader no objeto a ser retornado
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public override FilaQuery Parse(ref SqlDataReader reader)
        {
            FilaReadParser _parser = new FilaReadParser();
            return _parser.Parse(ref reader, Erros);
        }

        /// <summary>
        /// Localiza o item a partir da query passada
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ResultadoOperacaoRepostitory<FilaQuery> LocalizarItem()
        {
            return ExecutarQuery();
        }
    }
}