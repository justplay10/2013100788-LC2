using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class CentroAtencionConfiguration : EntityTypeConfiguration<CentroAtencion>
    {
        public CentroAtencionConfiguration()
        {
            ToTable("CentroAtencions");
            HasKey(c => c.CenAteId);
            Property(c => c.CenAteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.desc)
                .IsRequired()
                .HasMaxLength(255);
            
        }
    }
}
