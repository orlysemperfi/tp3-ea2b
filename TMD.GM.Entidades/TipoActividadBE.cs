using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class TipoActividadBE
    {
        public TipoActividadBE()
        { }
        public TipoActividadBE(IDataReader oReader)
        {}

        #region Atributos
        public string CODIGO_TIPO_ACTIVIDAD { get; set; }
        public string DESCRIPCION_TIPO_ACTIVIDAD { get; set; }
        public bool ESPECIALIDAD { get; set; }

        #endregion
    }
}
