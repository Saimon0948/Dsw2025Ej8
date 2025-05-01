namespace Dsw2025Ej8.Domain;

    public abstract class CuentaBancaria
{
    public string _numero { get; }
    public decimal _saldo { get; protected set; }
    public Estado _estado { get; protected set; }
    public string[] _titulares { get; set; } = Array.Empty<string>(); 

    protected CuentaBancaria(string numero, decimal saldo, Estado estado)
    {
        _numero = numero;
        _estado = estado;
        _saldo = saldo;
    }

    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
    public abstract void AplicarInteres();
}
