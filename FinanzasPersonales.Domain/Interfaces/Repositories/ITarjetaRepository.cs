using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Domain.Interfaces.Repositories;

public interface ITarjetaRepository
{
    Task<Tarjeta> GetByIdAsync(Guid tarjetaId, CancellationToken ct);
}