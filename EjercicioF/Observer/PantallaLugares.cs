using System;

namespace TP2_NicolasSanchez.EjercicioF.Observer
{
    public class PantallaLugares : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            Console.WriteLine($"[Pantalla] Lugares libres: {evento.LugaresLibres}");
        }
    }
}
