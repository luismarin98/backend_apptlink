using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("Categorias")]
public class CategoriaModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("nombre", TypeName = "varchar")] public string? Nombre { get; set; }
    [Column("descripcion", TypeName = "text")] public string? Descripcion { get; set; }
}
