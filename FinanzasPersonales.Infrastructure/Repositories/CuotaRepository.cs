using Dapper;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Domain.Interfaces.Repositories;
using FinanzasPersonales.Infrastructure.Data;

namespace FinanzasPersonales.Infrastructure.Repositories;

public class CuotaRepository : ICuotaRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public CuotaRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InsertManyAsync(IEnumerable<Cuota> cuotas, CancellationToken ct)
    {
        const string sql = """
                               INSERT INTO cuotas (
                                   cuota_id,
                                   movimiento_id,
                                   usuario_id,
                                   cuenta_id,
                                   numero_cuota,
                                   total_cuotas,
                                   monto,
                                   periodo,
                                   pagada
                               )
                               VALUES (
                                   @CuotaId,
                                   @MovimientoId,
                                   @UsuarioId,
                                   @CuentaId,
                                   @NumeroCuota,
                                   @TotalCuotas,
                                   @Monto,
                                   @Periodo,
                                   @Pagada
                               );
                           """;

        using var connection = _connectionFactory.Create();
        await connection.ExecuteAsync(sql, cuotas);
    }
}