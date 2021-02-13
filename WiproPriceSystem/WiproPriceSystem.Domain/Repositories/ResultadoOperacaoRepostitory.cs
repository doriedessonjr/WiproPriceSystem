using System.Collections.Generic;
using WiproPriceSystem.Domain.Entities;

namespace WiproPriceSystem.Domain.Repositories
{
    public class ResultadoOperacaoRepostitory<TResultObject>
    {
        public ResultadoOperacaoRepostitory()
        {
            Resultado = new List<TResultObject>();
            Erros = new List<Erro>();
        }
        public bool ExecutouComSucesso { get; set; }
        public string Mensagem { get; set; }
        public List<TResultObject> Resultado { get; set; }
        public List<Erro> Erros { get; set; }
    }
}