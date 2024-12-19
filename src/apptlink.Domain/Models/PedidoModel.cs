using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

public class PedidoModel : BaseModel
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("usuario_id")] public int UsuarioId { get; set; }
    [Column("fecha_pedido")] public DateTime FechaPedido { get; set; }
    [Column("estado")] public string? Estado { get; set; }
    [Column("total")] public decimal Total { get; set; }
}
