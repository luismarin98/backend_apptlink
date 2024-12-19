using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Types;

public class PedidoType : BaseType
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("usuario_id")] public int UsuarioId { get; set; }
    [JsonPropertyName("fecha_pedido")] public DateTime FechaPedido { get; set; }
    [JsonPropertyName("estado")] public string? Estado { get; set; }
    [JsonPropertyName("total")] public decimal Total { get; set; }
}
