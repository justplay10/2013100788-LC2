using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Evaluacion> Evaluacions { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
