using _2013100788_ENT.IRepositories;
using _2013100788_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2013100788_ENT.Entities;
using System.Linq.Expressions;

namespace _2013100788_PER.Repositories
{
    public class AdministradorEquipoRepository : Repository<AdministradorEquipo>, IAdministradorEquipoRepository
    {
        public AdministradorEquipoRepository(LineasNuevasContext context) : base(context)
        {

        }
    }
}
