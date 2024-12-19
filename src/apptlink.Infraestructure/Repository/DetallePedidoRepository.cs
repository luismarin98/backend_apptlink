using System;
using apptlink.Application.Contract;
using apptlink.Infraestructure.Context;
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
}
