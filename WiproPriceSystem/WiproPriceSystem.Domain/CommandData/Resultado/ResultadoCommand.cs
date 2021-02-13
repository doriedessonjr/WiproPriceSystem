namespace WiproPriceSystem.Domain.CommandData.Resultado
{
    public class ResultadoCommand : IResultadoCommand
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}