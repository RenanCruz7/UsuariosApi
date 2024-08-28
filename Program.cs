using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Conection string para o banco de dados
var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");

// Conexao com o banco de dados
builder.Services.AddDbContext<UsuarioDbContext>( opts =>
    opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

builder.Services
    .AddIdentity<Usuario, IdentityRole>() // Adicionando conceito de identidade
    .AddEntityFrameworkStores<UsuarioDbContext>() //conecta com o banco de dados
    .AddDefaultTokenProviders(); // questao de autenticacao

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
