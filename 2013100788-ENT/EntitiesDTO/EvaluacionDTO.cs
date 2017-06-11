using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2013100788_ENT.Entities;

namespace _2013100788_ENT.EntitiesDTO
{
    public class EvaluacionDTO
    {
        public int EvalId { get; set; }
        public string desc { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }
        public TipoPlan TipoPlan { get; set; }
        public Plan Plan { get; set; }
    }
}
