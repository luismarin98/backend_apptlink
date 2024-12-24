using System;
using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Parsing;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> DeleteCategoria(int id)
    {
        try
        {
            _logger.LogInformation("Inicia categoria controller - Metodo - Delete");
            CategoriaModel? categoria = await _context.Categoria.FindAsync(id);
            if (categoria is null) return false;
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo delete - categoria controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza categoria controller - Metodo - Delete");
        }
    }

    public async Task<CategoriaType> GetCategoriaID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia categoria controller - Metodo - Get");
            CategoriaModel? categoria = await _context.Categoria.FindAsync(id);
            if (categoria is null) return null!;
            return CategoriaParsing.ModelToType(categoria);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo get - categoria controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza categoria controller - Metodo - Get");
        }
    }

    public async Task<List<CategoriaType>> GetCategorias()
    {
        try
        {
            _logger.LogInformation("Inicia categoria controller - Metodo - Get");
            List<CategoriaModel> categorias = await _context.Categoria.ToListAsync();
            return CategoriaParsing.ModelToType(categorias);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo get - categoria controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza categoria controller - Metodo - Get");
        }
    }

    public async Task<bool> PostCategoria(CategoriaType categoria)
    {
        try
        {
            _logger.LogInformation("Inicia categoria controller - Metodo - Post");
            CategoriaModel categoriaModel = CategoriaParsing.ModelToType(categoria);
            _context.Categoria.Add(categoriaModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo post - categoria controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza categoria controller - Metodo - Post");
        }
    }

    public async Task<bool> PutCategoria(CategoriaType categoria)
    {
        try
        {
            _logger.LogInformation("Inicia categoria controller - Metodo - Put");
            CategoriaModel categoriaModel = CategoriaParsing.ModelToType(categoria);
            _context.Categoria.Update(categoriaModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo put - categoria controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza categoria controller - Metodo - Put");
        }
    }
}
