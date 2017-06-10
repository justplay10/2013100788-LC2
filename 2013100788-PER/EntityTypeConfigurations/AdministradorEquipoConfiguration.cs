using System.Data.Entity.ModelConfiguration;
using _2013100788_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class AdministradorEquipoConfiguration : EntityTypeConfiguration<AdministradorEquipo>
    {
        public AdministradorEquipoConfiguration()
        {
            ToTable("AdministradorEquipos")
            .HasKey(a => a.AdmiEquipId);
            Property(a => a.AdmiEquipId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.desc)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
