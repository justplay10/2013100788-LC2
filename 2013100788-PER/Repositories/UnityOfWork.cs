using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2013100788_ENT.IRepositories;

namespace _2013100788_PER.Repositories
{
    public class UnityOfWork : IUnityOfWork

    {
        private readonly LineasNuevasContext _Context;

        public IAdministradorEquipoRepository AdministradorEquipos { get; private set; }

        public IAdministradorLineaRepository AdministradorLineas { get; private set; }

        public ICentroAtencionRepository CentroAtencions { get; private set; }

        public IClienteRepository Clientes { get; private set; }
        public IContratoRepository Contratos { get; private set; }

        public IDireccionRepository Direccions { get; private set; }

        public IEquipoCelularRepository EquipoCelulars { get; private set; }

        public IEstadoEvaluacionRepository EstadoEvaluacions { get; private set; }

        public IEvaluacionRepository Evaluacions { get; private set; }

        public ILineaTelefonicaRepository LineaTelefonicas { get; private set; }

        public ITrabajadorRepository Trabajadors { get; private set; }

        public IUbigeoRepository Ubigeos { get; private set; }

        public IVentaRepository Ventas { get; private set; }

        public UnityOfWork()
        {

        }
        public UnityOfWork(LineasNuevasContext context)
        {
            _Context = context;

            AdministradorEquipos = new AdministradorEquipoRepository(_Context);
            AdministradorLineas = new AdministradorLineaRepository(_Context);
            CentroAtencions = new CentroAtencionRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Contratos = new ContratoRepository(_Context);
            Direccions = new DireccionRepository(_Context);
            EquipoCelulars = new EquipoCelularRepository(_Context);
            EstadoEvaluacions = new EstadoEvaluacionRepository(_Context);
            Evaluacions = new EvaluacionRepository(_Context);
            LineaTelefonicas = new LineaTelefonicaRepository(_Context);
            Trabajadors = new TrabajadorRepository(_Context);
            Ubigeos = new UbigeoRepository(_Context);
            Ventas = new VentaRepository(_Context);
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
