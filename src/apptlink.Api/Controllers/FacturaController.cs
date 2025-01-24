using apptlink.Application.Contract;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Pdf;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> _logger;
        private readonly IFacturaContract _contract;

        public FacturaController(ILogger<FacturaController> logger, IFacturaContract contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet("{id_pedido}")]
        public async Task<ActionResult> GenerarFactura(int id_pedido)
        {
            try
            {
                _logger.LogInformation("Inicia metodo GenerarFactura");
                // Generar factura
                PdfDocument pdf = await _contract.GenerarFactura(id_pedido);
                // Si no se genero la factura
                if (pdf == null) return StatusCode(StatusCodes.Status404NotFound, "Falla al generar factura");
                // Retornar PDF
                return StatusCode(StatusCodes.Status200OK, pdf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo - Get - GenerarFactura");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo GenerarFactura");
            }
        }
    }
}
