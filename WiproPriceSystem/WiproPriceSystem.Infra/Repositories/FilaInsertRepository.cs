using System;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Domain.Repositories;
using WiproPriceSystem.Infra.EF.Context;

namespace WiproPriceSystem.Infra.Repositories
{
    public class FilaInsertRepository : IInsertFilaRepository
    {
        private LocalContext _context;
        public FilaInsertRepository()
        {
            _context = new LocalContext();
        }

        public Fila Inserir(Fila source)
        {
            try
            {
                
                //Insere e salva o novo aplicativo
                Fila fila = new Fila();
                fila.Moeda = source.Moeda;
                fila.DataInicio = source.DataInicio;
                fila.DataFim = source.DataFim;

                _context.Filas.Add(fila);
                _context.SaveChanges();

                return source;
            }
            catch (Exception exp)
            {
                throw new Exception("Ocorreu o seguinte erro durante a persistência dos dados: "+exp.ToString());
            }
        }
    }
}