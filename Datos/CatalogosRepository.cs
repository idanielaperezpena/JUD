using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CatalogosRepository : RepositoryBase<Catalogos>
    {
        public CatalogosRepository(DatabaseContext context) : base(context) { }

        public override Catalogos Alta(Catalogos pGeneric)
        {
            throw new NotImplementedException();
        }

        public override void Baja(Catalogos pGeneric)
        {
            throw new NotImplementedException();
        }

        public override Catalogos ObtenerEntidad(Catalogos pGeneric)
        {
            throw new NotImplementedException();
        }

        public override List<Catalogos> ObtenerListado(Catalogos pGeneric)
        {
            return ObtenerLista("Catalogos_Select", pGeneric.NombreCatalogo);
        }

        public  List<Catalogos> ObtenerListado_NombreTablas(Catalogos pGeneric)
        {
            return ObtenerLista("Catalogos_Select_NombreTablas", pGeneric.NombreCatalogo);
        }

    }
}
