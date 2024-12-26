using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("Usuarios")]
public class UsuarioModel : BaseModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("nombre", TypeName = "varchar(500)")] public string? Nombre { get; set; }
    [Column("apellido", TypeName = "varchar(500)")] public string? Apellido { get; set; }
    [Column("email", TypeName = "varchar(500)")] public string? Email { get; set; }
    [Column("password", TypeName = "varchar(500)")] public string? Password { get; set; }
    [Column("admin", TypeName = "bit")] public bool Admin { get; set; }
    [Column("estado", TypeName = "bit")] public bool Estado { get; set; }
    [Column("intentos_logueo", TypeName = "int")] public int IntentosLogueo { get; set; }
    [Column("verification_code", TypeName = "int")] public string? VerificationCode { get; set; }
    [Column("verification_date", TypeName = "int")] public DateTime? VerificationDate { get; set; }
}