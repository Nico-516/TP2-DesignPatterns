using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_NicolasSanchez
{
    internal class EjercicioE
    {
        // ============================================
        // SECCIÓN E — Pregunta 1
        //
        // Patron y por que: Strategy, porque permite aislar el calculo de envio dependiendo del vehiculo, y permite agregar nuevas opciones de envio sin modificar el contexto.
        //                   Tambien se le puede agregar Factory Method para crear los distintos tipos de envio dependiendo del vehiculo.
        // ============================================
        //
        // ============================================
        // SECCIÓN E — Pregunta 2
        // Patron y por que: Observer, porque permite que todas las partes del negocio se suscriban al pedido y reciban notificaciones cuando cambia de estado.
        //                   Y tambien se puede agregar el Whatsapp del cliente como un observador mas, sin modificar el contexto.
        // ============================================
        //
        // ============================================
        // SECCIÓN E — Pregunta 3
        // Patron y por que: Singleton, porque al mantener una sola instancia global de la clase, no permite que haya multiples instancias creando discrepancias con otras pantallas.
        //                   Tambien se le podria agregar Observer para que todas las pantallas se suscriban a la instancia del singleton y reciban notificaciones cuando cambie de estado.
        // ============================================
        //
        // ============================================
        // SECCIÓN E — Pregunta 4
        // Patron y por que: Factory, porque es con este patron, centralizamos la logica de creacion de objetos dependiendo que texto devuelva el Json, y asi tener una creacion automatica condicional.
        // ============================================
        //
        // ============================================
        // SECCIÓN E — Pregunta 5
        // Patron y por que: Ninguno, porque en este caso, hay una sola opcion de creacion de objetos, por lo que no se justifica el uso de un patron como Factory.
        // ============================================
    }
}
