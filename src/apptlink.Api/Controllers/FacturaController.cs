using apptlink.Application.Contract;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> _logger;
        private readonly IUsuarioContract _usuarioContract;
        private readonly IPedidosContract _pedidosContract;
        private readonly IProductoContract _productoContract;
        private readonly IDetallePedidoContract _detallePedidoContract;

        public FacturaController(IUsuarioContract usuarioContract, ILogger<FacturaController> logger, IPedidosContract pedidosContract, IProductoContract productoContract, IDetallePedidoContract detallePedidoContract)
        {
            _logger = logger;
            _usuarioContract = usuarioContract;
            _pedidosContract = pedidosContract;
            _productoContract = productoContract;
            _detallePedidoContract = detallePedidoContract;
        }

        [HttpGet]
        public async Task<ActionResult> GenerarFactura()
        {
            try
            {
                _logger.LogInformation("Inicia metodo GenerarFactura");
                /* var pedidos = await _pedidosContract.GetAll();
                var productos = await _productoContract.GetAll();
                var detallePedidos = await _detallePedidoContract.GetAll();
                var usuarios = await _usuarioContract.GetAll();

                var facturas = new List<Factura>();

                foreach (var pedido in pedidos)
                {
                    var factura = new Factura();
                    factura.Pedido = pedido;
                    factura.Usuario = usuarios.FirstOrDefault(x => x.Id == pedido.UsuarioId);
                    factura.DetallePedidos = detallePedidos.Where(x => x.PedidoId == pedido.Id).ToList();
                    foreach (var detalle in factura.DetallePedidos)
                    {
                        detalle.Producto = productos.FirstOrDefault(x => x.Id == detalle.ProductoId);
                    }
                    facturas.Add(factura);
                }*/

                return Ok(/* facturas */); 
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
