using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace TMD.GM.Entidades
{
    public class OrdenTrabajoBE
    {
        public OrdenTrabajoBE()
        { }
        public OrdenTrabajoBE(IDataReader oReader)
        { }

        #region Atributos

        [Display(Name = "N° Orden")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(10, ErrorMessage = "Se permiten 10 caracteres como máximo")]
        public string NUMERO_ORDEN { get; set; }

        [Display(Name = "Fecha de emisión")]
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime? FECHA_EMISION_ORDEN { get; set; }

        [Display(Name = "Inicio de atención")]
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime? FECHA_INICIO_ORDEN { get; set; }

        [Display(Name = "Fin de atención")]
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime? FECHA_FIN_ORDEN { get; set; }

        [Display(Name = "Horas de trabajo")]
        [Required(ErrorMessage = "El campo es requerido")]
        public decimal HORAS_TRABAJO_ORDEN { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(250, ErrorMessage = "Se permiten 250 caracteres como máximo")]
        public string OBSERVACIONES_ORDEN { get; set; }

        [Display(Name = "Responsable")]
        public int? CODIGO_EMPLEADO { get; set; }
        public string NOMBRE_EMPLEADO { get; set; }

        [Display(Name = "N° Solicitud")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(10, ErrorMessage = "Se permiten 10 caracteres como máximo")]
        public string NUMERO_SOLICITUD { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int ESTADO_ORDEN { get; set; }
        public string DESCRIPCION_ESTADO { get; set; }

        public List<OrdenTrabajoDetalleBE> listaActividades { get; set; }

        #endregion
    }
}

