using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class OrdenTrabajoFiltroBE
    {
        public OrdenTrabajoFiltroBE()
        { }
        public OrdenTrabajoFiltroBE(IDataReader oReader)
        { }

        #region Atributos

        public string NUMERO_ORDEN { get; set; }
        public DateTime? FECHA_INICIO_ORDEN { get; set; }
        public DateTime? FECHA_FIN_ORDEN { get; set; }
        public int CODIGO_EMPLEADO { get; set; }
        public string NUMERO_SOLICITUD { get; set; }
        public string CODIGO_EQUIPO { get; set; }
        public int ESTADO_ORDEN { get; set; }

        #endregion
    }
}

