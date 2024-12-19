using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Types;

public class BaseType
{
    [JsonPropertyName("fecha_creacion")] public DateTime FechaCreacion { get; set; }
    [JsonPropertyName("fecha_actualizacion")] public DateTime FechaActualizacion { get; set; }
}
