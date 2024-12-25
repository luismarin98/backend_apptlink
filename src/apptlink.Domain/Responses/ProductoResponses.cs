using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Responses;

public class ProductoResponses
{
    [JsonPropertyName("valor_total")] public decimal valorTotal { get; set; }
    [JsonPropertyName("valor_promedio_precios")] public decimal valorPromedioPrecios { get; set; }
}
