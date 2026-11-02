using System;

namespace TP2_NicolasSanchez.EjercicioF.Observer
{
    public class AlertaOcupacionObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.LugaresLibres <= 2)
            {
                Console.WriteLine($"[Alerta] ¡Quedan {evento.LugaresLibres} lugares!");
            }
        }
    }
}
