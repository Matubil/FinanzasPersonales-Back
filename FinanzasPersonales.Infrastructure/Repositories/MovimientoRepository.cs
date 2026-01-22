using Dapper;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Domain.Interfaces.Repositories;
using FinanzasPersonales.Infrastructure.Data;

namespace FinanzasPersonales.Infrastructure.Repositories;

public class MovimientoRepository : IMovimientoRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public MovimientoRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InsertAsync(Movimiento movimiento, CancellationToken ct)
    {
        const string sql = """
                               INSERT INTO movimientos (
                                   movimiento_id,
                                   usuario_id,
                                   cuenta_id,
                                   categoria_id,
                                   monto,
                                   fecha,
                                   descripcion,
                                   es_ingreso,
                                   cantidad_cuotas,
                                   tarjeta_id
                               )
                               VALUES (
                                   @MovimientoId,
                                   @UsuarioId,
                                   @CuentaId,
                                   @CategoriaId,
                                   @Monto,
                                   @Fecha,
                                   @Descripcion,
                                   @EsIngreso,
                                   @CantidadCuotas,
                                   @TarjetaId
                               );
                           """;

        using var connection = _connectionFactory.Create();
        await connection.ExecuteAsync(sql, movimiento);
    }

    public async Task<IEnumerable<Movimiento>> ObtenerPorCuentaAsync(Guid cuentaId, CancellationToken ct)
    {
        const string sql = """
                               SELECT *
                               FROM movimientos
                               WHERE cuenta_id = @CuentaId
                               ORDER BY fecha DESC;
                           """;

        using var connection = _connectionFactory.Create();
        return await connection.QueryAsync<Movimiento>(sql, new { CuentaId = cuentaId });
    }
}