using System;
using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Parsing;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Context;
using apptlink.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace apptlink.Infraestructure.Repository;

public class UsuarioRepository : IUsuarioContract
{
    private readonly DB _context;
    private readonly ILogger<UsuarioRepository> _logger;
    private readonly EmailService _emailService;

    public UsuarioRepository(DB context, EmailService emailService, ILogger<UsuarioRepository> logger)
    {
        _emailService = emailService;
        _context = context;
        _logger = logger;
    }

    public async Task<string> PostRecover(string email, IConfiguration _configuration)
    {
        try
        {
            _logger.LogInformation("Inicia usuario controller - Metodo - PostRecover");
            UsuarioModel? usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == email);
            if (usuario is null) return null!;

            string verificationCode = GenerateVerificationCode();
            usuario.VerificationCode = verificationCode;
            usuario.VerificationDate = DateTime.UtcNow.AddMinutes(15);

            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();

            string styles = @"
                        body {
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 0;
                        }
                        .container {
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            background-color: #ffffff;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }
                        .header {
                            text-align: center;
                            padding: 10px 0;
                            background-color: #007bff;
                            color: #ffffff;
                        }
                        .content {
                            padding: 20px;
                        }
                        .content h1 {
                            font-size: 24px;
                            margin-bottom: 20px;
                        }
                        .content p {
                            font-size: 16px;
                            margin-bottom: 20px;
                        }
                        .content a {
                            display: inline-block;
                            padding: 10px 20px;
                            background-color: #007bff;
                            color: #ffffff;
                            text-decoration: none;
                            border-radius: 5px;
                        }
                        .footer {
                            text-align: center;
                            padding: 10px 0;
                            background-color: #f4f4f4;
                            color: #777777;
                            font-size: 14px;
                        }
        ";

            string body = $@"
            <!DOCTYPE html>
            <html lang=""es"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Recuperación de Contraseña</title>
                    <style>{styles}</style>
                </head>
                <body>
                    <p>Hola,</p>
                    <p>Recibimos una solicitud para restablecer tu contraseña. Usa el siguiente código de verificación para restablecer tu contraseña:</p>
                    <h2>{verificationCode}</h2>
                    <p>Si no solicitaste un restablecimiento de contraseña, ignora este correo electrónico.</p>
                    <p>Gracias,</p>
                    <p>El equipo de ApptLink</p>
                </body>
            </html>";

            _emailService.SendEmail(usuario.Email!, "Recuperación de Contraseña", body, _configuration);

            return "Verification code has been sent to your email.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo post - usuario controller");
            return null!;
        }
        finally
        {
            _logger.LogInformation("Finaliza usuario controller - Metodo - PostRecover");
        }
    }

    public async Task<UsuarioType> AuthUsuario(AuthUsuarioType usuario)
    {
        try
        {
            _logger.LogInformation("Inicia usuario controller - Metodo - Post");
            UsuarioModel? usuarioModel = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == usuario.Email);
            if (usuarioModel is null)
            {
                return null!;
            }
            else
            {
                if (usuarioModel.Password != usuario.Password)
                {
                    usuarioModel.IntentosLogueo++;
                }
                else if (usuarioModel.IntentosLogueo >= 5)
                {
                    usuarioModel.Estado = false;
                    _context.Usuario.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    usuarioModel.IntentosLogueo = 0;
                }
            }
            return UsuarioParsing.ModelToType(usuarioModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo post - usuario controller");
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza usuario controller - Metodo - Post");
        }
    }

    public async Task<bool> PostUsuario(UsuarioType usuario)
    {
        try
        {
            _logger.LogInformation("Inicia usuario controller - Metodo - Post");
            UsuarioModel usuarioModel = UsuarioParsing.ModelToType(usuario);
            _context.Usuario.Add(usuarioModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo post - usuario controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza usuario controller - Metodo - Post");
        }
    }

    public Task<bool> PutUsuario(UsuarioType usuario)
    {
        try
        {
            _logger.LogInformation("Inicia usuario controller - Metodo - Put");
            UsuarioModel usuarioModel = UsuarioParsing.ModelToType(usuario);
            _context.Usuario.Update(usuarioModel);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo Put - usuario controller");
            return Task.FromResult(false);
        }
        finally
        {
            _logger.LogInformation("Finaliza usuario controller - Metodo - Put");
        }
    }

    public async Task<bool> GetSearchVerificationCode(string email, string code)
    {
        try
        {
            _logger.LogInformation("Inicia usuario controller - Metodo - GetSearchVerificationCode");
            UsuarioModel? usuario = await _context.Usuario.Where(x => x.Email == email && x.VerificationCode == code).FirstOrDefaultAsync();
            if (usuario is null) return false;
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo GetSearchVerificationCode - usuario controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza usuario controller - Metodo - GetSearchVerificationCode");
        }
    }

    public async Task<bool> ChangePassword(AuthUsuarioType auth)
    {
        try
        {
            _logger.LogInformation("Inicia usuario controller - Metodo - ChangePassword");
            UsuarioModel? usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == auth.Email);
            if (usuario is null) return false;
            usuario.Password = auth.Password;
            usuario.VerificationCode = null;
            usuario.VerificationDate = null;
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en metodo ChangePassword - usuario controller");
            return false;
        }
        finally
        {
            _logger.LogInformation("Finaliza usuario controller - Metodo - ChangePassword");
        }
    }

    private string GenerateVerificationCode()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }
}