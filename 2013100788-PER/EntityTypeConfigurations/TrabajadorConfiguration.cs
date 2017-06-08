using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class TrabajadorConfiguration : EntityTypeConfiguration<Trabajador>
    {
        public TrabajadorConfiguration()
        {
            ToTable("Trabajadors")
            .HasKey(t => t.TrabaId);
            //Property(t => t.TrabaId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.desc)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
