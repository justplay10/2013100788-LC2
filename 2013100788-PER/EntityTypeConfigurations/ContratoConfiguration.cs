using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class ContratoConfiguration : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfiguration()
        {
            ToTable("Contratos")
            .HasKey(c => c.ContratoId);
            Property(c => c.ContratoId)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.desc)
                .IsRequired()
                .HasMaxLength(255);

        } 
    }
}
