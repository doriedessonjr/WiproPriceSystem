using System;

namespace WiproPriceSystem.Domain.QueryData.Queries
{
    public class FilaQuery
    {
        public string Moeda { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}