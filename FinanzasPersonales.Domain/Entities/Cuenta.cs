using FinanzasPersonales.Domain.Enums;

namespace FinanzasPersonales.Domain.Entities;

public class Cuenta
{
    public Guid CuentaId { get; private set; }
    public Guid UsuarioId { get; private set; }
    public string Nombre { get; private set; } = null!;
    public Moneda Moneda { get; private set; }
    public decimal SaldoInicial { get; private set; }
    public bool Activa { get; private set; }

    protected Cuenta() { }

    public Cuenta(Guid usuarioId, string nombre, Moneda moneda, decimal saldoInicial)
    {
        CuentaId = Guid.NewGuid();
        UsuarioId = usuarioId;
        Nombre = nombre;
        Moneda = moneda;
        SaldoInicial = saldoInicial;
        Activa = true;
    }
}