namespace FinanzasPersonales.Domain.Entities;

public class Usuario
{
    public Guid UsuarioId { get; private set; }
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;

    protected Usuario() { }

    public Usuario(string email, string passwordHash)
    {
        UsuarioId = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
    }
}