using System;
using apptlink.Domain.Types;

namespace apptlink.Application.Contract;

public interface IPedidosContract
{
    public Task<PedidoType> GetPedidosID(int id);
    public Task<List<PedidoType>> GetPedidos();
    public Task<bool> PostPedidos(PedidoType pedidos);
    public Task<bool> PutPedidos(PedidoType pedidos);
    public Task<bool> DeletePedidos(int id);
}
