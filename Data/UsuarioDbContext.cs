using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data;

/*
Diferente da abordagem padrão quando se trata de Identity devemos extender 
da clase IdentityDbContext e passar o tipo de usuário que estamos utilizando
*/
public class UsuarioDbContext : IdentityDbContext<Usuario>{
    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts){}

}

