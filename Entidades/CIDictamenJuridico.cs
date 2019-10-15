using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class CIDictamenJuridico
    {
        public int? CIDJ_IDDictamenJuridico { get; set; }
        public int CIDJ_IDCreditoInicial { get; set; }
        public int CIDJ_IDPropiedad { get; set; }
        public int CIDJ_Posesion { get; set; }
        public string CIDJ_NoDocumentoPropiedad { get; set; }
        public DateTime CIDJ_Anuencia { get; set; }
        public float CIDJ_SuperficieLote { get; set; }
        public string CIDJ_DatosLibro { get; set; }
        public string CIDJ_FolioDocumento { get; set; }
        public string CIDJ_Observaciones { get; set; }
        public int CIDJ_Procedencia { get; set; }
        public string CIDJ_MotivosProcedencia { get; set; }
        public DateTime CIDJ_FechaDictaminacion { get; set; }
        public string CIDJ_UsuarioDominio { get; set; }
    }
}
