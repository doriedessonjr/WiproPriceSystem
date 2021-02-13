using System;

namespace WiproPriceSystem.Domain.Entities
{
    public class Fila
    {
        public int FilaId { get; set; }
        public string Moeda { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}