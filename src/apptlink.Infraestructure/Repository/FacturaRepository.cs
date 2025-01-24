using System;
using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Infraestructure.Context;
using apptlink.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PdfSharp.Pdf;

namespace apptlink.Infraestructure.Repository;

public class FacturaRepository : IFacturaContract
{
    private readonly ILogger<FacturaRepository> _logger;
    private readonly DB _context;
    private readonly CreatePDF _createPDF;

    public FacturaRepository(ILogger<FacturaRepository> logger, DB context, CreatePDF createPDF)
    {
        _logger = logger;
        _createPDF = createPDF;
        _context = context;
    }

    // Generar factura
    public async Task<PdfDocument> GenerarFactura(int pedido_id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");

            // Buscar pedido
            PedidoModel? pedido = await _context.Pedido.FindAsync(pedido_id);
            // Si no existe el pedido
            if (pedido == null) return null!;
            // Buscar usuario
            UsuarioModel? usuario = await _context.Usuario.FindAsync(pedido.UsuarioId);
            // Si no existe el usuario
            if (usuario == null) return null!;

            // Buscar detalles del pedido
            List<DetallePedidoModel>? ListaDetallesPedidos = await _context.DetallePedido.Where(x => x.PedidoId == pedido.Id).ToListAsync();
            // Si no existen detalles del pedido
            if (ListaDetallesPedidos == null) return null!;

            // Crear PDF
            return await _createPDF.Exect(usuario, pedido, ListaDetallesPedidos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, "Error en metodo repository");
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository");
        }
    }
}
