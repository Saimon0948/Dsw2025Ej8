using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal _limiteDeDescubierto { get; set; }
        public decimal _comision { get; set; }

        public CuentaCorriente(string numero, decimal saldo, Estado estado)
            : base(numero, saldo, estado)
        {
        }

        public override void Depositar(decimal monto)
        {
            if (monto <= 0) throw new
                    MontoNoValidoException();
            if (_estado != Estado.Activa)

            monto -= monto * _comision;
            _saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0) throw new 
                    MontoNoValidoException();
            if (_estado != Estado.Activa) throw new
                    CuentaNoActivaException(_estado);

            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
                if (_saldo < 0)
                {
                    _estado = Estado.Suspendida;
                }
            }
            else
            {
                _estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }
        }

        public override void AplicarInteres()
        {

        }
    }
}
