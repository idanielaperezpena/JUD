using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// DATERANGEPICKER está basado en el plugin de JQuery: http://www.daterangepicker.com/
    /// DATEPICKER está basado en el plugin de JQuery: https://bootstrap-datepicker.readthedocs.io/en/latest/
    /// </summary>
    public enum TipoCalendario
    {
        DATERANGEPICKER,
        DATERANGEPICKER_SINGLE,
        DATEPICKER_MONTH,
        DATEPICKER_YEAR
    }

    public class CalendarControl
    {
        public string FechaString { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public TipoCalendario Tipo { get; private set; }
        public string DataToggle { get; private set; }
        public int? MinViewMode { get; private set; }
        public string DateFormat { get; private set; }
        public bool EsRequerido { get; set; }

        public CalendarControl(TipoCalendario tipo = TipoCalendario.DATERANGEPICKER)
        {
            InitParams(tipo);
        }

        private void InitParams(TipoCalendario tipo)
        {
            Tipo = tipo;

            switch (Tipo)
            {
                case TipoCalendario.DATEPICKER_MONTH:
                    DataToggle = "datepicker";
                    MinViewMode =  1;
                    DateFormat = "MM/yyyy";
                    break;
                case TipoCalendario.DATEPICKER_YEAR:
                    DataToggle = "datepicker";
                    MinViewMode = 2;
                    DateFormat = "yyyy";
                    break;
                case TipoCalendario.DATERANGEPICKER_SINGLE:
                    DataToggle = "daterangepickersingle";
                    break;
                default:
                    DataToggle = "daterangepicker";
                    break;
            }
        }
    }
}
