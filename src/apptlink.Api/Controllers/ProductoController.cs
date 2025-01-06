using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Responses;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
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

        [HttpGet("filtrar_categoria/{id}")]
        public async Task<ActionResult> GetReporte(int id)
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                List<ProductoType>? type = await _contract.GetFilteredProducts(id);
                if (type is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                List<ReporteProductoResponses> res = type.Select(x => new ReporteProductoResponses
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Cantidad = x.Stock
                }).ToList();
                return StatusCode(StatusCodes.Status200OK, res);
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

        [HttpGet("reporte")]
        public async Task<ActionResult> GetReporte()
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                List<ProductoType>? type = await _contract.GetProductos();
                if (type is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                List<ReporteProductoResponses> res = type.Select(x => new ReporteProductoResponses
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Cantidad = x.Stock
                }).ToList();
                return StatusCode(StatusCodes.Status200OK, res);
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

        [HttpGet("valor_total_promedio")]
        public async Task<ActionResult> GetValorTotal()
        {
            try
            {
                _logger.LogInformation("Inicia producto controller - Metodo - Get");
                List<ProductoType>? type = await _contract.GetProductos();
                ProductoResponses res = new ProductoResponses();
                res.valorTotal = type.Sum(x => x.Precio);
                res.valorPromedioPrecios = type.Average(x => x.Precio);
                if (type is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, res);
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
                if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Descripcion)) return StatusCode(StatusCodes.Status400BadRequest, "Error en los datos enviados, Asegurese de no enviar campos vacios");
                if (producto.Precio <= 0) return StatusCode(StatusCodes.Status400BadRequest, "Error en los datos enviados, Asegurese de enviar un precio valido");
                if (producto.Stock <= 0) return StatusCode(StatusCodes.Status400BadRequest, "Error en los datos enviados, Asegurese de enviar un stock valido");
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
