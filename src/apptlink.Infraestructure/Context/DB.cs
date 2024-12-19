using System;
using apptlink.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apptlink.Infraestructure.Context;

public class DB : DbContext
{
    public DB(DbContextOptions<DB> options) : base(options) { }

    public DbSet<CategoriaModel> Categoria => Set<CategoriaModel>();
    public DbSet<PedidoModel> Pedido => Set<PedidoModel>();
    public DbSet<ProductosModel> Producto => Set<ProductosModel>();
    public DbSet<UsuarioModel> Usuario => Set<UsuarioModel>();
    public DbSet<DetallePedidoModel> DetallePedido => Set<DetallePedidoModel>();

}
