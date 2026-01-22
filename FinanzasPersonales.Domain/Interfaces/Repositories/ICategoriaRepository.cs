using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Domain.Interfaces.Repositories;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> ObtenerPorUsuarioAsync(Guid usuarioId);
    Task CrearAsync(Categoria categoria);
}