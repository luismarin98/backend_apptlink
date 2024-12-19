using System;
using apptlink.Domain.Models;
using apptlink.Domain.Types;

namespace apptlink.Domain.Parsing;

public static class UsuarioParsing
{
    public static UsuarioType ModelToType(UsuarioModel model)
    {
        UsuarioType type = new UsuarioType
        {
            Admin = model.Admin,
            Apellido = model.Apellido,
            Email = model.Email,
            Estado = model.Estado,
            FechaActualizacion = DateTime.Now,
            FechaCreacion = model.FechaCreacion,
            Id = model.Id,
            Nombre = model.Nombre,
            Password = model.Password
        };

        return type;
    }

    public static UsuarioModel ModelToType(UsuarioType type)
    {
        UsuarioModel model = new UsuarioModel
        {
            Admin = type.Admin,
            Apellido = type.Apellido,
            Email = type.Email,
            Estado = type.Estado,
            FechaActualizacion = DateTime.Now,
            FechaCreacion = type.FechaCreacion,
            Id = type.Id,
            Nombre = type.Nombre,
            Password = type.Password
        };

        return model;
    }

    public static List<UsuarioModel> ModelToType(List<UsuarioType> type) => type.Select(ModelToType).ToList();
    public static List<UsuarioType> ModelToType(List<UsuarioModel> model) => model.Select(ModelToType).ToList();
}
