using System;
using System.Linq;
using WiproPriceSystem.Domain.Entities;
using WiproPriceSystem.Domain.Repositories;
using WiproPriceSystem.Infra.EF.Context;

namespace WiproPriceSystem.Infra.Repositories
{
    public class FilaDeleteRepository : IDeleteFilaRepository
    {
        private LocalContext _context;
        public FilaDeleteRepository()
        {
            _context = new LocalContext();
        }

        public Fila Deletar(Fila source)
        {
            try
            {
                //Carrega os dados da fila do banco
                Fila _filaBD = _context.Filas.Where(e => e.FilaId == source.FilaId).FirstOrDefault();

                //Se o registro existir, faz a alteração
                if (_filaBD != null)
                {
                    _context.Filas.Remove(_filaBD);
                    _context.SaveChanges();
                }

                return source;
            }
            catch (Exception exp)
            {
                throw new Exception("Ocorreu o seguinte erro durante a persistência dos dados: " + exp.ToString());
            }
        }
    }
}