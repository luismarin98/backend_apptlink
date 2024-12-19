using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Types;

public class ProductoType : BaseType
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("nombre")] public string? Nombre { get; set; }
    [JsonPropertyName("descripcion")] public string? Descripcion { get; set; }
    [JsonPropertyName("precio")] public decimal Precio { get; set; }
    [JsonPropertyName("stock")] public int Stock { get; set; }
    [JsonPropertyName("categoria_id")] public int CategoriaId { get; set; }
}
