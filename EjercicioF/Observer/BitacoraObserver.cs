using TP2_NicolasSanchez.EjercicioF.Bitacora;

namespace TP2_NicolasSanchez.EjercicioF.Observer
{
    public class BitacoraObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == TipoEvento.Ingreso)
            {
                Bitacora.Bitacora.Instancia.Registrar($"Ingresó {evento.Patente}");
            }
            else if (evento.Tipo == TipoEvento.Egreso)
            {
                Bitacora.Bitacora.Instancia.Registrar($"Egresó {evento.Patente} - $ {FormatoMoneda.Formatear(evento.Importe)}");
            }
        }
    }
}
