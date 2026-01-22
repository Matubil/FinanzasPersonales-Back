namespace FinanzasPersonales.Domain.Entities;

public class Tarjeta
{
    public Guid TarjetaId { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Guid CuentaId { get; private set; }

    public string Nombre { get; private set; } = null!;
    public string Ultimos4 { get; private set; } = null!;

    public decimal? Limite { get; private set; }
    public bool Activa { get; private set; }

    // Reglas de tarjeta
    public string? DiaCierreTipo { get; private set; }
    public int? DiaVencimiento { get; private set; }

    // Constructor para crear tarjeta nueva
    public Tarjeta(
        Guid usuarioId,
        Guid cuentaId,
        string nombre,
        string ultimos4,
        decimal? limite,
        string? diaCierreTipo,
        int? diaVencimiento)
    {
        TarjetaId = Guid.NewGuid();
        UsuarioId = usuarioId;
        CuentaId = cuentaId;
        Nombre = nombre;
        Ultimos4 = ultimos4;
        Limite = limite;
        Activa = true;
        DiaCierreTipo = diaCierreTipo;
        DiaVencimiento = diaVencimiento;
    }

    // Constructor vacío para Dapper
    protected Tarjeta() { }
}