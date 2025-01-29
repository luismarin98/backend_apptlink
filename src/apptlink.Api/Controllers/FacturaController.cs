using apptlink.Application.Contract;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Pdf;
using System.IO;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaContract _contract;
        private readonly ILogger<FacturaController> _logger;

        public FacturaController(IFacturaContract contract, ILogger<FacturaController> logger)
        {
            _contract = contract;
            _logger = logger;
        }

        [HttpGet("GenerarFactura/{pedido_id}")]
        public async Task<IActionResult> GenerarFactura(int pedido_id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo - Get - GenerarFactura");
                PdfDocument factura = await _contract.GenerarFactura(pedido_id);
                if (factura == null) return StatusCode(StatusCodes.Status404NotFound, "Pedido no encontrado");

                using (MemoryStream stream = new MemoryStream())
                {
                    factura.Save(stream, false);
                    return File(stream.ToArray(), "application/pdf", "Factura.pdf");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en metodo - Get - GenerarFactura");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al generar factura");
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo - Get - GenerarFactura");
            }
        }
    }
}
