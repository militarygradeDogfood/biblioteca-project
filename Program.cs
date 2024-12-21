using Biblioteca.Data;
using Biblioteca.Services;
using Biblioteca.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<LibroRepository>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<UsuarioRepository>();


builder.Services.AddScoped<DapperContext>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
