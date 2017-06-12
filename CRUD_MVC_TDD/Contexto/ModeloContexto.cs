using System.Data.Entity;
using CRUD_MVC_TDD.Models;
using CRUD_MVC_TDD.EntityConfig;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRUD_MVC_TDD.Contexto
{
    public class ModeloContexto : DbContext
    {
        public ModeloContexto()
        : base("CRUD_MVC_TDD")
        {
        }

        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<CategoriaEstabelecimento> CategoriaEstabelecimento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
               .Where(p => p.Name == "Id")
               .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new EstabelecimentoConfiguracao());
        }
    }
}
