using EntityWebSelect.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityWebSelect.Infrastructure
{
    public class ClienteService : IClienteRepository
    {
        private readonly MyDbContext _context;

        public ClienteService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ClienteModel?> ClienteComPedidosItensAsync(int idCliente)
        {
            return await _context.Clientes
                .Where(cliente => cliente.IdCliente == idCliente)
                .Include(cliente => cliente.Pedidos)
                    .ThenInclude(pedidos => pedidos.ItensPedido)
                .FirstOrDefaultAsync();
        }
    }
}