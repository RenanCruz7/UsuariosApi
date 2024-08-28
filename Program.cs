using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.Services;

var builder = WebApplication.CreateBuilder(args);
// Conection string para o banco de dados
var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");

// Conexao com o banco de dados
builder.Services.AddDbContext<UsuarioDbContext>
    (opts =>{opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<CadastroService>();

builder.Services
    .AddIdentity<Usuario, IdentityRole>() // Adicionando conceito de identidade
    .AddEntityFrameworkStores<UsuarioDbContext>() //conecta com o banco de dados
    .AddDefaultTokenProviders(); // questao de autenticacao
/*
 * Configuração de senha por padrao são essas: 
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});
*/

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
