using Dapper;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Domain.Interfaces.Repositories;
using FinanzasPersonales.Infrastructure.Data;

namespace FinanzasPersonales.Infrastructure.Repositories;

public class CuentaRepository : ICuentaRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public CuentaRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Cuenta>> ObtenerPorUsuarioAsync(Guid usuarioId)
    {
        using var connection = _connectionFactory.Create();

        const string sql = """
            SELECT 
                cuenta_id AS CuentaId,
                usuario_id AS UsuarioId,
                nombre,
                moneda,
                saldo_inicial AS SaldoInicial,
                activa
            FROM cuentas
            WHERE usuario_id = @UsuarioId
        """;

        return await connection.QueryAsync<Cuenta>(sql, new { UsuarioId = usuarioId });
    }

    public async Task<Cuenta?> ObtenerPorIdAsync(Guid cuentaId)
    {
        using var connection = _connectionFactory.Create();

        const string sql = """
            SELECT 
                cuenta_id AS CuentaId,
                usuario_id AS UsuarioId,
                nombre,
                moneda,
                saldo_inicial AS SaldoInicial,
                activa
            FROM cuentas
            WHERE cuenta_id = @CuentaId
        """;

        return await connection.QueryFirstOrDefaultAsync<Cuenta>(sql, new { CuentaId = cuentaId });
    }

    public async Task CrearAsync(Cuenta cuenta)
    {
        using var connection = _connectionFactory.Create();

        const string sql = """
            INSERT INTO cuentas
            (cuenta_id, usuario_id, nombre, moneda, saldo_inicial, activa)
            VALUES
            (@CuentaId, @UsuarioId, @Nombre, @Moneda, @SaldoInicial, @Activa)
        """;

        await connection.ExecuteAsync(sql, cuenta);
    }

    public async Task ActualizarAsync(Cuenta cuenta)
    {
        using var connection = _connectionFactory.Create();

        const string sql = """
            UPDATE cuentas
            SET nombre = @Nombre,
                activa = @Activa
            WHERE cuenta_id = @CuentaId
        """;

        await connection.ExecuteAsync(sql, cuenta);
    }
}
