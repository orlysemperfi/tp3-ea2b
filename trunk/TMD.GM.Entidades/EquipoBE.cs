using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class EquipoBE
    {
        public EquipoBE()
        { }
        public EquipoBE(IDataReader oReader)
        {}

        #region Atributos
        public int CODIGO_EQUIPO { get; set; }
        public string NOMBRE_EQUIPO { get; set; }
        public string SERIE_EQUIPO { get; set; }
        public string MARCA_EQUIPO { get; set; }
        public string MODELO_EQUIPO { get; set; }
        public string CARACTERISTICAS_EQUIPO { get; set; }
        public DateTime? FECHA_COMPRA { get; set; }
        public DateTime? FECHA_EXPIRACION_GARANTIA { get; set; }
        public DateTime? FECHA_ULTIMO_MANTENIMIENTO_EQUIPO { get; set; }
        public int CODIGO_AREA { get; set; }
        public string DESCRIPCION_AREA { get; set; }
        public int CODIGO_TIPO_EQUIPO { get; set; }
        public string CODIGO_PLAN { get; set; }
        public string PROCEDENCIA_EQUIPO { get; set; }
        public bool ESTADO_EQUIPO { get; set; }
        #endregion
    }
}
