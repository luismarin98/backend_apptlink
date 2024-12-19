using System;
using apptlink.Application.Contract;
using apptlink.Infraestructure.Context;
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
}
