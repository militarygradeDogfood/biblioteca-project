using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Repository;
using WebApplication1.NewFolder;
using WebApplication1.Repository;
using WebApplication1.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using WebApplication1.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
var configValue = builder.Configuration.GetValue<string>("Connection");


var logFilePath = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory,
    "Logs",
    "api-errors.log");

Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

builder.Services.AddSingleton(new FileLogger(logFilePath));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseMiddleware<ErrorLoggingMiddleware>();

app.MapControllers();

app.Run();

using (var connection = new SqlConnection(configValue))
{
    var sql = "INSERT INTO Libro(autor, titulo, estado, isbn) VALUES (@autor, @titulo, @estado, @isbn)";

    var libroTest = new
    {
        titulo = "JRR Tolkien",
        autor = "El Señor de los Anillos: La Comunidad del Anillo",
        estado = 0,
        isbn = "ASDF1234"
    };

    var rowsAffected1 = connection.Execute(sql, libroTest);

    var insertedLibro = connection.Query<Libro>("SELECT * FROM Libro").ToList();
}

