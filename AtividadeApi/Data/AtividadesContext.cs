using AtividadeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadeApi.Data
{
    public class AtividadesContext : DbContext
    {
        public AtividadesContext(DbContextOptions<AtividadesContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build();


            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        public DbSet<Atividade> Atividades { get; set; }

    }
}
