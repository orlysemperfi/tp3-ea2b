using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class SolicitudDetalleBE
    {
        public SolicitudDetalleBE()
        { }
        public SolicitudDetalleBE(IDataReader oReader)
        {}

        #region Atributos

        public int ID_ACTIVIDAD { get; set; }
        public string NUMERO_SOLICITUD { get; set; }
        public int ITEM_SOLICITUD { get; set; }
        public string DESCRIPCION_ACTIVIDAD { get; set; }
        public int CODIGO_TIPO_ACTIVIDAD { get; set; }
        public string DESCRIPCION_TIPO_ACTIVIDAD { get; set; }
        public int PRIORIDAD_ACTIVIDAD { get; set; }
        public int CODIGO_FRECUENCIA { get; set; }
        public string DESCRIPCION_FRECUENCIA { get; set; }
        public string DESCRIPCION_PRIORIDAD_ACTIVIDAD { get; set; }
        public int PERSONAL_REQUERIDO { get; set; }
        public int CODIGO_TIEMPO { get; set; }
        public string DESCRIPCION_TIEMPO { get; set; }
        public int TIEMPO_ACTIVIDAD { get; set; }
        public DateTime FECHA_PROGRAMACION { get; set; }
        public string ORDEN_TRABAJO { get; set; }
        #endregion
    }
}
