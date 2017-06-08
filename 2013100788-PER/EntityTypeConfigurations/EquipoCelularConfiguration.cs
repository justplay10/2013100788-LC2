using _2013100788_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class EquipoCelularConfiguration : EntityTypeConfiguration<EquipoCelular>
    {
        public EquipoCelularConfiguration()
        {
            ToTable("EquipoCelulars");
            HasKey(e => e.EquipCelId);
            Property(e => e.EquipCelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.descrip)
                .IsRequired()
                .HasMaxLength(255);
            HasMany(e => e.AdministradorEquipos)
                .WithRequired(t => t.EquipoCelular)
                .HasForeignKey(t => t.EquipCelId);
            HasRequired(e => e.Evaluacions);
        }
    }
}
