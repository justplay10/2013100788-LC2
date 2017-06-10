using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class Evaluacion
    {
        public int EvalId { get; set; }
        public string desc { get; set; }

        public int EquipCelId { get; set; }
        public EquipoCelular EquipoCelular { get; set; }
        public TipoPlan TipoPlan { get; set; }
        public Plan Plan { get; set; }
        public int LinTelfId { get; set; }
        public LineaTelefonica LineaTelefonica { get; set; }
        public int TrabaId { get; set; }
        public Trabajador Trabajador { get; set; }
        public int EstEvaId { get; set; }
        public EstadoEvaluacion EstadoEvaluacion { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int CenAteId { get; set; }
        public CentroAtencion CentroAtencion { get; set; }

        public ICollection<Venta> Venta { get; set; }
        public Evaluacion()
        {
            Venta = new Collection<Venta>();
        }

    }
}
