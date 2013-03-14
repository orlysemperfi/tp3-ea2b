using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.AccesoDatos.Implementacion;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.AccesoDatos.Contrato;

namespace TMD.GM.LogicaNegocios.Implementacion
{
    public class ComunBL:IComunBL
    {
        #region Constructor
        private readonly IComunDA instanciaDA;
        public ComunBL()
        {
            instanciaDA = new ComunDA();
        }
        #endregion


        public List<SelectListItemBE> ListarTipoMante()
        {
            return instanciaDA.ListarTipoMante();
        }
        public List<SelectListItemBE> ListarEstadoSolicitud()
        {
            return instanciaDA.ListarEstadoSolicitud();
        }

        public List<SelectListItemBE> ListarTipoActividad()
        {
            return instanciaDA.ListarTipoActividad();
        }
        public List<SelectListItemBE> ListarTiempoUniMed()
        {
            return instanciaDA.ListarTiempoUniMed();
        }
        public List<SelectListItemBE> ListarPrioridad()
        {
            return instanciaDA.ListarPrioridad();
        }
        public List<SelectListItemBE> ListarFrecuencia()
        {
            return instanciaDA.ListarFrecuencia();
        }
    }
}
