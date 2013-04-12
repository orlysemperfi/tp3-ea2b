using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace TMD.GM.Entidades
{
    public class OrdenTrabajoEquipoBE
    {
        public OrdenTrabajoEquipoBE()
        { }
        public OrdenTrabajoEquipoBE(IDataReader oReader)
        {}

        #region Atributos

        public string CODIGO_EQUIPO { get; set; }

        [Display(Name = "Nombre")]
        public string NOMBRE_EQUIPO { get; set; }

        public string DESCRIPCION_TIPO_EQUIPO { get; set; }
        public string NOMBRE_PLAN { get; set; }
        public string NUMERO_SOLICITUD { get; set; }
        #endregion

        public bool CHECKED { get; set; }
        public int CANTIDAD_ACTIVIDADES { get; set; }
        public string TIEMPO_ESTIMADO { get; set; }
        public int CODIGO_TIEMPO { get; set; }

        [Display(Name = "Código")]
        public int CODIGO_RESPONSABLE { get; set; }

        [Display(Name = "Nombre")]
        public string NOMBRE_RESPONSABLE { get; set; }

        [Display(Name = "Candidad de OT asignadas")]
        public int CANTIDAD_OT_ASIGNADAS { get; set; }
        [Display(Name = "Duración de OT asignadas (Horas)")]
        public decimal HORAS_OT_ASIGNADAS { get; set; }

        public DateTime? FECHA_INICIO_ORDEN { get; set; }
        public DateTime? FECHA_FIN_ORDEN { get; set; }
        
        

    }
}
