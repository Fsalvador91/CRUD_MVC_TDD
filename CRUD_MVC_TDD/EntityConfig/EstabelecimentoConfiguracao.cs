using CRUD_MVC_TDD.Models;
using System.Data.Entity.ModelConfiguration;

namespace CRUD_MVC_TDD.EntityConfig
{
    public class EstabelecimentoConfiguracao : EntityTypeConfiguration<Estabelecimento>
    {
        public EstabelecimentoConfiguracao()
        {
            HasKey(p => p.Id);

            HasRequired(x => x.CategoriaEstabelecimento)
                   .WithMany()
                   .HasForeignKey(x => x.CategoriaId);

            ToTable("Estabelecimento");
        }
    }
}
