using System;
using apptlink.Domain.Types;
using Microsoft.Extensions.Configuration;

namespace apptlink.Application.Contract;

public interface IUsuarioContract
{
    public Task<UsuarioType> GetUsuarioID(int id);
    public Task<bool> ChangePassword(RecoverPasswordType auth);
    public Task<bool> GetSearchVerificationCode(string email, int code);
    public Task<string> PostRecover(string email, IConfiguration _configuration);
    public Task<UsuarioType> AuthUsuario(AuthUsuarioType usuario);
    public Task<bool> PostUsuario(UsuarioType usuario);
    public Task<bool> PutUsuario(UsuarioType usuario);
}