using System;
using apptlink.Application.Contract;
using apptlink.Infraestructure.Context;
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
}
