using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace TMD.GM.Entidades
{
    public class EquipoBE
    {
        public EquipoBE()
        { }
        public EquipoBE(IDataReader oReader)
        {}

        #region Atributos

        [Display(Name = "Código equipo")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(10, ErrorMessage="Se permiten 10 caracteres como máximo")]
        public string CODIGO_EQUIPO { get; set; }

        [Display(Name = "Nombre equipo")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(250, ErrorMessage = "Se permiten 250 caracteres como máximo")]
        public string NOMBRE_EQUIPO { get; set; }

        [Display(Name = "N° Serie")]
        [Required (ErrorMessage="El campo es requerido")]
        [StringLength(50, ErrorMessage = "Se permiten 50 caracteres como máximo")]
        public string SERIE_EQUIPO { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "Se permiten 50 caracteres como máximo")]
        public string MARCA_EQUIPO { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "Se permiten 50 caracteres como máximo")]
        public string MODELO_EQUIPO { get; set; }

        [Display(Name = "Características")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(250, ErrorMessage = "Se permiten 250 caracteres como máximo")]
        public string CARACTERISTICAS_EQUIPO { get; set; }

        [Display(Name = "Fecha de compra")]
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime? FECHA_COMPRA { get; set; }

        [Display(Name = "Expira garantía")]
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime? FECHA_EXPIRACION_GARANTIA { get; set; }

        [Display(Name = "Último mantenimiento")]
        [DataType(DataType.Date)]
        public DateTime? FECHA_ULTIMO_MANTENIMIENTO_EQUIPO { get; set; }

        [Display(Name = "Área")]
        [Required]
        public int CODIGO_AREA { get; set; }

        [Display(Name = "Área")]
        public string DESCRIPCION_AREA { get; set; }

        [Display(Name = "Tipo de Equipo")]
        [Required]
        public int CODIGO_TIPO_EQUIPO { get; set; }

        [Display(Name = "Plan mantenimiento")]
        [Required]
        [StringLength(50)]
        public string CODIGO_PLAN { get; set; }

        [Display(Name = "Procedencia")]
        [Required]
        public int PROCEDENCIA_EQUIPO { get; set; }

        [Display(Name = "Activo")]
        public bool ESTADO_EQUIPO { get; set; }
        #endregion
    }
}
