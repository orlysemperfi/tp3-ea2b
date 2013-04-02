using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.Entidades
{
    public class CronogramaBE
    {
        public CronogramaBE()
        { }
        public CronogramaBE(IDataReader oReader)
        {}

        #region Atributos
        public int PERSONAL_DISPONIBLE { get; set; }
        public int HORAS_LABORABLES { get; set; }
        public int HORAS_DISPONIBLE { get; set; }
        public int HORAS_EMPLEADAS { get; set; }

        public List<SolicitudDetalleBE> listaActividades { get; set; }
        #endregion
    }
}
