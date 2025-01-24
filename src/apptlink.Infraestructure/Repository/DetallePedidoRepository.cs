using System;
using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Parsing;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace apptlink.Infraestructure.Repository;

public class DetallePedidoRepository : IDetallePedidoContract
{
    private readonly DB _context;
    private readonly ILogger<DetallePedidoRepository> _logger;

    public DetallePedidoRepository(DB context, ILogger<DetallePedidoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> SaveSomeDetails(List<DetallePedidoType> detalles)
    {
        try
        {
            _logger.LogInformation("Inicia DetallePedido controller - Metodo - SaveSomeDetails");
            List<DetallePedidoModel> models = DetallePedidoParsing.ModelToType(detalles);
            await _context.DetallePedido.AddRangeAsync(models);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo SaveSomeDetails - DetallePedido controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza DetallePedido controller - Metodo - SaveSomeDetails");
        }
    }

    public async Task<List<DetallePedidoType>> GetDetallesPedidosByPedido(int id)
    {
        try
        {
            _logger.LogInformation("Inicia DetallePedido controller - Metodo - Get");
            List<DetallePedidoModel> models = await _context.DetallePedido.Where(x => x.PedidoId == id).ToListAsync();
            return DetallePedidoParsing.ModelToType(models);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo get - DetallePedido controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza DetallePedido controller - Metodo - Get");
        }
    }

    public async Task<bool> DeleteDetallesPedidos(int id)
    {
        try
        {
            _logger.LogInformation("Inicia DetallePedido controller - Metodo - Delete");
            DetallePedidoModel? model = await _context.DetallePedido.FindAsync(id);
            if (model is null) return false;
            _context.DetallePedido.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - DetallePedido controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza DetallePedido controller - Metodo - Delete");
        }
    }

    public async Task<DetallePedidoType> GetDetallePedidoID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia DetallePedido controller - Metodo - Get");
            DetallePedidoModel? model = await _context.DetallePedido.FirstOrDefaultAsync(x => x.PedidoId == id);
            if (model is null) return null!;
            return DetallePedidoParsing.ModelToType(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo get - DetallePedido controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza DetallePedido controller - Metodo - Get");
        }
    }

    public async Task<List<DetallePedidoType>> GetDetallesPedidos()
    {
        try
        {
            _logger.LogInformation("Inicia DetallePedido controller - Metodo - Get");
            List<DetallePedidoModel> models = await _context.DetallePedido.ToListAsync();
            return DetallePedidoParsing.ModelToType(models);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo get - DetallePedido controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza DetallePedido controller - Metodo - Get");
        }
    }

    public async Task<bool> PostDetallesPedidos(DetallePedidoType categoria)
    {
        try
        {
            _logger.LogInformation("Inicia DetallePedido controller - Metodo - Post");
            DetallePedidoModel model = DetallePedidoParsing.ModelToType(categoria);
            _context.DetallePedido.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo post - DetallePedido controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza DetallePedido controller - Metodo - Post");
        }
    }

    public async Task<bool> PutDetallesPedidos(DetallePedidoType categoria)
    {
        try
        {
            _logger.LogInformation("Inicia DetallePedido controller - Metodo - Put");
            DetallePedidoModel? model = await _context.DetallePedido.FindAsync(categoria.Id);
            if (model is null) return false;
            model = DetallePedidoParsing.ModelToType(categoria);
            
            _context.DetallePedido.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo put - DetallePedido controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza DetallePedido controller - Metodo - Put");
        }
    }
}
