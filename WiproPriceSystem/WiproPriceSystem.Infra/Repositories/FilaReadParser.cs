using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Domain.QueryData.Queries;

namespace WiproPriceSystem.Infra.Repositories
{
    public class FilaReadParser
    {
        /// <summary>
        /// Converte a Fila a patir de um data reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public FilaQuery Parse(ref SqlDataReader reader, List<Erro> erros)
        {
            FilaQuery _fila = new FilaQuery();

            while (reader.Read())
            {
                try
                {
                    _fila.Moeda = reader["Moeda"] == DBNull.Value ? "" : Convert.ToString(reader["Moeda"]).Trim();
                    _fila.DataInicio = reader["DataInicio"] == DBNull.Value ? System.DateTime.MinValue : Convert.ToDateTime(reader["DataInicio"]);
                    _fila.DataFim = reader["DataFim"] == DBNull.Value ? System.DateTime.MinValue : Convert.ToDateTime(reader["DataFim"]);
                }
                catch (Exception exp)
                {
                    erros.Add(new Erro() { Mensagem = exp.ToString() });
                }

            }

            return _fila;
        }
    }
}