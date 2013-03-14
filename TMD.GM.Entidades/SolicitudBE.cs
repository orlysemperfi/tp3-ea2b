using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class SolicitudBE
    {
        public SolicitudBE()
        { }
        public SolicitudBE(IDataReader oReader)
        {}

        #region Atributos
        public string NUMERO_SOLICITUD { get; set; }
        public DateTime FECHA_SOLICITUD { get; set; }
        #endregion
    }
}
