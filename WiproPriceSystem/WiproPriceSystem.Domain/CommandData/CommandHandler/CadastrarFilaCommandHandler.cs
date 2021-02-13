using WiproPriceSystem.Domain.CommandData.Base;
using WiproPriceSystem.Domain.CommandData.Command;
using WiproPriceSystem.Domain.CommandData.Resultado;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Domain.Repositories;
using System;

namespace WiproPriceSystem.Domain.CommandData.CommandHandler
{
    public class CadastrarFilaCommandHandler : ICommandHandler<FilaCommand, ResultadoCommand>
    {
        private readonly IInsertFilaRepository _repositorio;

        public CadastrarFilaCommandHandler(IInsertFilaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public ResultadoCommand Handle(FilaCommand command)
        {

            ResultadoCommand _resultado = new ResultadoCommand();

            try
            {
                Fila _fila = new Fila();
                _fila.Moeda = command.Moeda;
                _fila.DataInicio = command.DataInicio;
                _fila.DataFim = command.DataFim;

                _fila = _repositorio.Inserir(_fila);

                _resultado.Codigo = 0; //Executou com sucesso
                _resultado.Mensagem = $"Fila atualizada com sucesso";

            }
            catch (Exception exp)
            {
                _resultado.Codigo = 1; //Não executou com sucesso
                _resultado.Mensagem = "Ocorreu o seguinte erro ao adicionar os dados à fila: "+exp.ToString();

            }

            return _resultado;
        }
    }
}