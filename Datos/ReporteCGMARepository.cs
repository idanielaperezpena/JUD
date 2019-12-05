using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ReporteCGMARepository : RepositoryBase<ReporteCGMA>
    {
        public ReporteCGMARepository(DatabaseContext context) : base(context)
        {
        }

        public override ReporteCGMA Alta(ReporteCGMA pGeneric)
        {
            throw new NotImplementedException();
        }

        public override void Baja(ReporteCGMA pGeneric)
        {
            throw new NotImplementedException();
        }

        public override ReporteCGMA ObtenerEntidad(ReporteCGMA pGeneric)
        {
            throw new NotImplementedException();
        }

        public override List<ReporteCGMA> ObtenerListado(ReporteCGMA pGeneric)
        {
            return ObtenerLista("a");
        }
    }
}
