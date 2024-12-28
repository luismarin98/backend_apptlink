using apptlink.Application.Contract;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoContract _contract;
        private readonly ILogger<DetallePedidoController> _logger;

        public DetallePedidoController(IDetallePedidoContract contract, ILogger<DetallePedidoController> logger)
        {
            _contract = contract;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetDetallePedidos()
        {
            try
            {
                _logger.LogInformation("DetallePedidoController - GetDetallePedidos - Start");
                List<DetallePedidoType> list = await _contract.GetDetallesPedidos();
                if (list.Count is 0) return StatusCode(StatusCodes.Status404NotFound, "No se encontraron registros");
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetDetallePedidos");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("DetallePedidoController - GetDetallePedidos - Finally");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetallePedidoID(int id)
        {
            try
            {
                _logger.LogInformation("DetallePedidoController - GetDetallePedidoID - Start");
                DetallePedidoType detallePedido = await _contract.GetDetallePedidoID(id);
                if (detallePedido is null) return StatusCode(StatusCodes.Status404NotFound, "No se encontraron registros");
                return Ok(detallePedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetDetallePedidoID");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("DetallePedidoController - GetDetallePedidoID - Finally");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostDetallePedido(DetallePedidoType detallePedido)
        {
            try
            {
                _logger.LogInformation("DetallePedidoController - PostDetallePedido - Start");
                bool newDetallePedido = await _contract.PostDetallesPedidos(detallePedido);
                return StatusCode(StatusCodes.Status400BadRequest, "No se pudo completar la transacción");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en PostDetallePedido");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("DetallePedidoController - PostDetallePedido - Finally");
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutDetallePedido(DetallePedidoType detallePedido)
        {
            try
            {
                _logger.LogInformation("DetallePedidoController - PutDetallePedido - Start");
                bool updateDetallePedido = await _contract.PutDetallesPedidos(detallePedido);
                if (updateDetallePedido is false) return BadRequest("No se pudo completar la transacción");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en PutDetallePedido");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("DetallePedidoController - PutDetallePedido - Finally");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDetallePedido(int id)
        {
            try
            {
                _logger.LogInformation("DetallePedidoController - DeleteDetallePedido - Start");
                bool deleteDetallePedido = await _contract.DeleteDetallesPedidos(id);
                if (deleteDetallePedido is false) return BadRequest("No se pudo completar la transacción");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en DeleteDetallePedido");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("DetallePedidoController - DeleteDetallePedido - Finally");
            }
        }
    }
}
