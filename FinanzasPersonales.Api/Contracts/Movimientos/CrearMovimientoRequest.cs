namespace FinanzasPersonales.Contracts.Movimientos;

public class CrearMovimientoRequest
{
    public Guid UsuarioId { get; init; }
    public Guid CuentaId { get; init; }
    public Guid CategoriaId { get; init; }

    public decimal Monto { get; init; }
    public DateOnly Fecha { get; init; }
    public string? Descripcion { get; init; }

    public bool EsIngreso { get; init; }

    public int CantidadCuotas { get; init; } = 1;
    public Guid? TarjetaId { get; init; }
}