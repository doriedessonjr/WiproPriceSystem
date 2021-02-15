using System.Collections.Generic;

namespace WiproPriceSystem.Domain.QueryData.Base
{
    public class ResultadoQuery<TResultObject> where TResultObject : class
    {
        public string Mensagem { get; set; }
        public IEnumerable<TResultObject> Resultado { get; set; }
        public bool ExecutouComSucesso { get; set; }
    }
}