using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAdministradorEquipoRepository AdministradorEquipos { get; }
        IAdministradorLineaRepository AdministradorLineas { get; }
        ICentroAtencionRepository CentroAtencion { get; }
        IClienteRepository Clientes { get; }
        IContratoRepository Contratos { get; }
        IDireccionRepository Direccions { get; }
        IEquipoCelularRepository EquipoCelulars { get; }
        IEstadoEvaluacionRepository EstadoEvaluacions { get; }
        IEvaluacionRepository Evaluacions { get; }
        ILineaTelefonicaRepository LineaTelefonicas { get; }
        ITrabajadorRepository Trabajadors { get; }
        IUbigeoRepository Ubigeos { get; }
        IVentaRepository Ventas { get; }
        int SaveChanges();

        void StateModified(object entity);
    }
}
