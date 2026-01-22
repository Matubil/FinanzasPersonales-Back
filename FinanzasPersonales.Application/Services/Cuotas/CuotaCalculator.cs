using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Services.Cuotas;

public static class CuotaCalculator
{
    public static DateOnly ObtenerUltimoJueves(int year, int month)
    {
        var lastDay = new DateOnly(year, month, DateTime.DaysInMonth(year, month));

        while (lastDay.DayOfWeek != DayOfWeek.Thursday)
        {
            lastDay = lastDay.AddDays(-1);
        }

        return lastDay;
    }

    public static List<Cuota> GenerarCuotas(
        Guid movimientoId,
        Guid usuarioId,
        Guid cuentaId,
        DateOnly fechaCompra,
        decimal montoTotal,
        int cantidadCuotas,
        string diaCierreTipo
    )
    {
        DateOnly fechaCierre;

        if (diaCierreTipo == "ultimo_jueves")
        {
            fechaCierre = ObtenerUltimoJueves(fechaCompra.Year, fechaCompra.Month);
        }
        else
        {
            throw new NotSupportedException("Tipo de cierre no soportado");
        }

        DateOnly primerPeriodo;

        if (fechaCompra <= fechaCierre)
        {
            primerPeriodo = new DateOnly(fechaCompra.Year, fechaCompra.Month, 1)
                .AddMonths(1);
        }
        else
        {
            primerPeriodo = new DateOnly(fechaCompra.Year, fechaCompra.Month, 1)
                .AddMonths(2);
        }

        var montoCuota = Math.Round(montoTotal / cantidadCuotas, 2);

        var cuotas = new List<Cuota>();

        for (int i = 1; i <= cantidadCuotas; i++)
        {
            cuotas.Add(new Cuota(
                movimientoId,
                usuarioId,
                cuentaId,
                i,
                cantidadCuotas,
                montoCuota,
                primerPeriodo.AddMonths(i - 1)
            ));
        }

        return cuotas;
    }
}