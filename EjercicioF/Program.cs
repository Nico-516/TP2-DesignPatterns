using System;
using TP2_NicolasSanchez.EjercicioF.Bitacora;
using TP2_NicolasSanchez.EjercicioF.Model;
using TP2_NicolasSanchez.EjercicioF.Observer;
using TP2_NicolasSanchez.EjercicioF.Repository;

namespace TP2_NicolasSanchez.EjercicioF
{
    // ==============================================================================================
    // SECCIÓN F — JUSTIFICACIÓN DE PATRONES DE DISEÑO EN LA PLAYA "PLAZA COLÓN"
    // ==============================================================================================
    //
    // 1. SINGLETON (Bitacora)
    //    - Qué problema concreto resolvía en ESTA playa:
    //      Garantiza que exista una única bitácora global compartida y secuencial para toda la playa,
    //      donde todos los observadores y componentes registran eventos sin perder el número correlativo.
    //    - Qué pasaría sin él:
    //      Cada observador o clase crearía su propia instancia mediante 'new Bitacora()', provocando que
    //      los registros queden desparramados, la numeración se reinicie y no exista un historial centralizado.
    //
    // 2. STRATEGY (ITarifa, TarifaHora, TarifaEstadia, TarifaNocturna)
    //    - Qué problema concreto resolvía en ESTA playa:
    //      Encapsula cada algoritmo de cobro (hora fraccionada, estadía de 12hs con excedente, tarifa fija nocturna)
    //      en clases independientes intercambiables que implementan ITarifa.
    //    - Qué pasaría sin él:
    //      Playa tendría un switch/if gigante en Egresar para calcular importes; agregar nuevas tarifas
    //      (como la tarifa MOTO) obligaría a abrir y modificar el método de Playa, violando Open/Closed.
    //
    // 3. FACTORY (TarifaFactory)
    //    - Qué problema concreto resolvía en ESTA playa:
    //      Centraliza en un único lugar la traducción y validación del código recibido como texto ("HORA", "ESTADIA", "NOCHE")
    //      para instanciar la estrategia concreta correcta, lanzando una excepción clara ante códigos desconocidos.
    //    - Qué pasaría sin él:
    //      La lógica de instanciación con new y switch de strings estaría dispersa por toda la aplicación,
    //      acoplando Playa a las implementaciones concretas en vez de operar solo con la interfaz ITarifa.
    //
    // 4. OBSERVER (IPlayaObserver, Playa, PantallaLugares, CajaObserver, AlertaOcupacionObserver, BitacoraObserver)
    //    - Qué problema concreto resolvía en ESTA playa:
    //      Permite que múltiples actores (la pantalla, la caja, la alerta de ocupación crítica y la bitácora)
    //      reaccionen a los ingresos y egresos de vehículos sin que Playa conozca detalles de ninguno de ellos.
    //    - Qué pasaría sin él:
    //      Playa estaría fuertemente acoplada a las clases concretas de Pantalla, Caja, Alerta y Bitácora;
    //      cualquier nuevo requerimiento (ej. alerta por WhatsApp o mail) obligaría a modificar Playa.
    //
    // 5. REPOSITORY (JsonRepository, PlayaJsonRepository en carpeta Datos)
    //    - Qué problema concreto resolvía en ESTA playa:
    //      Abstrae la persistencia de datos y el guardado en formato JSON dentro de la carpeta 'Datos',
    //      desacoplando el almacenamiento físico de la lógica de negocio del estacionamiento.
    //    - Qué pasaría sin él:
    //      El modelo de negocio estaría mezclado con File.WriteAllText y serialización System.Text.Json,
    //      haciendo imposible cambiar la fuente de almacenamiento o realizar pruebas unitarias aisladas.
    // ==============================================================================================

    public static class EjercicioFDemo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== EJERCICIO F: PLAYA 'PLAZA COLÓN' ===\n");

            // 1. Instanciación del repositorio JSON en la carpeta de Datos
            var jsonRepo = new PlayaJsonRepository();
            jsonRepo.LimpiarHistorial();

            // 2. Creación de la Playa (capacidad de 10 lugares) con persistencia por JSON
            var playa = new Playa(10, jsonRepo);
            Bitacora.Bitacora.Instancia.Reiniciar();

            // 3. Creación y suscripción de los observadores
            var pantalla = new PantallaLugares();
            var caja = new CajaObserver();
            var alerta = new AlertaOcupacionObserver();
            var bitacora = new BitacoraObserver();

            playa.Suscribir(pantalla);
            playa.Suscribir(caja);
            playa.Suscribir(alerta);
            playa.Suscribir(bitacora);

            // 4. Ingresan 8 vehículos con distintos códigos de tarifa
            playa.Ingresar("AB123CD", "HORA");
            playa.Ingresar("AC456EF", "ESTADIA");
            playa.Ingresar("AD789GH", "NOCHE");
            playa.Ingresar("AE012IJ", "HORA");
            playa.Ingresar("AF345KL", "ESTADIA");
            playa.Ingresar("AG678MN", "NOCHE");
            playa.Ingresar("AH901OP", "HORA");
            playa.Ingresar("AI234QR", "ESTADIA"); // Al quedar 2 lugares, salta la alerta

            // 5. Egresos con cálculos según la tarifa con la que entró
            playa.Egresar("AB123CD", 150); // HORA, 2 h 30 min -> $ 3.600
            playa.Egresar("AC456EF", 900); // ESTADIA, 15 h    -> $ 9.600

            // 6. Demostración de desuscripción dinámica (la pantalla deja de recibir avisos)
            playa.Desuscribir(pantalla);

            playa.Egresar("AD789GH", 600); // NOCHE            -> $ 4.500

            // 7. Prueba de código de tarifa inválido con try/catch
            try
            {
                playa.Ingresar("AZ999ZZ", "SEMANAL");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // 8. Mostrar la bitácora completa
            Bitacora.Bitacora.Instancia.MostrarTodo();

            // 9. Verificación de los datos persistidos en el archivo JSON
            Console.WriteLine("\n--- PERSISTENCIA EN REPOSITORIO JSON ---");
            Console.WriteLine($"Archivo JSON: {jsonRepo.RutaArchivo}");
            var movimientosGuardados = jsonRepo.ObtenerMovimientos();
            Console.WriteLine($"Total de movimientos guardados en JSON: {movimientosGuardados.Count}");
            Console.WriteLine($"Total recaudado registrado en JSON: $ {FormatoMoneda.Formatear(jsonRepo.ObtenerTotalRecaudado())}");
            Console.WriteLine("=========================================\n");
        }
    }
}
