using System;
using apptlink.Domain.Models;
using apptlink.Domain.Types;

namespace apptlink.Domain.Parsing;

public static class CategoriaParsing
{
    public static CategoriaModel ModelToType(CategoriaType type)
    {
        CategoriaModel model = new CategoriaModel
        {
            CategoriaId = type.CategoriaId,
            Descripcion = type.Descripcion,
            FechaActualizacion = DateTime.Now,
            FechaCreacion = type.FechaCreacion,
            Id = type.Id,
            Nombre = type.Nombre,
            Precio = type.Precio,
            Stock = type.Stock
        };
        return model;
    }

    public static CategoriaType ModelToType(CategoriaModel model)
    {
        CategoriaType type = new CategoriaType
        {
            CategoriaId = model.CategoriaId,
            Descripcion = model.Descripcion,
            FechaActualizacion = DateTime.Now,
            FechaCreacion = model.FechaCreacion,
            Id = model.Id,
            Nombre = model.Nombre,
            Precio = model.Precio,
            Stock = model.Stock
        };
        return type;
    }

    public static List<CategoriaType> ModelToType(List<CategoriaModel> model) => model.Select(ModelToType).ToList();
    public static List<CategoriaModel> ModelToType(List<CategoriaType> type) => type.Select(ModelToType).ToList();
}
