using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            ToTable("Direccions")
            .HasKey(d => d.DirId);
            //Property(d => d.DirId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(d => d.desc)
                .IsRequired()
                .HasMaxLength(255);
            HasRequired(d => d.CentroAtencions);
        }
    }
}