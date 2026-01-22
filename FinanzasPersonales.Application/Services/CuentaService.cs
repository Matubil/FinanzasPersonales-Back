using FinanzasPersonales.Application.DTOs;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Domain.Interfaces.Repositories;

namespace FinanzasPersonales.Application.Services;

public class CuentaService
{
    private readonly ICuentaRepository _cuentaRepository;

    public CuentaService(ICuentaRepository cuentaRepository)
    {
        _cuentaRepository = cuentaRepository;
    }

    public async Task CrearCuentaAsync(Guid usuarioId, CrearCuentaDto dto)
    {
        var cuenta = new Cuenta(
            usuarioId,
            dto.Nombre,
            dto.Moneda,
            dto.SaldoInicial
        );

        await _cuentaRepository.CrearAsync(cuenta);
    }

    public async Task<IEnumerable<CuentaDto>> ObtenerCuentasAsync(Guid usuarioId)
    {
        var cuentas = await _cuentaRepository.ObtenerPorUsuarioAsync(usuarioId);

        return cuentas.Select(c => new CuentaDto
        {
            CuentaId = c.CuentaId,
            Nombre = c.Nombre,
            Moneda = c.Moneda,
            SaldoInicial = c.SaldoInicial
        });
    }
}