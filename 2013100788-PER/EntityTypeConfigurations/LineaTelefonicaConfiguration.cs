

using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
   public class LineaTelefonicaConfiguration : EntityTypeConfiguration<LineaTelefonica>

    {
        public LineaTelefonicaConfiguration()
        {
            ToTable("LineaTelefonicas")
           .HasKey(l => l.LinTelfId);
            //Property(l => l.LinTelfId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(l => l.desc)
                .IsRequired()
                .HasMaxLength(255);
            HasMany(l => l.AdministradorLineas)
                .WithRequired(t => t.LineaTelefonica)
                .HasForeignKey(t => t.LinTelfId);
            HasRequired(l => l.Evaluacions);
            HasMany(l => l.Ventas);
        }
    }
}
