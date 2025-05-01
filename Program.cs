using System.Linq.Expressions;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

            var caja1 = new CajaDeAhorro("CA01", 1000m, Estado.Suspendida) { _tasaDeInteres = 0.05m, _titulares = new[] { "Joel" } };
            var caja2 = new CajaDeAhorro("CA02", 100m, Estado.Inactiva) { _tasaDeInteres = 0.03m, _titulares = new[] { "Milton" } };

            var cc1 = new
                CuentaCorriente("CC001", 500m, Estado.Activa)
            {
                _comision = 0.02m,
                _limiteDeDescubierto = 300m,
                _titulares = new[] { "Damian" }
            };
            var cc2 = new
               CuentaCorriente("CC002", 900m, Estado.Activa)
            {
                _comision = 0.01m,
                _limiteDeDescubierto = 300m,
                _titulares = new[] { "Simon" }

            };
            cuentas.AddRange(new CuentaBancaria[] { caja1, caja2, cc1, cc2 });

            foreach (var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(200);
                }
                catch (Exception ex) {Console.WriteLine($"[Despositar]{ex.Message} "); }
                try
                {
                    cuenta.Retirar(150);
                }
                catch (Exception ex) { Console.WriteLine($"[Retirar] {ex.Message}"); }
                try
                {
                    cuenta.AplicarInteres();
                }
                catch (Exception ex) { Console.WriteLine($"[Interes] {ex.Message}"); }
            }

            try { caja2.Depositar(0); } 
            catch (Exception ex) {
                Console.WriteLine($"[Error esperado] {ex.Message}"); }

            try { cc2.Retirar(300); }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error esperado] {ex.Message}");
            }

            Console.WriteLine("\n---Resumen de Cuentas---");

            foreach (var c in cuentas)
            {
                var resumen = new
                {
                    Titular = string.Join(",",c._titulares),
                    Numero = c._numero,
                    Tipo = c.GetType().Name,
                    Saldo = c._saldo,
                    Estado = c._estado,
                };

                Console.WriteLine($"{resumen.Titular} -{resumen.Numero} -{ resumen.Tipo} -${resumen.Saldo} -{resumen.Estado}");
            }
        }
    }
}
