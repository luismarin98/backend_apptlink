using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

[Table("DetallesPedido")]
public class DetallePedidoModel
{
    [Key][Column("id")] public long Id { get; set; }
    [Column("pedido_id")] public int PedidoId { get; set; }
    [Column("producto_id")] public int ProductoId { get; set; }
    [Column("cantidad")] public int Cantidad { get; set; }
    [Column("precio_unitario")] public decimal PrecioUnitario { get; set; }
    [Column("descuento")] public decimal Descuento { get; set; }
    [Column("impuesto")] public decimal Impuesto { get; set; }
}
