using Desafio_API_Backend.Data;
using Desafio_API_Backend.Servi�os.Moto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//avisa a interface que seus met�dos ser�o implementados dentro do servi�o
builder.Services.AddScoped<MotoInterface, MotoServi�os>();


// Configura��o do DbContext com a string de conex�o
//pegando a string de conex�o no arquivo appsettings.json e mandando para a classe ContextoBancoDeDados.cs
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
