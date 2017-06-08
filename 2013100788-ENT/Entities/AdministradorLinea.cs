using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class AdministradorLinea
    {
        public int AdmiLinId { get; set; }
        public string desc { get; set; }
        public LineaTelefonica LineaTelefonica { get; set; }
        public int LinTelfId { get; set; }
    }
}
