using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class EquipoCelular
    {
        public int EquipCelId { get; set; }
        public string descrip { get; set; }

        public ICollection<AdministradorEquipo> AdministradorEquipos { get; set; }
        public ICollection<Evaluacion> Evaluacions { get; set; }

        public EquipoCelular()
        {
            AdministradorEquipos = new Collection<AdministradorEquipo>();
        }
    }
}
