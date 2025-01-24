using System;
using System.Text;
using apptlink.Application.Contract;
using apptlink.Infraestructure.Configuracion;
using apptlink.Infraestructure.Context;
using apptlink.Infraestructure.Repository;
using apptlink.Infraestructure.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace apptlink.Infraestructure;

public static class InfraestructureServices
{
    public static IServiceCollection AddServicesCollection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoriaContract, CategoriaRepository>();
        services.AddScoped<IDetallePedidoContract, DetallePedidoRepository>();
        services.AddScoped<IPedidosContract, PedidoRepository>();
        services.AddScoped<IProductoContract, ProductoRepository>();
        services.AddScoped<IUsuarioContract, UsuarioRepository>();
        services.AddScoped<IFacturaContract, FacturaRepository>();
        services.AddSingleton<EmailService>();
        services.AddScoped<CreatePDF>();
        services.AddScoped<JWTGenerate>();

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };
        });

        services.AddDbContext<DB>(opts => opts.UseSqlServer(configuration.GetConnectionString("apptlink")));

        return services;
    }
}
