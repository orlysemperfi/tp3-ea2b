using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class SolicitudFiltroBE
    {
        public SolicitudFiltroBE()
        { }
        public SolicitudFiltroBE(IDataReader oReader)
        {}

        #region Atributos
        public string NUMERO_SOLICITUD { get; set; }
        public int TIPO_SOLICITUD { get; set; }
        public string DOCUMENTO_REFERENCIA { get; set; }
        public DateTime? FECHA_INICIO_SOLICITUD { get; set; }
        public DateTime? FECHA_FIN_SOLICITUD { get; set; }
        public int ESTADO_SOLICITUD { get; set; }
        public int CODIGO_EQUIPO { get; set; }
        public string CODIGO_PLAN { get; set; }
        #endregion
    }
}
