using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class UbigeoConfiguration : EntityTypeConfiguration<Ubigeo>
    {
        public UbigeoConfiguration()
        {
            ToTable("Ubigeos")
            .HasKey(u => u.UbigeoId);
            //Property(u => u.UbigeoId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.desc)
                .IsRequired()
                .HasMaxLength(255);
            HasRequired(u => u.Direccions);
        }
    }
}
