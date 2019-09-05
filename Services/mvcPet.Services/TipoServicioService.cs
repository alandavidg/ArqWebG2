using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts;
using mvcPet.Services;

namespace mvcPet.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TipoServicioService : ITipoServicioService
    {
        public TipoServicio Agregar(TipoServicio tiposervicio)
        {
            var bc = new TipoServicioComponent();
            return bc.Agregar(tiposervicio);
        }

        public List<TipoServicio> ListarTodos()
        {
            var bc = new TipoServicioComponent();
            return bc.ListarTodos();
        }

        public void Editar(TipoServicio tiposervicio)
        {
            var bc = new TipoServicioComponent();
            bc.Editar(tiposervicio);
        }
    }
}
