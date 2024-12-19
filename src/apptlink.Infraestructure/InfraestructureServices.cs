using System;
using apptlink.Application.Contract;
using apptlink.Infraestructure.Context;
using apptlink.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        services.AddDbContext<DB>(opts => opts.UseSqlServer(configuration.GetConnectionString("apptlink")));

        return services;
    }
}
