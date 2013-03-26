using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class InformesBE
    {
        public InformesBE()
        { }
        public InformesBE(IDataReader oReader)
        {}

        #region Atributos
        public int NUMERO_INFORME { get; set; }
        public DateTime FECHA_INFORME { get; set; }
        public int CODIGO_EMPLEADO { get; set; }
        public string OBSERVACION_EMPLEADO { get; set; }
        public string NOMBRES { get; set; }
        public string FECHA { get; set; }

        #endregion
    }
}
