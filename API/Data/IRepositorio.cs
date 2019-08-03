
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IRepositorio
    {
        Task<T> Agregar<T> (T Entity) where T : class;
        void Eliminar<T> (T Entity) where T : class;
        Task<bool> Actualizar<T> (T Entity) where T : class;
        Task<bool> ActualizarLista<T> (List<T> Entity) where T : class;
        Task<List<T>> Listar<T> (Expression<Func<T, bool>> predicado) where T: class;
        Task<T> Obtener<T> (Expression<Func<T, bool>> predicado) where T: class;
    }
}