using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class EspecialidadBE
    {
        public EspecialidadBE()
        { }
        public EspecialidadBE(IDataReader oReader)
        {}

        #region Atributos
        public int CODIGO_TIPO_ACTIVIDAD { get; set; }
        public string DESCRIPCION_TIPO_ACTIVIDAD { get; set; }
        public bool ESPECIALIDAD { get; set; }

        #endregion
    }
}
