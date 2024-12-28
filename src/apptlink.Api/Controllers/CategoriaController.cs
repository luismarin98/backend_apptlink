using apptlink.Application.Contract;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaContract _contract;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaContract contract, ILogger<CategoriaController> logger)
        {
            _contract = contract;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("CategoriaController - Get - Start");
                var result = await _contract.GetCategorias();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CategoriaController - Get");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("CategoriaController - Get - Finally");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation("CategoriaController - Get - Start");
                var result = await _contract.GetCategoriaID(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CategoriaController - Get");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("CategoriaController - Get - Finally");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaType categoria)
        {
            try
            {
                _logger.LogInformation("CategoriaController - Post - Start");
                var result = await _contract.PostCategoria(categoria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CategoriaController - Post");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("CategoriaController - Post - Finally");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoriaType categoria)
        {
            try
            {
                _logger.LogInformation("CategoriaController - Put - Start");
                var result = await _contract.PutCategoria(categoria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CategoriaController - Put");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("CategoriaController - Put - Finally");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("CategoriaController - Delete - Start");
                var result = await _contract.DeleteCategoria(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CategoriaController - Delete");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("CategoriaController - Delete - Finally");
            }
        }
    }
}
