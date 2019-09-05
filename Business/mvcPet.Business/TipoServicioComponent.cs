using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mvcPet.Entities;
using mvcPet.Data;

namespace mvcPet.Business
{
    public partial class TipoServicioComponent
    {

        public TipoServicio Agregar(TipoServicio tiposervicio)
        {
            TipoServicio result = default(TipoServicio);
            var tiposervicioDAC = new TipoServicioDAC();
            result = tiposervicioDAC.Create(tiposervicio);
            return result;
        }
        public List<TipoServicio> ListarTodos()
        {
            List<TipoServicio> result = default(List<TipoServicio>);
            var tiposervicioDAC = new TipoServicioDAC();
            result = tiposervicioDAC.Read();
            return result;

        }

        public void Editar(TipoServicio tiposervicio)
        {
            var tiposervicioDAC = new TipoServicioDAC();
            tiposervicioDAC.Update(tiposervicio);
        }
    }
}
