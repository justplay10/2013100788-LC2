using System.Data.Entity.ModelConfiguration;
using _2013100788_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_PER.EntityTypeConfigurations
{
    public class AdministradorEquipoConfiguration : EntityTypeConfiguration<AdministradorEquipo>
    {
        public AdministradorEquipoConfiguration()
        {
            ToTable("AdministradorEquipos")
            .HasKey(a => a.AdmiEquipId);

            Property(a => a.desc)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
