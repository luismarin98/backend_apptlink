using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Types;

public class DetallePedidoType
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("pedido_id")] public int PedidoId { get; set; }
    [JsonPropertyName("producto_id")] public int ProductoId { get; set; }
    [JsonPropertyName("cantidad")] public int Cantidad { get; set; }
    [JsonPropertyName("precio_unitario")] public decimal PrecioUnitario { get; set; }
    [JsonPropertyName("descuento")] public decimal Descuento { get; set; }
    [JsonPropertyName("impuesto")] public decimal Impuesto { get; set; }
}
