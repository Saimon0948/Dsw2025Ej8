using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal _tasaDeInteres { get; set; }

        public CajaDeAhorro(string numero, decimal saldo, Estado estado)
            : base(numero, saldo, estado)
        {
        }

        public override void Depositar(decimal monto)
        {
            if (monto <= 0) throw new
                MontoNoValidoException();
            if (_estado != Estado.Activa) throw new
                CuentaNoActivaException(_estado);

            _saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (_saldo <= monto) throw new 
                MontoNoValidoException();
            if (_estado != Estado.Activa) throw new
                CuentaNoActivaException(_estado);

            if (_saldo >= monto)
            {
                _saldo -= monto;
            }
            else
            {
                _estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }
        }

        public override void AplicarInteres()
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
