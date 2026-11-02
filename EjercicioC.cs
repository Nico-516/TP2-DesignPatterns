using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_NicolasSanchez
{
    internal class EjercicioC
    {
        // ============================================
        // SECCIÓN C — Pregunta 1
        //
        // ¿Cuál es el error y de qué tipo es?: Error de ejecución del tipo "InvalidOperationException".
        // 
        // ¿Por qué ocurre?: Porque dentro del bucle foreach, se esta modificando la lista en tiempo de ejecucion, porque la clase "AvisoUnico" se desuscribe de la alarma,
        //                   y al desuscribirse, se elimina de la lista de suscriptores, lo que provoca que el enumerador del foreach se invalide y lance la excepción.
        //
        // ¿Cómo se corrige?: Se resuelve cambiando "foreach (var o in _observadores)" por "foreach (var o in _observadores.ToList())"
        //
        // ============================================
        //
        // ============================================
        // SECCIÓN C — Pregunta 2
        //
        // ¿Cuál es el error y de qué tipo es?: Error de diseño. No se aplica el patrón Strategy ni el del Principio Open/Closed.
        // 
        // ¿Qué pasa cuando llega un tipo nuevo, por ejemplo "Bicicleta"?: En este caso, habria que modificar la clase EnvioStrategyy el metodo Calcular.
        // 
        // ¿Cómo se corrige? (escribí las clases): public class EnvioMoto : IEnvioStrategy
        //                                         {
        //                                            public decimal Calcular(decimal pesoKg) => 1500 + pesoKg * 100;
        //                                         }
        //
        //                                         public class EnvioCamion : IEnvioStrategy
        //                                         {
        //                                            public decimal Calcular(decimal pesoKg) => 8000 + pesoKg * 40;
        //                                         }
        //
        //                                         public class EnvioEstandar : IEnvioStrategy
        //                                         {
        //                                            public decimal Calcular(decimal pesoKg) => 3000 + pesoKg * 70;
        //                                         }
        //
        // ============================================
        //
        // ============================================
        // SECCIÓN C — Pregunta 3
        //
        // ¿Cuál es el error y de qué tipo es?: De compilacion. el error es del tipo "CS0161: 'NotificadorFactory.Crear(string)': not all code paths return a value".
        // 
        // ¿Cómo se corrige?: Agregando esta linea "throw new ArgumentException($"Canal de notificación no soportado: '{canal}'", nameof(canal));"
        // 
        // ¿Por qué conviene lanzar una excepción con un mensaje claro y no devolver null?: Porque de esta manera, se avisa del posible error de manera inmediata, 
        //                                                                                  mientras que si fuera null, el error puede pasar desapercibido y volver a repetirse.
        // ============================================
    }
}
