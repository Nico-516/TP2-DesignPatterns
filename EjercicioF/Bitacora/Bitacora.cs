using System;
using System.Collections.Generic;

namespace TP2_NicolasSanchez.EjercicioF.Bitacora
{
    public class Bitacora
    {
        private static Bitacora? _instancia;
        private readonly List<string> _entradas = new List<string>();
        private int _contador = 0;

        // Regla 1: Constructor privado para evitar instanciación externa
        private Bitacora() { }

        // Regla 2 y 3: Campo estático privado y propiedad estática pública con inicialización lazy
        public static Bitacora Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Bitacora();
                return _instancia;
            }
        }

        public void Registrar(string texto)
        {
            _contador++;
            _entradas.Add($"{_contador:D2}. {texto}");
        }

        public void MostrarTodo()
        {
            Console.WriteLine("--- Bitácora ---");
            foreach (var entrada in _entradas)
            {
                Console.WriteLine(entrada);
            }
        }

        public IReadOnlyList<string> Entradas => _entradas.AsReadOnly();

        public void Reiniciar()
        {
            _entradas.Clear();
            _contador = 0;
        }
    }
}
