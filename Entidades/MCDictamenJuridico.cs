using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MCDictamenJuridico
    {
        public int? MCDJ_IDDictamenJuridico { get; set; }
        public int MCDJ_IDModificacionesCredito { get; set; }
        public int MCDJ_IDPropiedad { get; set; }
        public int MCDJ_Posesion { get; set; }
        public string MCDJ_NoDocumentoPropiedad { get; set; }
        public DateTime MCDJ_Anuencia { get; set; }
        public float MCDJ_SuperficieLote { get; set; }
        public string MCDJ_DatosLibro { get; set; }
        public string MCDJ_FolioDocumento { get; set; }
        public string MCDJ_Observaciones { get; set; }
        public int MCDJ_Procedencia { get; set; }
        public string MCDJ_MotivosProcedencia { get; set; }
        public DateTime MCDJ_FechaDictaminacion { get; set; }
        public string MCDJ_UsuarioDominio { get; set; }
    }
}
