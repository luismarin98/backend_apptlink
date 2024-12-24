using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("Pedidos")]
public class PedidoModel : BaseModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("usuario_id", TypeName = "int")] public int UsuarioId { get; set; }
    [Column("fecha_pedido", TypeName = "datetime")] public DateTime FechaPedido { get; set; }
    [Column("estado", TypeName = "varchar(500)")] public string? Estado { get; set; }
    [Column("total", TypeName = "int")] public decimal Total { get; set; }
}
