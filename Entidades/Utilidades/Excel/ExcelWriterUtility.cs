using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utilidades
{
    /// <summary>
    /// Clase base para la generacion de Archivos en Excel
    /// </summary>
    public abstract class ExcelWriterUtility
    {
        public const string CONTENT_TYPE = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public const string EXTENSION = ".xlsx";

        public List<string> Encabezados { get; protected set; }
        public int InicioFilaCabecera { get; set; }
        public int InicioColumnaCabecera { get; set; }
        public string Nombre { get; set; }
        public string NombreHoja { get; set; }
        public bool AjustarColumnas { get; set; }

        protected abstract void SetEncabezados(IXLWorksheet pSheet);
        protected abstract void SetContenido(IXLWorksheet pSheet);

        public ExcelWriterUtility()
        {
            InicioFilaCabecera = 1;
            InicioColumnaCabecera = 1;
            AjustarColumnas = true;
            Encabezados = new List<string>();
        }

        /// <summary>
        /// Obtiene el MemoryStream del documento
        /// </summary>
        public MemoryStream Exportar()
        {
            using (var book = GenerarExcel())
            {
                using (var stream = new MemoryStream())
                {
                    book.SaveAs(stream);

                    return stream;
                }
            }
        }

        /// <summary>
        /// Guarda el documento en la ubicación física
        /// </summary>
        /// <param name="ruta">Ruta para guardar el archivo</param>
        public void Exportar(string ruta)
        {
            Nombre = Path.GetFileName(ruta);

            using (var book = GenerarExcel())
            {
                ruta = Path.Combine(Path.GetDirectoryName(ruta), Nombre);
                book.SaveAs(ruta);
            }
        }

        protected virtual XLWorkbook GenerarExcel()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                Nombre = "Export_" + DateTime.Now.ToString("ddMMyyHHmmss");

            if (string.IsNullOrWhiteSpace(NombreHoja))
                NombreHoja = Path.GetFileNameWithoutExtension(Nombre);

            Nombre = Path.ChangeExtension(Nombre, EXTENSION);

            var book = new XLWorkbook();
            var sheet = book.AddWorksheet(NombreHoja);

            SetEncabezados(sheet);
            SetContenido(sheet);

            if (AjustarColumnas)
                sheet.Columns().AdjustToContents();

            foreach (var col in sheet.ColumnsUsed(c => c.Width > 255))
                col.Width = 254;

            return book;
        }

        protected virtual void FormatearEncabezados(IXLWorksheet pSheet)
        {
            for (var idx = 0; idx < Encabezados.Count; idx++)
            {
                pSheet.Cell(InicioFilaCabecera, InicioColumnaCabecera + idx).Value = Encabezados[idx];
                pSheet.Cell(InicioFilaCabecera, InicioColumnaCabecera + idx).Style.Font.Bold = true;
                pSheet.Cell(InicioFilaCabecera, InicioColumnaCabecera + idx).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                pSheet.Cell(InicioFilaCabecera, InicioColumnaCabecera + idx).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }
        }
    }

    /// <summary>
    /// Clase de tipo ExcelWriterUtility que exporta un Enumerable.
    /// Las propiedades a exportar deben estar decoradas con el atributo ExcelAttribue del cual se tomará la columna y el texto del encabezado.
    /// </summary>
    /// <typeparam name="T">Clase a exportar decorada con el atributo ExcelAttribute a nivel de Propiedad</typeparam>
    public class EnumerableExcelWriter<T> : ExcelWriterUtility
    {
        /// <summary>
        /// Obtiene la Relación Propiedad-Columna-Encabezado de aquellas propiedades a exportar
        /// </summary>
        public Dictionary<string, ExcelAttribute> EncabezadosPersonalizados { get; private set; }
        /// <summary>
        /// Obtiene o establece el DataSource a Exportar
        /// </summary>
        public IEnumerable<T> Datos { get; set; }

        /// <summary>
        /// Inicializa el DataSource a exportar
        /// </summary>
        /// <param name="pDatos">DataSource a exportar</param>
        public EnumerableExcelWriter(IEnumerable<T> pDatos)
        {
            Datos = pDatos;
        }

        /// <summary>
        /// Obtiene todas las propiedades decoradas con ExcelAttribute e inicializa los Encabezados
        /// </summary>
        /// <param name="pSheet">Hoja de Excel donde se exportará el DataSource</param>
        protected override void SetEncabezados(IXLWorksheet pSheet)
        {
            EncabezadosPersonalizados = new Dictionary<string, ExcelAttribute>();

            var _headers = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(p => Attribute.IsDefined(p, typeof(ExcelAttribute)));

            for (int idx = 0; idx < _headers.Count(); idx++)
            {
                var prop = _headers.ElementAt(idx);
                var attr = prop.GetCustomAttribute<ExcelAttribute>();

                if (string.IsNullOrWhiteSpace(attr.Columna))
                    attr.Columna = ((char)(idx + 'A')).ToString();

                pSheet.Cell(InicioFilaCabecera, attr.Columna).Value = attr.Encabezado;
                pSheet.Cell(InicioFilaCabecera, attr.Columna).Style.Font.Bold = true;
                pSheet.Cell(InicioFilaCabecera, attr.Columna).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                pSheet.Cell(InicioFilaCabecera, attr.Columna).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                EncabezadosPersonalizados.Add(prop.Name, attr);
            }
        }

        /// <summary>
        /// Itera cada encabezado para obtener el valor de su propiedad y exportarla en la fila y columna que le corresponde
        /// </summary>
        /// <param name="pSheet">Hoja de Excel donde se exportará el DataSource</param>
        protected override void SetContenido(IXLWorksheet pSheet)
        {
            PropertyInfo property = null;
            KeyValuePair<string, ExcelAttribute> _attr;
            int indexInicio = InicioFilaCabecera + 1;

            foreach (var item in Datos)
            {
                for (var idx = 0; idx < EncabezadosPersonalizados.Count; idx++)
                {
                    _attr = EncabezadosPersonalizados.ElementAt(idx);
                    property = typeof(T).GetProperty(_attr.Key);

                    if (property != null)
                    {
                        pSheet.Cell(indexInicio, _attr.Value.Columna).Value = property.GetValue(item);

                        if (_attr.Value.DataType != null)
                            pSheet.Cell(indexInicio, _attr.Value.Columna).DataType = (XLDataType)_attr.Value.DataType;

                        if (_attr.Value.Ajustar)
                            pSheet.Column(_attr.Value.Columna).AdjustToContents();
                    }
                }

                indexInicio++;
            }

            EncabezadosPersonalizados.Clear();
        }
    }

    /// <summary>
    /// Clase que genera un archivo de Excel a partir del IDataReader generado, hereda de cls_ExcelHelper 
    /// </summary>
    public class DataReaderExcelWriter : ExcelWriterUtility
    {
        public IDataReader Datos { get; private set; }

        public DataReaderExcelWriter(IDataReader pDatos)
            : base()
        {
            Datos = pDatos;
        }

        public DataReaderExcelWriter(IDataReader pDatos, List<string> pEncabezado)
            : base()
        {
            Datos = pDatos;
            Encabezados = pEncabezado;
        }

        /// <summary>
        /// Si la propiedad Encabezados es null o vacia, se utilizan el nombre de las propiedades de la entidad T, 
        /// en su defecto se utilizan las proporcionadas
        /// </summary>
        /// <param name="pSheet">Hoja de Excel donde se escribe la información</param>
        protected override void SetEncabezados(IXLWorksheet pSheet)
        {
            if (Encabezados == null)
            {
                Encabezados = new List<string>();

                for (int idx = 0; idx < Datos.FieldCount; idx++)
                    Encabezados.Add(Datos.GetName(idx));
            }

            base.FormatearEncabezados(pSheet);
        }

        /// <summary>
        /// Obtiene el contenido a partir del IDataReader y los encabezados proporcionados
        /// </summary>
        /// <param name="pSheet">Hoja de Excel donde se escribe la información</param>
        protected override void SetContenido(IXLWorksheet pSheet)
        {
            if (Datos != null)
            {
                int indexInicio = InicioFilaCabecera + 1;

                while (Datos.Read())
                {
                    for (var idx = 0; idx < Encabezados.Count; idx++)
                        pSheet.Cell(indexInicio, idx + 1).Value = Datos[idx].ToString();

                    indexInicio++;
                }

                Encabezados.Clear();
                Datos.Close();
                Datos.Dispose();
            }
        }
    }
}
