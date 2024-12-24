using System;
using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Parsing;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace apptlink.Infraestructure.Repository;

public class ProductoRepository : IProductoContract
{
    private readonly DB _context;
    private readonly ILogger<ProductoRepository> _logger;

    public ProductoRepository(DB context, ILogger<ProductoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> DeleteProducto(int id)
    {
        try
        {
            _logger.LogInformation("Inicia producto controller - Metodo - Delete");
            ProductosModel? producto = await _context.Producto.FindAsync(id);
            if (producto is null) return false;
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - producto controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza producto controller - Metodo - Delete");
        }
    }

    public async Task<ProductoType> GetProductoID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia producto controller - Metodo - GET");
            ProductosModel? producto = await _context.Producto.FindAsync(id);
            if (producto is null) return null!;
            return ProductoParsing.ModelToType(producto);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error en metodo get - producto controller");
           return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza producto controller - Metodo - GET");
        }
    }

    public async Task<List<ProductoType>> GetProductos()
    {
        try
        {
            _logger.LogInformation("Inicia producto controller - Metodo - GET");
            List<ProductosModel> productos = await _context.Producto.ToListAsync();
            return ProductoParsing.ModelToType(productos);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error en metodo get - producto controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza producto controller - Metodo - GET");
        }
    }

    public async Task<bool> PostProducto(ProductoType producto)
    {
        try
        {
            _logger.LogInformation("Inicia producto controller - Metodo - POST");
            ProductosModel productoModel = ProductoParsing.ModelToType(producto);
            _context.Producto.Add(productoModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error en metodo POST - producto controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza producto controller - Metodo - POST");
        }
    }

    public async Task<bool> PutProducto(ProductoType producto)
    {
        try
        {
            _logger.LogInformation("Inicia producto controller - Metodo - Delete");
            ProductosModel productoModel = ProductoParsing.ModelToType(producto);
            _context.Producto.Update(productoModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - producto controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza producto controller - Metodo - Delete");
        }
    }
}
