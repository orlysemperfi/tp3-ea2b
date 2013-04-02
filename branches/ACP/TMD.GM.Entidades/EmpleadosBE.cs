using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class EmpleadosBE
    {
        public EmpleadosBE()
        { }
        public EmpleadosBE(IDataReader oReader)
        {}

        #region Atributos
        public string NOMBRES { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string DNI_PERSONA { get; set; }
        public int CODIGO_EMPLEADO { get; set; }
        public int CODIGO_AREA { get; set; }
        public int CODIGO_PUESTO { get; set; }
        public string DESCRIPCION_AREA { get; set; }
        public string DESCRIPCION_PUESTO { get; set; }
        public string NOMBRE_COMPLETO { get; set; }

        #endregion
    }
}
