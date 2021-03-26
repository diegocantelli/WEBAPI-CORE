using DevIO.Api.Data;
using DevIO.Api.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //Adicionando o contexto de BD do Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Adicionando o serviço do identity e o configurando
            services.AddDefaultIdentity<IdentityUser>()
                //permite criar "papeis/níveis" de usuários
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                //Configurando o identity para exibir as msgs de erro traduzidas
                .AddErrorDescriber<IdentityMensagensPortugues>()
                //usado para gerar tokens para resetar senhas via email e etc
                .AddDefaultTokenProviders();
            
            return services;
        }
    }
}
