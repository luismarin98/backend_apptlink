using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apptlink.Domain.Models;

public class BaseModel
{
    [Column("fecha_creacion")] public DateTime FechaCreacion { get; set; }
    [Column("fecha_actualizacion")] public DateTime FechaActualizacion { get; set; }
}
