using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class AdministradorEquipo
    {
        public int AdmiEquipId { get; set; }
        public string desc { get; set; }
        public int EquipCelId { get; set; }
        public EquipoCelular EquipoCelular { get; set; }

    }
}
