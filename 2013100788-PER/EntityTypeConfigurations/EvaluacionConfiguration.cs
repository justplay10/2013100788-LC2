using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {
            ToTable("Evaluacions")
            .HasKey(e => e.EvalId);
            Property(e => e.EvalId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.desc)
                .IsRequired()
                .HasMaxLength(255);
           
            HasRequired(e => e.Trabajador);
            HasRequired(e => e.CentroAtencion);
            HasRequired(e => e.EquipoCelular);
            HasRequired(e => e.EstadoEvaluacion);
            HasRequired(c => c.Cliente);
            HasRequired(e => e.LineaTelefonica);            
        }
    }
}