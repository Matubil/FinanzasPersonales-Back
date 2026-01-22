using FinanzasPersonales.Application.Services;
using FinanzasPersonales.Domain.Interfaces.Repositories;
using FinanzasPersonales.Infrastructure.Data;
using FinanzasPersonales.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);


// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de Dependencias
builder.Services.AddScoped<DbConnectionFactory>();
builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
builder.Services.AddScoped<CuentaService>();


var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();