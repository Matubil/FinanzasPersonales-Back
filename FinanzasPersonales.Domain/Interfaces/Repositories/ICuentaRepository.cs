using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Domain.Interfaces.Repositories;

public interface ICuentaRepository
{
    Task<IEnumerable<Cuenta>> ObtenerPorUsuarioAsync(Guid usuarioId);
    Task<Cuenta?> ObtenerPorIdAsync(Guid cuentaId);
    Task CrearAsync(Cuenta cuenta);
    Task ActualizarAsync(Cuenta cuenta);
}