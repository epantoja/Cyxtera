using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ValoresBL: IRepositorio
    {
        private readonly DataContext _context;

        public ValoresBL (DataContext context) {
            _context = context;
        }

        public async Task<T> Agregar<T> (T Entity) where T : class {
            _context.Add (Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public void Eliminar<T> (T Entity) where T : class {
            _context.Remove (Entity);
        }

        public async Task<List<T>> Listar<T> (Expression<Func<T, bool>> predicado) where T: class{
            var result = await _context.Set<T>().Where(predicado).ToListAsync();
            return result;
        }

        public async Task<T> Obtener<T> (Expression<Func<T, bool>> predicado) where T: class{
            var result = await _context.Set<T>().Where(predicado).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Actualizar<T> (T Entity) where T : class {
            _context.Set<T>().Update(Entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarLista<T> (List<T> Entity) where T : class {
            _context.Set<T>().UpdateRange(Entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}