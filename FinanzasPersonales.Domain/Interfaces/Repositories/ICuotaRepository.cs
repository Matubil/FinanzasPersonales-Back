using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Domain.Interfaces.Repositories;

public interface ICuotaRepository
{
    Task InsertManyAsync(IEnumerable<Cuota> cuotas, CancellationToken ct);
}