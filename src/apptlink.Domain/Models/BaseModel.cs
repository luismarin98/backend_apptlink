using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

public class BaseModel
{
    [Column("fecha_creacion", TypeName = "datetime")] public DateTime FechaCreacion { get; set; }
    [Column("fecha_actualizacion", TypeName = "datetime")] public DateTime FechaActualizacion { get; set; }
}
