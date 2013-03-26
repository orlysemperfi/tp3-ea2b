using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class OrdenTrabajoBE
    {
        public OrdenTrabajoBE()
        { }
        public OrdenTrabajoBE(IDataReader oReader)
        { }

        #region Atributos

        public string NUMERO_ORDEN { get; set; }
        public DateTime FECHA_EMISION_ORDEN { get; set; }
        public DateTime FECHA_INICIO_ORDEN { get; set; }
        public DateTime FECHA_FIN_ORDEN { get; set; }
        public decimal HORAS_TRABAJO_ORDEN { get; set; }
        public string OBSERVACIONES_ORDEN { get; set; }
        public int CODIGO_EMPLEADO { get; set; }
        public string NUMERO_SOLICITUD { get; set; }
        public int ESTADO_ORDEN { get; set; }
        //-- INI OTROS
        public string UMERO_SOLICITUD { get; set; }
        public string NOMBRE_EQUIPO { get; set; }
        public string MARCA_EQUIPO { get; set; }
        public string DESC_AREA { get; set; }
        public DateTime FECHA_INICIO_SOLICITUD { get; set; }
        public DateTime FECHA_FIN_SOLICITUD { get; set; }
        public int ESTADO_SOLICITUD { get; set; }
        //-- FIN OTROS

        public List<OrdenTrabajoDetalleBE> listaActividades { get; set; }

        #endregion
    }
}

