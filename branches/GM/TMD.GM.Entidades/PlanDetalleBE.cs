using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class PlanDetalleBE
    {
        public PlanDetalleBE()
        { }
        public PlanDetalleBE(IDataReader oReader)
        {}

        #region Atributos
        public Guid GUID_ROW { get; set; }
        public int ID_ACTIVIDAD { get; set; }
        public string CODIGO_PLAN { get; set; }
        public int ITEM_ACTIVIDAD { get; set; }
        public string DESCRIPCION_TIPO_ACTIVIDAD { get; set; }
        public int CODIGO_TIPO_ACTIVIDAD { get; set; }
        public string DESCRIPCION_ACTIVIDAD { get; set; }
        public int PRIORIDAD_ACTIVIDAD { get; set; }
        public int CODIGO_FRECUENCIA { get; set; }
        public string DESCRIPCION_FRECUENCIA { get; set; }
        public int PERSONAL_REQUERIDO { get; set; }
        public int CODIGO_TIEMPO { get; set; }
        public string DESCRIPCION_TIEMPO { get; set; }
        public int TIEMPO_ACTIVIDAD { get; set; }
        public string PROCEDIMIENTOS_PLAN { get; set; }
        public string OBSERVACIONES_PLAN { get; set; }

        #endregion
    }
}
