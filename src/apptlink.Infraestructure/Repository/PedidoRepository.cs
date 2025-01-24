using System;
using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Parsing;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace apptlink.Infraestructure.Repository;

public class PedidoRepository : IPedidosContract
{
    private readonly DB _context;
    private readonly ILogger<PedidoRepository> _logger;

    public PedidoRepository(DB context, ILogger<PedidoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> DeletePedidos(int id)
    {
        try
        {
            _logger.LogInformation("Inicia pedido controller - Metodo - Delete");
            PedidoModel? pedido = await _context.Pedido.FindAsync(id);
            if (pedido is null) return false;
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - pedido controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza pedido controller - Metodo - Delete");
        }
    }

    public async Task<List<PedidoType>> GetPedidos()
    {
        try
        {
            _logger.LogInformation("Inicia pedido controller - Metodo - Delete");
            List<PedidoModel> pedidos = await _context.Pedido.ToListAsync();
            return PedidoParsing.ModelToType(pedidos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - pedido controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza pedido controller - Metodo - Delete");
        }
    }

    public async Task<PedidoType> GetPedidosID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia pedido controller - Metodo - Delete");
            PedidoModel? pedido = await _context.Pedido.FindAsync(id);
            if (pedido is null) return null!;
            return PedidoParsing.ModelToType(pedido);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - pedido controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza pedido controller - Metodo - Delete");
        }
    }

    public async Task<bool> PostPedidos(PedidoType pedidos)
    {
        try
        {
            _logger.LogInformation("Inicia pedido controller - Metodo - Delete");
            PedidoModel pedidoModel = PedidoParsing.ModelToType(pedidos);
            _context.Pedido.Add(pedidoModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - pedido controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza pedido controller - Metodo - Delete");
        }
    }

    public async Task<bool> PutPedidos(PedidoType pedidos)
    {
        try
        {
            _logger.LogInformation("Inicia pedido controller - Metodo - Delete");
            PedidoModel? pedidoModel = await _context.Pedido.FindAsync(pedidos.Id);
            if (pedidoModel is null) return false;
            pedidoModel = PedidoParsing.ModelToType(pedidos);
            
            _context.Pedido.Update(pedidoModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - pedido controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza pedido controller - Metodo - Delete");
        }
    }
}
