using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Negocio
{
    public class ExcelFile
    {
        public string Extension => ".xlsx";
        public string ContentDispositionKey => "Content-Disposition";
        public string MimeType { get; set; }
        public ContentDisposition ContentDisposition { get; set; }
        public byte[] FileBytes { get; set; }

        public ExcelFile(string filename, bool inline = true)
        {
            MimeType = MimeMapping.GetMimeMapping(Extension);
            ContentDisposition = new ContentDisposition {
                FileName = Path.ChangeExtension(filename, Extension),
                Inline = inline
            };
        }
    }
}
