
using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class EstadoEvaluacionConfiguration : EntityTypeConfiguration<EstadoEvaluacion>
    {
        public EstadoEvaluacionConfiguration()
        {
            ToTable("EstadoEvaluacions")
            .HasKey(e => e.EstEvaId);
            Property(e => e.EstEvaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.desc)
                .IsRequired()
                .HasMaxLength(255);
            HasRequired(e => e.Evaluacions);
        }
    }
}
