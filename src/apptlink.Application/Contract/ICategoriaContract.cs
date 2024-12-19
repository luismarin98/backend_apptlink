using System;
using apptlink.Domain.Types;

namespace apptlink.Application.Contract;

public interface ICategoriaContract
{
    public Task<CategoriaType> GetCategoriaID(int id);
    public Task<List<CategoriaType>> GetCategorias();
    public Task<bool> PostCategoria(CategoriaType categoria);
    public Task<bool> PutCategoria(CategoriaType categoria);
    public Task<bool> DeleteCategoria(int id);
}
