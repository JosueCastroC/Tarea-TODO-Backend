using System.Globalization;
using TodoApi.Interfaces;
using TodoApi.Repositories;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Configuración de la cadena de conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("Database");
if (connectionString.IsNullOrEmpty())
    throw new Exception("Missing database connection string.");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITODOMessageRepository, TODOMessageRepository>();
builder.Services.AddTransient<IMiembrosRepository, MiembrosRepository>();
builder.Services.AddTransient<IMembresiaRepository, MembresiaRepository>();
builder.Services.AddDbContext<TODODbContext>((opts) =>
{
    opts.UseSqlServer(connectionString);
    opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Configurar CORS: permitir cualquier origen, método y cabecera
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Ejecutar migraciones
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<TODODbContext>();
    app.Logger.LogInformation("connecting to db");
    ctx.Database.Migrate();
}

// Configuración del pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

// Habilitar CORS antes de Authorization
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();
app.Run();
