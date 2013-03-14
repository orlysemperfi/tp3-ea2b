using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class PlanBE
    {
        public PlanBE()
        { }
        public PlanBE(IDataReader oReader)
        {}

        #region Atributos
        public string CODIGO_PLAN { get; set; }
        public string NOMBRE_PLAN { get; set; }
        public bool ESTADO_PLAN { get; set; }
        #endregion
    }
}
