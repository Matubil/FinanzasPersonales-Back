namespace FinanzasPersonales.Domain.Entities;

public class Movimiento
{
    public Guid MovimientoId { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Guid CuentaId { get; private set; }
    public Guid CategoriaId { get; private set; }

    public decimal Monto { get; private set; }
    public DateOnly Fecha { get; private set; }
    public bool EsIngreso { get; private set; }
    public string? Descripcion { get; private set; }

    public int CantidadCuotas { get; private set; }
    public Guid? TarjetaId { get; private set; }

    public Movimiento(
        Guid usuarioId,
        Guid cuentaId,
        Guid categoriaId,
        decimal monto,
        DateOnly fecha,
        bool esIngreso,
        string? descripcion,
        int cantidadCuotas,
        Guid? tarjetaId)
    {
        MovimientoId = Guid.NewGuid();
        UsuarioId = usuarioId;
        CuentaId = cuentaId;
        CategoriaId = categoriaId;
        Monto = monto;
        Fecha = fecha;
        EsIngreso = esIngreso;
        Descripcion = descripcion;
        CantidadCuotas = cantidadCuotas;
        TarjetaId = tarjetaId;
    }

    // Constructor para Dapper
    protected Movimiento() { }
}