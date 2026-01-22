using FinanzasPersonales.Application.DTOs;
using FinanzasPersonales.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("api/cuentas")]
public class CuentasController : ControllerBase
{
    private readonly CuentaService _cuentaService;

    // ⚠️ Por ahora hardcodeamos el usuario
    private static readonly Guid UsuarioIdFijo =
        Guid.Parse("11111111-1111-1111-1111-111111111111");

    public CuentasController(CuentaService cuentaService)
    {
        _cuentaService = cuentaService;
    }

    // POST api/cuentas
    [HttpPost]
    public async Task<IActionResult> CrearCuenta([FromBody] CrearCuentaDto dto)
    {
        await _cuentaService.CrearCuentaAsync(UsuarioIdFijo, dto);
        return Ok();
    }

    // GET api/cuentas
    [HttpGet]
    public async Task<IActionResult> ObtenerCuentas()
    {
        var cuentas = await _cuentaService.ObtenerCuentasAsync(UsuarioIdFijo);
        return Ok(cuentas);
    }
}