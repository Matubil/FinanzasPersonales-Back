using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Domain.Interfaces.Repositories;

public interface IMovimientoRepository
{
    Task InsertAsync(Movimiento movimiento, CancellationToken ct);
    Task<IEnumerable<Movimiento>> ObtenerPorCuentaAsync(Guid cuentaId, CancellationToken ct);
}