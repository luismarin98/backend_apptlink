using System;
using apptlink.Application.Contract;
using apptlink.Infraestructure.Context;
using Microsoft.Extensions.Logging;

namespace apptlink.Infraestructure.Repository;

public class UsuarioRepository : IUsuarioContract
{
    private readonly DB _context;
    private readonly ILogger<UsuarioRepository> _logger;

    public UsuarioRepository(DB context, ILogger<UsuarioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
}
