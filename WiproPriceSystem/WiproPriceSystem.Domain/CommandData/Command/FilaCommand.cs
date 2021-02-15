using System;
using WiproPriceSystem.Domain.CommandData.Base;

namespace WiproPriceSystem.Domain.CommandData.Command
{
    public class FilaCommand : ICommand
    {
        public int FilaId { get; set; }
        public string Moeda { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}