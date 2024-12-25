using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Responses;

public class ProductoResponses
{
    [JsonPropertyName("valor_total")] public decimal valorTotal { get; set; }
    [JsonPropertyName("valor_promedio_precios")] public decimal valorPromedioPrecios { get; set; }
}

public class ReporteProductoResponses
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("nombre")] public string? Nombre { get; set; }
    [JsonPropertyName("precio")] public decimal Precio { get; set; }
    [JsonPropertyName("cantidad")] public int Cantidad { get; set; }
}