using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioContract _contract;
        private readonly ILogger<UsuarioController> _logger;
        private readonly JWTGenerate _token;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioContract contract, IConfiguration configuration, ILogger<UsuarioController> logger, JWTGenerate token)
        {
            _configuration = configuration;
            _contract = contract;
            _logger = logger;
            _token = token;
        }

        [HttpPut("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] AuthUsuarioType auth)
        {
            try
            {
                _logger.LogInformation("Inicializa usuario controller - Metodo - ChangePassword");
                if (auth is null) return StatusCode(StatusCodes.Status400BadRequest, "Usuario no puede ser nulo");
                if (string.IsNullOrEmpty(auth.Email) || string.IsNullOrEmpty(auth.Password)) return StatusCode(StatusCodes.Status400BadRequest, "Usuario o contraseña no pueden ser nulos");
                bool res = await _contract.ChangePassword(auth);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado");
                return StatusCode(StatusCodes.Status200OK, "Contraseña actualizada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo post - usuario controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza usuario controller - Metodo - ChangePassword");
            }
        }

        [HttpGet("{email}/{code}")]
        public async Task<ActionResult> GetSearchVerificationCode(string email, int code)
        {
            try
            {
                _logger.LogInformation("Inicia usuario controller - Metodo - GetSearchVerificationCode");
                bool res = await _contract.GetSearchVerificationCode(email, code);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Código de verificación incorrecto");
                return StatusCode(StatusCodes.Status200OK, "Código de verificación correcto");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo get - usuario controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza usuario controller - Metodo - GetSearchVerificationCode");
            }
        }

        [HttpGet("recover")]
        public async Task<ActionResult> GetRecoverAccount(string email)
        {
            try
            {
                _logger.LogInformation("Inicia usuario controller - Metodo - GetRecoverAccount");
                string res = await _contract.PostRecover(email, _configuration);
                if (res is null) return StatusCode(StatusCodes.Status404NotFound, "email no encontrado");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo get - usuario controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza usuario controller - Metodo - GetRecoverAccount");
            }
        }

        [HttpPost("auth")]
        public async Task<ActionResult> AuthUsuario([FromBody] AuthUsuarioType usuario)
        {
            try
            {
                _logger.LogInformation("Inicia usuario controller - Metodo - Post");
                if (usuario is null) return StatusCode(StatusCodes.Status400BadRequest, "Usuario no puede ser nulo");
                if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Password)) return StatusCode(StatusCodes.Status400BadRequest, "Usuario o contraseña no pueden ser nulos");
                UsuarioType res = await _contract.AuthUsuario(usuario);
                if (res is null) return StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado");
                string token = _token.Execute(res, _configuration);
                return StatusCode(StatusCodes.Status200OK, token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo post - usuario controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza usuario controller - Metodo - Post");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> PostUsuario([FromBody] UsuarioType usuario)
        {
            try
            {
                _logger.LogInformation("Inicia usuario controller - Metodo - Post");
                bool res = await _contract.PostUsuario(usuario);
                if (res is false) return StatusCode(StatusCodes.Status409Conflict, "Usuario ya existe");
                return StatusCode(StatusCodes.Status201Created, "Usuario creado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo post - usuario controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza usuario controller - Metodo - Post");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> PutUsuario([FromBody] UsuarioType usuario)
        {
            try
            {
                _logger.LogInformation("Inicia usuario controller - Metodo - Put");
                bool res = await _contract.PutUsuario(usuario);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado");
                return StatusCode(StatusCodes.Status200OK, "Usuario actualizado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo put - usuario controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza usuario controller - Metodo - Put");
            }
        }
    }
}