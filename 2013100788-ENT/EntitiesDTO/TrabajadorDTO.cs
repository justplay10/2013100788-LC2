using _2013100788_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.EntitiesDTO
{
    public class TrabajadorDTO
    {
        public int TrabaId { get; set; }
        public string desc { get; set; }
        public TipoTrabajador TipoTrabajador { get; set; }
    }
}
