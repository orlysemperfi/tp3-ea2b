using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace TMD.GM.Entidades
{
    public class OrdenTrabajoDetalleBE
    {
        public OrdenTrabajoDetalleBE()
        { }
        public OrdenTrabajoDetalleBE(IDataReader oReader)
        { }

        #region Atributos

        public Guid GUID_ROW { get; set; }
        public int ID_ACTIVIDAD { get; set; }
        public string NUMERO_ORDEN { get; set; }

        [Display(Name = "N° Item")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int ITEM_ORDEN { get; set; }
        public string NUMERO_SOLICITUD { get; set; }

        [Display(Name = "Inicio actividad")]
        public DateTime? FECHA_INICIO_ACTIVIDAD { get; set; }

        [Display(Name = "N° Item solicitud")]
        public int? ITEM_SOLICITUD { get; set; }

        [Display(Name = "Fin actividad")]
        public DateTime? FECHA_FIN_ACTIVIDAD { get; set; }


        [Display(Name = "Fecha programada")]
        public DateTime? FECHA_PROGRAMADA { get; set; }
        [Display(Name = "Fecha cronograma")]
        public DateTime? FECHA_CRONOGRAMA { get; set; }
        public string RESULTADO_ATENCION { get; set; }

        public decimal TIEMPO_ACTIVIDAD { get; set; }
        public string DESCRIPCION_TIEMPO { get; set; }

        [Display(Name = "Actividad")]
        public string DESCRIPCION_TIPO_ACTIVIDAD { get; set; }

        [Display(Name = "Tipo actividad")]
        public string DESCRIPCION_ACTIVIDAD { get; set; }

        [Display(Name = "Código equipo")]
        public string CODIGO_EQUIPO { get; set; }
        public bool CHECKED { get; set; }
        [Display(Name = "Tiempo actividad")]
        public string TIEMPO_ACTIVIDAD_TEXTO { get; set; }
        public int CODIGO_TIEMPO { get; set; }


        #endregion

    }
}
