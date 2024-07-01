using Microsoft.EntityFrameworkCore;

namespace M2.Cadastro.API
{
    internal class Contexto : DbContext
    {
        private string connectionString = "Data Source=DELL_DOUG;Initial Catalog=EstudyDB;User ID=sa;Password=sa1234;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet<Pessoa> Pessoas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString);
        }
    }
}
