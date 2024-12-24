using apptlink.Application.Contract;
using apptlink.Domain.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace apptlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoContract _contract;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(IProductoContract contract, ILogger<ProductoController> logger)
        {
            _contract = contract;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductoID(int id)
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                ProductoType? type = await _contract.GetProductoID(id);
                if (type is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo get - producto controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza producto controller - Metodo - Get");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetProductos()
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                List<ProductoType>? type = await _contract.GetProductos();
                if (type.Count is 0) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo get - producto controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza producto controller - Metodo - Get");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostProducto([FromBody] ProductoType producto)
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                bool res = await _contract.PostProducto(producto);
                if (res) return StatusCode(StatusCodes.Status201Created, "Producto creado con exito");
                return StatusCode(StatusCodes.Status400BadRequest, "Error al crear producto");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo get - producto controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza producto controller - Metodo - Get");
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutProducto([FromBody] ProductoType producto)
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                bool res = await _contract.PutProducto(producto);
                if (res) return StatusCode(StatusCodes.Status201Created, "Producto actualizado con exito");
                return StatusCode(StatusCodes.Status400BadRequest, "Error al crear producto");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo get - producto controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza producto controller - Metodo - Get");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                bool res = await _contract.DeleteProducto(id);
                if (res) return StatusCode(StatusCodes.Status201Created, "Producto eliminado con exito");
                return StatusCode(StatusCodes.Status400BadRequest, "Error al crear producto");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo get - producto controller");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Finaliza producto controller - Metodo - Get");
            }
        }
    }
}
