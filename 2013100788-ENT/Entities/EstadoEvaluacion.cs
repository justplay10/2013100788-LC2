using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class EstadoEvaluacion
    {
        public int EstEvaId { get; set; }
        public string desc { get; set; }
        public ICollection<Evaluacion> Evaluacions { get; set; }
    }
}
