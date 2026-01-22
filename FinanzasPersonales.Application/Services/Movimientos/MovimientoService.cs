using FinanzasPersonales.Application.DTOs.Movimientos;
using FinanzasPersonales.Application.Services.Cuotas;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Domain.Interfaces.Repositories;

namespace FinanzasPersonales.Application.Services.Movimientos;

public class MovimientoService
{
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly ICuotaRepository _cuotaRepository;
    private readonly ITarjetaRepository _tarjetaRepository;

    public MovimientoService(
        IMovimientoRepository movimientoRepository,
        ICuotaRepository cuotaRepository,
        ITarjetaRepository tarjetaRepository)
    {
        _movimientoRepository = movimientoRepository;
        _cuotaRepository = cuotaRepository;
        _tarjetaRepository = tarjetaRepository;
    }

    public async Task<CrearMovimientoResult> CrearAsync(
        CrearMovimientoCommand command,
        CancellationToken ct)
    {
        // 1. Validaciones básicas
        if (command.Monto <= 0)
            throw new InvalidOperationException("El monto debe ser mayor a 0");

        if (command.CantidadCuotas < 1)
            throw new InvalidOperationException("Cantidad de cuotas inválida");

        if (command.CantidadCuotas > 1 && command.TarjetaId is null)
            throw new InvalidOperationException("Las cuotas requieren tarjeta");

        // 2️. Crear movimiento
        var movimiento = new Movimiento(
            command.UsuarioId,
            command.CuentaId,
            command.CategoriaId,
            command.Monto,
            command.Fecha,
            command.EsIngreso,
            command.Descripcion,
            command.CantidadCuotas,
            command.TarjetaId
        );

        await _movimientoRepository.InsertAsync(movimiento, ct);

        // 3. Generar cuotas si corresponde
        var cuotasGeneradas = 0;

        if (command.CantidadCuotas > 1)
        {
            var tarjeta = await _tarjetaRepository.GetByIdAsync(
                command.TarjetaId!.Value, ct);

            var cuotas = CuotaCalculator.GenerarCuotas(
                movimiento.MovimientoId,
                command.UsuarioId,
                command.CuentaId,
                command.Fecha,
                command.Monto,
                command.CantidadCuotas,
                tarjeta.DiaCierreTipo!
            );

            await _cuotaRepository.InsertManyAsync(cuotas, ct);
            cuotasGeneradas = cuotas.Count;
        }

        return new CrearMovimientoResult
        {
            MovimientoId = movimiento.MovimientoId,
            CuotasGeneradas = cuotasGeneradas
        };
    }
}
