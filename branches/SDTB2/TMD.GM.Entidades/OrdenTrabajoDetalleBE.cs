using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class OrdenTrabajoDetalleBE
    {
        public OrdenTrabajoDetalleBE()
        { }
        public OrdenTrabajoDetalleBE(IDataReader oReader)
        { }

        #region Atributos

        public Guid GUID_ROW { get; set; }
        public int ID_ACTIVIDAD { get; set; }
        public string NUMERO_ORDEN { get; set; }
        public int ITEM_ORDEN { get; set; }
        public string NUMERO_SOLICITUD { get; set; }
        public DateTime? FECHA_INICIO_ACTIVIDAD { get; set; }
        public int? ITEM_SOLICITUD { get; set; }
        public DateTime? FECHA_FIN_ACTIVIDAD { get; set; }
        public DateTime? FECHA_PROGRAMADA { get; set; }
        public DateTime? FECHA_CRONOGRAMA { get; set; }
        public string RESULTADO_ATENCION { get; set; }
        public decimal TIEMPO_ACTIVIDAD { get; set; }
        public string DESCRIPCION_TIEMPO { get; set; }

        public string DESCRIPCION_TIPO_ACTIVIDAD { get; set; }
        public string DESCRIPCION_ACTIVIDAD { get; set; }
        public string CODIGO_EQUIPO { get; set; }
        public bool CHECKED { get; set; }
        public string TIEMPO_ACTIVIDAD_TEXTO { get; set; }


        #endregion
    }
}
