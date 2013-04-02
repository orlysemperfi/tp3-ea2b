using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class SelectListItemBE
    {
        public SelectListItemBE()
        { }
        public SelectListItemBE(IDataReader oReader)
        {}

        #region Atributos
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        #endregion
    }
}
