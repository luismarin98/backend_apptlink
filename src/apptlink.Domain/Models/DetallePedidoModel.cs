using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("DetallesPedido")]
public class DetallePedidoModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("pedido_id", TypeName = "int")] public int PedidoId { get; set; }
    [Column("producto_id", TypeName = "int")] public int ProductoId { get; set; }
    [Column("cantidad", TypeName = "int")] public int Cantidad { get; set; }
    [Column("precio_unitario", TypeName = "decimal")] public decimal PrecioUnitario { get; set; }
    [Column("descuento", TypeName = "decimal")] public decimal Descuento { get; set; }
    [Column("impuesto", TypeName = "decimal")] public decimal Impuesto { get; set; }
}
