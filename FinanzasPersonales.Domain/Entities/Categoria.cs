namespace FinanzasPersonales.Domain.Entities;

public class Categoria
{
    public Guid CategoriaId { get; private set; }
    public Guid UsuarioId { get; private set; }
    public string Nombre { get; private set; } = null!;
    public bool EsIngreso { get; private set; }

    protected Categoria() { }

    public Categoria(Guid usuarioId, string nombre, bool esIngreso)
    {
        CategoriaId = Guid.NewGuid();
        UsuarioId = usuarioId;
        Nombre = nombre;
        EsIngreso = esIngreso;
    }
}