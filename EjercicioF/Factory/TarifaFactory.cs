using System;
using System.Collections.Generic;
using TP2_NicolasSanchez.EjercicioF.Strategy;

namespace TP2_NicolasSanchez.EjercicioF.Factory
{
    public static class TarifaFactory
    {
        public static ITarifa Crear(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new ArgumentException("El código de tarifa no puede estar vacío.", nameof(codigo));
            }

            return (codigo.Trim().ToUpperInvariant()) switch
            {
                "HORA" => new TarifaHora(),
                "ESTADIA" => new TarifaEstadia(),
                "NOCHE" or "NOCTURNA" => new TarifaNocturna(),
                _ => throw new ArgumentException($"Código de tarifa desconocido: {codigo}")
            };
        }

        public static List<string> CodigosDisponibles()
        {
            return new List<string> { "HORA", "ESTADIA", "NOCHE" };
        }

        // Métodos de compatibilidad adicionales
        public static ITarifa CrearTarifa(string tipo) => Crear(tipo);
        public static List<string> ObtenerTiposTarifa() => CodigosDisponibles();
    }
}
