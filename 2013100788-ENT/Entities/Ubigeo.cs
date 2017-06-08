using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class Ubigeo
    {
        public int UbigeoId { get; set; }
        public string desc { get; set; }
        public Departamento Departamento { get; set; }
        public Provincia Provincia { get; set; }
        public Distrito Distrito { get; set; }
        public ICollection<Direccion> Direccions { get; set; }
        public Ubigeo()
        {
            Direccions = new Collection<Direccion>();
        }
    }
}
