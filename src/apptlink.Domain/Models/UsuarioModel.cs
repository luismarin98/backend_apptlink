using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("Usuarios")]
public class UsuarioModel : BaseModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("nombre")] public string? Nombre { get; set; }
    [Column("apellido")] public string? Apellido { get; set; }
    [Column("email")] public string? Email { get; set; }
    [Column("password")] public string? Password { get; set; }
    [Column("admin")] public bool Admin { get; set; }
    [Column("estado")] public bool Estado { get; set; }
    [Column("verification_code")] public string? VerificationCode { get; set; }
    [Column("verification_date")] public DateTime? VerificationDate { get; set; }
}