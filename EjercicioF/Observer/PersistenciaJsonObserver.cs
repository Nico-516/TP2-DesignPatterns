using System;
using TP2_NicolasSanchez.EjercicioF.Repository;

namespace TP2_NicolasSanchez.EjercicioF.Observer
{
    /// <summary>
    /// Observer opcional que desacopla la persistencia: escucha los eventos de Playa
    /// y guarda cada movimiento en el repositorio JSON de forma automática (Principio Open/Closed).
    /// </summary>
    public class PersistenciaJsonObserver : IPlayaObserver
    {
        private readonly IPlayaRepository _repository;

        public PersistenciaJsonObserver(IPlayaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Actualizar(EventoPlaya evento)
        {
            _repository.RegistrarMovimiento(new MovimientoVehiculo
            {
                Patente = evento.Patente,
                Tipo = evento.Tipo,
                Importe = evento.Importe,
                LugaresLibres = evento.LugaresLibres,
                FechaHora = DateTime.Now
            });
        }
    }
}
