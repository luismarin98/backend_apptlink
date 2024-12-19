using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("Productos")]
public class ProductosModel : BaseModel
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("nombre")] public string? Nombre { get; set; }
    [Column("descripcion")] public string? Descripcion { get; set; }
    [Column("precio")] public decimal Precio { get; set; }
    [Column("stock")] public int Stock { get; set; }
    [Column("categoria_id")] public int CategoriaId { get; set; }
}
