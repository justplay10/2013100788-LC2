using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    class Venta
    {
        public int VentaId { get; set; }
        public string desc { get; set; }
        public int LinTelfId { get; set; }
        public LineaTelefonica LineaTelefonica { get; set; }
        public int EvalId { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public TipoPago TipoPago { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public int CenAteId { get; set; }
        public CentroAtencion CentroAtencion { get; set; }
    }
}
