using _2013100788_ENT.Entities;
using _2013100788_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_PER.Repositories
{
    public class EvaluacionRepository : Repository<Evaluacion>, IEvaluacionRepository
    {
        public EvaluacionRepository(LineasNuevasContext context) : base(context)
        {

        }
    }
}
