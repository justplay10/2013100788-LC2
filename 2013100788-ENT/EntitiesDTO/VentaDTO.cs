using _2013100788_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.EntitiesDTO
{
    class VentaDTO
    {
        public int VentaId { get; set; }
        public string desc { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
