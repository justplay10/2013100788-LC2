using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class Direccion
    {
        public int DirId { get; set; }
        public string desc { get; set; }
        public int UbigeoId { get; set; }
        public Ubigeo Ubigeo { get; set; }
        public ICollection<CentroAtencion> CentroAtencions { get; set; }
        public Direccion()
        {
            CentroAtencions = new Collection<CentroAtencion>();
        }
    }
}
