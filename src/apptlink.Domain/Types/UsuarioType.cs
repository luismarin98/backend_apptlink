using System;
using System.Text.Json.Serialization;

namespace apptlink.Domain.Types;

public class UsuarioType : BaseType
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("nombre")] public string? Nombre { get; set; }
    [JsonPropertyName("apellido")] public string? Apellido { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("password")] public string? Password { get; set; }
    [JsonPropertyName("admin")] public bool Admin { get; set; }
    [JsonPropertyName("estado")] public bool Estado { get; set; }
}


public class AuthUsuarioType
{
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("password")] public string? Password { get; set; }
}