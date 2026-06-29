using EntityWebSelect.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityWebSelect.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; } = null!;
        public DbSet<PedidoModel> Pedidos { get; set; } = null!;
        public DbSet<ItemPedidoModel> ItensPedido { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Regra do CPF único
            modelBuilder.Entity<ClienteModel>()
                .HasIndex(cliente => cliente.Cpf)
                .IsUnique();

            // Deleção em cascata
            modelBuilder.Entity<PedidoModel>()
                .HasMany(pedidos => pedidos.ItensPedido)
                .WithOne(itens => itens.Pedido)
                .HasForeignKey(i => i.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ClienteModel>().HasData(
                new ClienteModel
                {
                    IdCliente = 1,
                    Cpf = "123.456.789-00",
                    Nome = "Luiz",
                    DtNasc = new DateTime(2000, 01, 01)
                }
            );

            modelBuilder.Entity<PedidoModel>().HasData(
                new PedidoModel
                {
                    IdPedido = 10,
                    IdCliente = 1,
                    DtVenda = new DateTime(2026, 06, 29, 10, 0, 0),
                    ValorTot = 150.50m
                }
            );

            // 3. Cria Itens para o Pedido 10
            modelBuilder.Entity<ItemPedidoModel>().HasData(
                new ItemPedidoModel
                {
                    IdItens = 100,
                    IdPedido = 10,
                    DescIten = "Teclado Mecânico",
                    QtdeEstoque = 1,
                    ValorUni = 100.00m
                },
                new ItemPedidoModel
                {
                    IdItens = 101,
                    IdPedido = 10,
                    DescIten = "Mouse Pad Gamer",
                    QtdeEstoque = 1,
                    ValorUni = 50.00m
                }
            );
        }
    }
}