using System;
using System.Reflection;
using apptlink.Domain.Models;
using apptlink.Domain.Types;

namespace apptlink.Domain.Parsing;

public class PedidoParsing
{
    public static PedidoModel ModelToType(PedidoType type)
    {
        PedidoModel model = new PedidoModel
        {
            Estado = type.Estado,
            FechaActualizacion = DateTime.Now,
            FechaCreacion = type.FechaCreacion,
            FechaPedido = type.FechaPedido,
            Id = type.Id,
            Total = type.Total,
            UsuarioId = type.UsuarioId
        };
        return model;
    }

    public static PedidoType ModelToType(PedidoModel model)
    {
        PedidoType type = new PedidoType
        {
            Estado = model.Estado,
            FechaActualizacion = DateTime.Now,
            FechaCreacion = model.FechaCreacion,
            FechaPedido = model.FechaPedido,
            Id = model.Id,
            Total = model.Total,
            UsuarioId = model.UsuarioId
        };
        return type;
    }

    public static List<PedidoModel> ModelToType(List<PedidoType> type) => type.Select(ModelToType).ToList();
    public static List<PedidoType> ModelToType(List<PedidoModel> model) => model.Select(ModelToType).ToList();
}
