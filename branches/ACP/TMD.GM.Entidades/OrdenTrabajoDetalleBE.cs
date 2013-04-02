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

        public string NUMERO_ORDEN { get; set; }
        public int ITEM_ORDEN { get; set; }
        public string NUMERO_SOLICITUD { get; set; }
        public DateTime FECHA_INICIO_ACTIVIDAD { get; set; }
        public int ITEM_SOLICITUD { get; set; }
        public DateTime FECHA_FIN_ACTIVIDAD { get; set; }
        public DateTime FECHA_PROGRAMADA { get; set; }
        public string RESULTADO_ATENCION { get; set; }

        #endregion
    }
}
