using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Domain.Repositories;

namespace WiproPriceSystem.Infra.Repositories
{
    public abstract class RepositoryBase<TSourceObject, TResultObject>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        protected RepositoryBase()
        {
            Erros = new List<Erro>();
        }
        /// <summary>
        /// Executa a query e retorna o resultado do processamento
        /// </summary>
        /// <typeparam name="TResultObject"></typeparam>
        /// <returns></returns>
        public ResultadoOperacaoRepostitory<TResultObject> ExecutarQuery()
        {

            SqlConnection _conn = null;
            SqlCommand _command = null;
            SqlDataReader _reader = null;

            ResultadoOperacaoRepostitory<TResultObject> _resultado = new ResultadoOperacaoRepostitory<TResultObject>();
            TResultObject _resultObject = default(TResultObject);

            #region query
            String _query = this.Query();
            #endregion query            

            try
            {
                _conn = new SqlConnection();
                _conn.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["LocalContext"]);

                _command = _conn.CreateCommand();
                _command.CommandText = _query;
                _command.CommandType = System.Data.CommandType.Text;

                _conn.Open();
                _reader = _command.ExecuteReader();

                if (_reader != null && _reader.HasRows)
                {
                    try
                    {
                        _resultObject = Parse(ref _reader);
                        _resultado.Resultado.Add(_resultObject);
                    }
                    catch (Exception exp)
                    {
                        _resultado.Erros.Add(new Erro() { Mensagem = exp.ToString() });
                    }
                }

                _resultado.ExecutouComSucesso = true;
                _resultado.Mensagem = $"Pesquisa efetuada com sucesso";
                _resultado.Erros.Concat(Erros);
            }
            catch (Exception exp)
            {
                _resultado.ExecutouComSucesso = false;
                _resultado.Mensagem = $"Ocorreu um erro durante pesquisa";
                _resultado.Erros.Add(new Erro() { Mensagem = exp.ToString() });
            }
            finally
            {
                if (_reader != null)
                {
                    _reader.Close();
                }

                if (_command != null)
                {
                    _command.Dispose();
                }

                if (_conn != null)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
            }

            return _resultado;
        }

        protected List<Erro> Erros { get; set; }

        /// <summary>
        /// Através do reader re
        /// </summary>
        /// <typeparam name="TResultObject"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public abstract TResultObject Parse(ref SqlDataReader reader);

        public abstract string Query();
    }
}