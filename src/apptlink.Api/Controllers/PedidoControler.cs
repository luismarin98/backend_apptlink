using apptlink.Application.Contract;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apptlink.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidosContract _contract;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(IPedidosContract contract, ILogger<PedidoController> logger)
        {
            _contract = contract;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Buscando pedidos");
                List<PedidoType> result = await _contract.GetPedidos();
                if (result.Count is 0) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar pedidos");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al buscar pedidos");
            }
            finally
            {
                _logger.LogInformation("Finalizando busca de pedidos");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation("Buscando pedido");
                PedidoType result = await _contract.GetPedidosID(id);
                if (result is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar pedido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al buscar pedido");
            }
            finally
            {
                _logger.LogInformation("Finalizando busca de pedido");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoType pedido)
        {
            try
            {
                _logger.LogInformation("Inserindo pedido");
                var result = await _contract.PostPedidos(pedido);
                if (result is false) return StatusCode(StatusCodes.Status400BadRequest, "Error al inserir pedido");
                return StatusCode(StatusCodes.Status201Created, "Pedido inserido com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al inserir pedido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al inserir pedido");
            }
            finally
            {
                _logger.LogInformation("Finalizando inserção de pedido");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PedidoType pedido)
        {
            try
            {
                _logger.LogInformation("Atualizando pedido");
                var result = await _contract.PutPedidos(pedido);
                if (result is false) return StatusCode(StatusCodes.Status400BadRequest, "Error al atualizar pedido");
                return StatusCode(StatusCodes.Status200OK, "Pedido atualizado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al atualizar pedido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al atualizar pedido");
            }
            finally
            {
                _logger.LogInformation("Finalizando atualização de pedido");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deletando pedido");
                var result = await _contract.DeletePedidos(id);
                if (result is false) return StatusCode(StatusCodes.Status400BadRequest, "Error al deletar pedido");
                return StatusCode(StatusCodes.Status200OK, "Pedido deletado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al deletar pedido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al deletar pedido");
            }
            finally
            {
                _logger.LogInformation("Finalizando deleção de pedido");
            }
        }
    }
}
