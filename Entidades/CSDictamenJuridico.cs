using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CSDictamenJuridico
    {
        public int? CSDJ_IDDictamenJuridico { get; set; }
        public int CSDJ_IDCreditoSustentabilidad { get; set; }
        public int CSDJ_IDPropiedad { get; set; }
        public int CSDJ_Posesion { get; set; }
        public string CSDJ_NoDocumentoPropiedad { get; set; }
        public DateTime CSDJ_Anuencia { get; set; }
        public float CSDJ_SuperficieLote { get; set; }
        public string CSDJ_DatosLibro { get; set; }
        public string CSDJ_FolioDocumento { get; set; }
        public string CSDJ_Observaciones { get; set; }
        public int CSDJ_Procedencia { get; set; }
        public string CSDJ_MotivosProcedencia { get; set; }
        public DateTime CSDJ_FechaDictaminacion { get; set; }
        public string CSDJ_UsuarioDominio { get; set; }
    }
}
