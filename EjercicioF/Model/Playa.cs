using System;
using System.Collections.Generic;
using System.Linq;
using TP2_NicolasSanchez.EjercicioF.Factory;
using TP2_NicolasSanchez.EjercicioF.Observer;
using TP2_NicolasSanchez.EjercicioF.Repository;
using TP2_NicolasSanchez.EjercicioF.Strategy;

namespace TP2_NicolasSanchez.EjercicioF.Model
{
    public class Playa
    {
        private readonly int _capacidad;
        private readonly Dictionary<string, ITarifa> _vehiculos = new Dictionary<string, ITarifa>(StringComparer.OrdinalIgnoreCase);
        private readonly List<IPlayaObserver> _observadores = new List<IPlayaObserver>();
        private readonly IPlayaRepository? _repository;

        public int Capacidad => _capacidad;
        public int LugaresLibres => _capacidad - _vehiculos.Count;
        public int Ocupados => _vehiculos.Count;
        public IReadOnlyDictionary<string, ITarifa> Vehiculos => _vehiculos;

        public Playa(int capacidad = 10, IPlayaRepository? repository = null)
        {
            if (capacidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacidad), "La capacidad debe ser mayor a 0.");

            _capacidad = capacidad;
            _repository = repository;
        }

        public void Suscribir(IPlayaObserver o)
        {
            if (o != null && !_observadores.Contains(o))
            {
                _observadores.Add(o);
            }
        }

        public void Desuscribir(IPlayaObserver o)
        {
            if (o != null)
            {
                _observadores.Remove(o);
            }
        }

        private void Notificar(EventoPlaya evento)
        {
            // Recorre una copia (.ToList()) para evitar InvalidOperationException en modificaciones concurrentes
            foreach (var observador in _observadores.ToList())
            {
                observador.Actualizar(evento);
            }
        }

        public void Ingresar(string patente, string codigoTarifa)
        {
            if (string.IsNullOrWhiteSpace(patente))
                throw new InvalidOperationException("La patente no puede estar vacía.");

            string patenteNormalizada = patente.Trim().ToUpperInvariant();

            if (_vehiculos.ContainsKey(patenteNormalizada))
                throw new InvalidOperationException($"El vehículo con patente {patenteNormalizada} ya se encuentra en la playa.");

            if (LugaresLibres <= 0)
                throw new InvalidOperationException("La playa está llena. No hay lugares disponibles.");

            ITarifa tarifa = TarifaFactory.Crear(codigoTarifa);
            _vehiculos[patenteNormalizada] = tarifa;

            var evento = new EventoPlaya(TipoEvento.Ingreso, patenteNormalizada, 0m, LugaresLibres);
            Notificar(evento);

            _repository?.RegistrarMovimiento(new MovimientoVehiculo
            {
                Patente = patenteNormalizada,
                Tipo = TipoEvento.Ingreso,
                TarifaCodigo = codigoTarifa.Trim().ToUpperInvariant(),
                Minutos = 0,
                Importe = 0m,
                LugaresLibres = LugaresLibres,
                FechaHora = DateTime.Now
            });
        }

        public decimal Egresar(string patente, int minutos)
        {
            if (string.IsNullOrWhiteSpace(patente))
                throw new InvalidOperationException("La patente no puede estar vacía.");

            string patenteNormalizada = patente.Trim().ToUpperInvariant();

            if (!_vehiculos.TryGetValue(patenteNormalizada, out ITarifa? tarifa))
                throw new InvalidOperationException($"El vehículo con patente {patenteNormalizada} no se encuentra en la playa.");

            if (minutos < 0)
                throw new ArgumentOutOfRangeException(nameof(minutos), "Los minutos no pueden ser negativos.");

            decimal importe = tarifa.Calcular(minutos);
            _vehiculos.Remove(patenteNormalizada);

            var evento = new EventoPlaya(TipoEvento.Egreso, patenteNormalizada, importe, LugaresLibres);
            Notificar(evento);

            _repository?.RegistrarMovimiento(new MovimientoVehiculo
            {
                Patente = patenteNormalizada,
                Tipo = TipoEvento.Egreso,
                TarifaCodigo = tarifa.Nombre,
                Minutos = minutos,
                Importe = importe,
                LugaresLibres = LugaresLibres,
                FechaHora = DateTime.Now
            });

            return importe;
        }
    }
}
