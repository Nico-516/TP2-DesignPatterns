using System;

namespace TP2_NicolasSanchez.EjercicioF.Observer
{
    public class CajaObserver : IPlayaObserver
    {
        private decimal _totalRecaudado = 0m;

        public decimal TotalRecaudado => _totalRecaudado;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == TipoEvento.Egreso)
            {
                _totalRecaudado += evento.Importe;
                Console.WriteLine($"[Caja] Cobrado $ {FormatoMoneda.Formatear(evento.Importe)} a {evento.Patente}. Recaudado: $ {FormatoMoneda.Formatear(_totalRecaudado)}");
            }
        }
    }
}
