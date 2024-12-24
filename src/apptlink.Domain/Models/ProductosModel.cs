using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("Productos")]
public class ProductosModel : BaseModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("nombre", TypeName = "varchar(500)")] public string? Nombre { get; set; }
    [Column("descripcion", TypeName = "text")] public string? Descripcion { get; set; }
    [Column("precio", TypeName = "decimal(18,0)")] public decimal Precio { get; set; }
    [Column("stock", TypeName = "int")] public int Stock { get; set; }
    [Column("categoria_id", TypeName = "int")] public int CategoriaId { get; set; }
}
