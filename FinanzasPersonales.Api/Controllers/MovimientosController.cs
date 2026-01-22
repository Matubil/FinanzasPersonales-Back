using FinanzasPersonales.Application.DTOs.Movimientos;
using FinanzasPersonales.Application.Services.Movimientos;
using FinanzasPersonales.Contracts.Movimientos;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosController : ControllerBase
{
    private readonly MovimientoService _movimientoService;

    public MovimientosController(MovimientoService movimientoService)
    {
        _movimientoService = movimientoService;
    }

    [HttpPost]
    public async Task<IActionResult> Crear(
        [FromBody] CrearMovimientoRequest request,
        CancellationToken ct)
    {
        var command = new CrearMovimientoCommand
        {
            UsuarioId = request.UsuarioId,
            CuentaId = request.CuentaId,
            CategoriaId = request.CategoriaId,
            Monto = request.Monto,
            Fecha = request.Fecha,
            Descripcion = request.Descripcion,
            EsIngreso = request.EsIngreso,
            CantidadCuotas = request.CantidadCuotas,
            TarjetaId = request.TarjetaId
        };

        var result = await _movimientoService.CrearAsync(command, ct);

        return CreatedAtAction(
            nameof(Crear),
            new { id = result.MovimientoId },
            result
        );
    }
}