using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services.Contracts
{
    [ServiceContract]
    public interface ITipoServicioService
    {
        [OperationContract]
        TipoServicio Agregar(TipoServicio tiposervicio);

        [OperationContract]
        List<TipoServicio> ListarTodos();

        [OperationContract]
        void Editar(TipoServicio tiposervicio);
    }
}
