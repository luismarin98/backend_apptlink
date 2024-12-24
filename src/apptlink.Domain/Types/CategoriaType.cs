using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Types;

public class CategoriaType : BaseType
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("nombre")] public string? Nombre { get; set; }
    [JsonPropertyName("descripcion")] public string? Descripcion { get; set; }
}
