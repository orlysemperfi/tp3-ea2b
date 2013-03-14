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
        public string CODIGO { get; set; }
        #endregion
    }
}
