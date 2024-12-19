using System;
using apptlink.Domain.Types;

namespace apptlink.Application.Contract;

public interface IUsuarioContract
{
    public Task<UsuarioType> AuthSinc(Auth auth);
    public Task<UsuarioType> GetUsuarioID(Guid id);
    public Task<List<UsuarioType>> GetUsuarios();
    public Task<UsuarioType> PostUsuario(UsuarioType usuario);
    public Task<UsuarioType> PutUsuario(UsuarioType usuario);
    public Task<UsuarioType> DeleteUsuario(Guid id);
}

public class Auth
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}