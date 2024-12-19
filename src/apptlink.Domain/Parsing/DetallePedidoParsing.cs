using System;
using apptlink.Domain.Models;
using apptlink.Domain.Types;

namespace apptlink.Domain.Parsing;

public static class DetallePedidoParsing
{
    public static DetallePedidoModel ModelToType(DetallePedidoType type)
    {
        DetallePedidoModel model = new DetallePedidoModel
        {
            Cantidad = type.Cantidad,
            Descuento = type.Descuento,
            Id = type.Id,
            Impuesto = type.Impuesto,
            PedidoId = type.PedidoId,
            PrecioUnitario = type.PrecioUnitario,
            ProductoId = type.ProductoId
        };
        return model;
    }

    public static DetallePedidoType ModelToType(DetallePedidoModel model)
    {
        DetallePedidoType type = new DetallePedidoType
        {
            Cantidad = model.Cantidad,
            Descuento = model.Descuento,
            Id = model.Id,
            Impuesto = model.Impuesto,
            PedidoId = model.PedidoId,
            PrecioUnitario = model.PrecioUnitario,
            ProductoId = model.ProductoId
        };
        return type;
    }

    public static List<DetallePedidoModel> ModelToType(List<DetallePedidoType> type) => type.Select(ModelToType).ToList();
    public static List<DetallePedidoType> ModelToType(List<DetallePedidoModel> model) => model.Select(ModelToType).ToList();
}
