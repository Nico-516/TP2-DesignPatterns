using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_NicolasSanchez
{
    internal class EjercicioA
    {
        // ============================================
        // SECCIÓN A — Pregunta 1
        // Respuesta: C
        // ¿Por qué?: Porque al estar privado, no es accesible por otras clases, por lo que solamente pueden usar el metodo publico, el cual tiene una logica
        //            para devolver un appLogger si ya existia de antes, y si no, crear uno nuevo. De esta manera se asegura que solo exista un appLogger en toda la aplicacion.
        // ===
        // Opción descartada: Se descarta la opción B porque la propiedad pública "Instancia" es solo el punto de acceso para obtener el objeto ya creado,
        //                    no el mecanismo que bloquea la instanciación externa.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 2
        // Respuesta: A
        // ¿Por qué?: Porque por defecto la instancia es nula, y solamente se le asigna un valor cuando se llama al metodo publico por primera vez,
        //            de ahi en adelante siempre devuelve la misma instancia.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 3
        // Respuesta: D
        // ¿Por qué?: Porque encapsula las distintas funciones bajo un contrato, lo que permite que se puedan agregar nuevas opciones como clases.
        // ===
        // Opción descartada: Se descarta la opción C porque construir objetos complejos paso a paso es la definición del patrón Builder, no de Strategy.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 4
        // Respuesta: B
        // ¿Por qué?: Porque el contexto es el que le da informacion al strategy de que hacer, mientras que el metodo no tiene necesidad de saber que se va a ejecutar,
        //            por eso funciona como un punto de acceso para ejecutar distintas estrategias.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 5
        // Respuesta: C
        // ¿Por qué?: Porque en este caso se puede suponer que se necesitan varias formas de crear objetos dependiendo de las opciones elegidas.
        //            Por lo que se justifica el metodo factory, ya que permite centralizar la logica de creacion condicional de objetos.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 6
        // Respuesta: A
        // ¿Por qué?: Factory Method se basa en herencia y polimorfismo (delegación a subclases),
        //            mientras que Simple Factory centraliza la selección en un único método (habitualmente estático) sin jerarquía de creadores.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 7
        // Respuesta: B
        // ¿Por qué?: Porque gracias a esa lista de referencias, se puede publicar los cambios a todos los suscriptores,
        //            sin necesidad de que el publicador conozca a cada uno de ellos.
        // ===
        // Opción descartada: Se descarta la opción A porque guardar listas de tipos concretos acoplaría el notificador rígidamente a cada vista o servicio.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 8
        // Respuesta: D
        // ¿Por qué?: Esto pasa porque el notificador todavia tiene una referencia al form destruido, y al intentar notificarlo,
        //            el form ya no existe, por lo que se produce un error.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 9
        // Respuesta: B
        // ¿Por qué?: btnGuardar_Click es el método manejador que se asocia como callback para recibir la notificación cuando el emisor (btnGuardar) dispara el evento.
        // ============================================

        // ============================================
        // SECCIÓN A — Pregunta 10
        // Respuesta: C
        // ¿Por qué?: Porque agregar una nueva clase es la unica de esas 4 opciones que no modifica el codigo exxistente, cumpliendo el open/closed.
        // ============================================

    }
}
