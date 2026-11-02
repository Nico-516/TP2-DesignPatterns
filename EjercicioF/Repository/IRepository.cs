using System.Collections.Generic;

namespace TP2_NicolasSanchez.EjercicioF.Repository
{
    public interface IRepository<T>
    {
        void Guardar(T entidad);
        void GuardarTodos(IEnumerable<T> entidades);
        List<T> ObtenerTodos();
        void Limpiar();
    }
}
