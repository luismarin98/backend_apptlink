using System;
using apptlink.Domain.Models;
using apptlink.Domain.Types;

namespace apptlink.Domain.Parsing;

public static class ProductoParsing
{
    public static ProductosModel ModelToType(ProductoType type)
    {
        ProductosModel model = new ProductosModel
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

    public static ProductoType ModelToType(ProductosModel model)
    {
        ProductoType type = new ProductoType
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

    public static List<ProductoType> ModelToType(List<ProductosModel> model) => model.Select(ModelToType).ToList();
    public static List<ProductosModel> ModelToType(List<ProductoType> type) => type.Select(ModelToType).ToList();
}
