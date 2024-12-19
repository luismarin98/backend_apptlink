using System;
using apptlink.Domain.Types;

namespace apptlink.Application.Contract;

public interface IDetallePedidoContract
{
    public Task<DetallePedidoType> GetDetallePedidoID(int id);
    public Task<List<DetallePedidoType>> GetDetallesPedidos();
    public Task<bool> PostDetallesPedidos(DetallePedidoType categoria);
    public Task<bool> PutDetallesPedidos(DetallePedidoType categoria);
    public Task<bool> DeleteDetallesPedidos(int id);
}
