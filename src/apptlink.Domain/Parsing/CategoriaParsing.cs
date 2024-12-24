using System;
using apptlink.Domain.Models;
using apptlink.Domain.Types;

namespace apptlink.Domain.Parsing;

public static class CategoriaParsing
{
    public static CategoriaModel ModelToType(CategoriaType type)
    {
        CategoriaModel model = new CategoriaModel { Descripcion = type.Descripcion, Id = type.Id, Nombre = type.Nombre };
        return model;
    }

    public static CategoriaType ModelToType(CategoriaModel model)
    {
        CategoriaType type = new CategoriaType { Descripcion = model.Descripcion, Id = model.Id, Nombre = model.Nombre };
        return type;
    }

    public static List<CategoriaType> ModelToType(List<CategoriaModel> model) => model.Select(ModelToType).ToList();
    public static List<CategoriaModel> ModelToType(List<CategoriaType> type) => type.Select(ModelToType).ToList();
}
