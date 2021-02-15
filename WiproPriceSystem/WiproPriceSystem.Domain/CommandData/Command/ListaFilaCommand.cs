using System.Collections.Generic;
using WiproPriceSystem.Domain.CommandData.Base;
using WiproPriceSystem.Domain.Entities;

namespace WiproPriceSystem.Domain.CommandData.Command
{
    public class ListaFilaCommand : ICommand
    {
        public ListaFilaCommand()
        {
            Root = new List<Fila>();
        }

        public List<Fila> Root { get; set; }
    }
}