using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    class LineaTelefonica
    {
        public int LinTelfId { get; set; }
        public string desc { get; set; }
        public TipoLinea TipoLinea { get; set; }
        public ICollection<AdministradorLinea> AdministradorLineas { get; set; }
        public ICollection<Evaluacion> Evaluacions { get; set; }
        public LineaTelefonica()
        {
            AdministradorLineas = new Collection<AdministradorLinea>();
        }
        public ICollection<Venta> Ventas { get; set; }
    }
}
