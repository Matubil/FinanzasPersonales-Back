using FinanzasPersonales.Domain.Enums;

namespace FinanzasPersonales.Application.DTOs;

public class CrearCuentaDto
{
    public string Nombre { get; set; } = null!;
    public Moneda Moneda { get; set; }
    public decimal SaldoInicial { get; set; }
}