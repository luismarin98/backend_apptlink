using System;
using apptlink.Application.Contract;
using apptlink.Infraestructure.Context;
using Microsoft.Extensions.Logging;

namespace apptlink.Infraestructure.Repository;

public class CategoriaRepository : ICategoriaContract
{
    private readonly DB _context;
    private readonly ILogger<CategoriaRepository> _logger;

    public CategoriaRepository(DB context, ILogger<CategoriaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
}
