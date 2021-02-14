using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WiproPriceSystem.Domain.QueryData.Base;
using WiproPriceSystem.Domain.QueryData.Queries;
using WiproPriceSystem.Domain.Repositories;

namespace WiproPriceSystem.Domain.QueryData.QueryHandlers
{
    public class FilaLastIdQueryHandler : IQueryHandler<FilaLastIdQuery, ResultadoQuery<FilaQuery>>
    {
        private readonly IFilaLastIdRepository _repository;

        /// <summary>
        /// Construtor
        /// </summary>
        public FilaLastIdQueryHandler(IFilaLastIdRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Pesquisa último item da Fila
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ResultadoQuery<FilaQuery> Handle(FilaLastIdQuery source)
        {
            ResultadoQuery<FilaQuery> _resultado = new ResultadoQuery<FilaQuery>();
            try
            {
                ResultadoOperacaoRepostitory<FilaQuery> _resultadoQuery = _repository.LocalizarItem();
                
                _resultado.ExecutouComSucesso = _resultadoQuery.ExecutouComSucesso;
                _resultado.Mensagem = _resultadoQuery.Mensagem;
                _resultado.Resultado = _resultadoQuery.Resultado;
            }
            catch (Exception exp)
            {
                _resultado.ExecutouComSucesso = false;
                _resultado.Mensagem = $"Ocorreu um erro durante a execução da operação {exp.ToString()}";
                _resultado.Resultado = new List<FilaQuery>();
            }
            return _resultado;
        }
    }
}