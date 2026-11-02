using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_NicolasSanchez
{
    internal class EjercicioB
    {
        // ============================================
        // SECCIÓN B — Pregunta 1
        //
        // ¿Qué imprime?: Creando contador
        //                1
        //                2
        //                3
        //                True
        //
        // ¿Cuántas veces aparece "Creando contador" y por qué?: "Creando contador" aparece 1 vez, porque el constructor es privado y solo se llama una vez cuando se crea la instancia del contador.
        //
        // ¿Por qué b.Siguiente() no devuelve 1?: porque "a.Siguiente()" ya incrementó el contador a 1, y luego "b.Siguiente()" lo incrementa a 2, por lo que "b.Siguiente()" devuelve 2.
        // ============================================
        //
        // ============================================
        // SECCIÓN B — Pregunta 2
        //
        // ¿Qué imprime?: Sin propina: 20000
        //                10%: 22000
        //                Fija: 21500
        //
        // En este código, ¿quién es el contexto y quiénes son las estrategias?: El contexto es la clase Cuenta, y las estrategias son la interfaz IPropina, y
        //                                                                       las clases SinPropina, Propina10 y PropinaFija que implementan la interfaz IPropina.
        //
        // ¿Qué hubo que modificar de Cuenta para poder usar PropinaFija? ¿Qué principio se cumple?: No hubo que modificar absolutamente nada en la clase Cuenta.
        //                                                                                           Porque cumple el Principio Open/Closed.
        // ============================================
        //
        // ============================================
        // SECCIÓN B — Pregunta 3
        //
        // ¿Qué imprime?: Nuevo video: Patrones en C#
        //                Lu mira Patrones en C#
        //                Tomi mira Patrones en C#
        //                Avisos registrados: 1
        //                Nuevo video: Observer en WinForms
        //                Tomi mira Observer en WinForms
        //                Avisos registrados: 2
        //
        // ¿Por qué Lu no aparece en la segunda publicación?: Porque Lu se desuscribió del canal antes de la segunda publicación, por lo que no recibe el aviso de la segunda publicación.
        //
        // ¿Canal conoce la clase Fan? ¿Cómo te das cuenta mirando el código?: No, canal no cono la clase Fan, porque canal solo conoce la interfaz IObserver,
        //                                                                     y Fan implementa esa interfaz. Por lo que canal solo interactúa con la interfaz y no con la clase concreta.
        // ============================================
    }
}
