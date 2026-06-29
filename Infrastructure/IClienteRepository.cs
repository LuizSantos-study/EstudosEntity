using EntityWebSelect.Model;

namespace EntityWebSelect.Infrastructure { 
    public interface IClienteRepository
    {
        Task<ClienteModel?> ClienteComPedidosItensAsync(int idCliente);
    }
}