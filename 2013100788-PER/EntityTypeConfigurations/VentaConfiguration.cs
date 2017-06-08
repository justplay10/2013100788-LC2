using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {
        public VentaConfiguration()
        {
            ToTable("Ventas");
            HasKey(v => v.VentaId);
            Property(v => v.VentaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.desc)
                .IsRequired()
                .HasMaxLength(255);
            HasRequired(v => v.CentroAtencion);
        }
    }
}
