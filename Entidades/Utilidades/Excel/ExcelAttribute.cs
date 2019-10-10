using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Atributo para decorar propiedades de entidades que se utilizaran en la exportación a Excel
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class ExcelAttribute : Attribute
    {
        /// <summary>
        /// Letra de la Columna de Excel sobre la cual se exportará la propiedad
        /// </summary>
        public string Columna { get; set; }
        /// <summary>
        /// Texto del Encabezado para la propiedad
        /// </summary>
        public string Encabezado { get; set; }
        /// <summary>
        /// Indica si la columna se ajustará a su contenido
        /// </summary>
        public bool Ajustar { get; set; }
        /// <summary>
        /// Indica el tipo de dato de Excel para la propiedad
        /// </summary>
        public XLDataType? DataType { get; private set; }

        public ExcelAttribute() { }

        public ExcelAttribute(XLDataType dataType)
        {
            DataType = dataType;
        }
    }
}
