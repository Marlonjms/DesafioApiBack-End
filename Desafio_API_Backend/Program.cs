using Desafio_API_Backend.Data;
using Desafio_API_Backend.Serviços.Moto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//avisa a interface que seus metódos serão implementados dentro do serviço
builder.Services.AddScoped<MotoInterface, MotoServiços>();


// Configuração do DbContext com a string de conexão
//pegando a string de conexão no arquivo appsettings.json e mandando para a classe ContextoBancoDeDados.cs
builder.Services.AddDbContext<ContextoBancoDeDados>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
