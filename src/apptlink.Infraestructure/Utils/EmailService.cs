using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace apptlink.Infraestructure.Utils;

public class EmailService
{
    public void SendEmail(string to, string subject, string body, IConfiguration _configuration)
    {
        // Configuracion del cliente SMTP
        var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
        {
            Port = int.Parse(_configuration["Smtp:Port"]!),
            Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
            EnableSsl = true,
        };

        // Crear mensaje
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration["Smtp:From"]!),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
        };

        // Agregar destinatario
        mailMessage.To.Add(to);
        // Enviar correo
        smtpClient.Send(mailMessage);
    }
}
