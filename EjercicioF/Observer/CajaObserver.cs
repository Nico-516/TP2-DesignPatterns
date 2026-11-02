using System;

namespace TP2_NicolasSanchez.EjercicioF.Observer
{
    public class CajaObserver : IPlayaObserver
    {
        private decimal _totalPlazaColon = 0m;

        public decimal TotalPlazaColon => _totalPlazaColon;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == TipoEvento.Egreso)
            {
                _totalPlazaColon += evento.Importe;
                Console.WriteLine($"[Caja] Cobrado $ {FormatoMoneda.Formatear(evento.Importe)} a {evento.Patente}. Recaudado: $ {FormatoMoneda.Formatear(_totalPlazaColon)}");
            }
        }
    }
}
