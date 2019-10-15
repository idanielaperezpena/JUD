using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CCDictamenJuridico
    {
        public int? CCDJ_IDDictamenJuridico { get; set; }
        public int CCDJ_IDCreditoComplementario { get; set; }
        public int CCDJ_IDPropiedad { get; set; }
        public int CCDJ_Posesion { get; set; }
        public string CCDJ_NoDocumentoPropiedad { get; set; }
        public DateTime CCDJ_Anuencia { get; set; }
        public float CCDJ_SuperficieLote { get; set; }
        public string CCDJ_DatosLibro { get; set; }
        public string CCDJ_FolioDocumento { get; set; }
        public string CCDJ_Observaciones { get; set; }
        public int CCDJ_Procedencia { get; set; }
        public string CCDJ_MotivosProcedencia { get; set; }
        public DateTime CCDJ_FechaDictaminacion { get; set; }
        public string CCDJ_UsuarioDominio { get; set; }
    }
}
