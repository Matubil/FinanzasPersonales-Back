namespace FinanzasPersonales.Domain.Entities;

public class Cuota
{
    public Guid CuotaId { get; private set; }
    public Guid MovimientoId { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Guid CuentaId { get; private set; }

    public int NumeroCuota { get; private set; }
    public int TotalCuotas { get; private set; }
    public decimal Monto { get; private set; }
    public DateOnly Periodo { get; private set; }

    public bool Pagada { get; private set; }

    public Cuota(
        Guid movimientoId,
        Guid usuarioId,
        Guid cuentaId,
        int numeroCuota,
        int totalCuotas,
        decimal monto,
        DateOnly periodo)
    {
        CuotaId = Guid.NewGuid();
        MovimientoId = movimientoId;
        UsuarioId = usuarioId;
        CuentaId = cuentaId;
        NumeroCuota = numeroCuota;
        TotalCuotas = totalCuotas;
        Monto = monto;
        Periodo = periodo;
        Pagada = false;
    }
}
