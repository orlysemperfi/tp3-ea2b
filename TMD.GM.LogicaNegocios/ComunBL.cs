using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.AccesoDatos;
using TMD.GM.Entidades;

namespace TMD.GM.LogicaNegocios
{
    public class ComunBL
    {
        #region Constructor
        ComunDA instanciaDA;
        public ComunBL(): this(new ComunDA()) {}
        public ComunBL(ComunDA instanciaDA) { this.instanciaDA = instanciaDA; }
        #endregion

        public List<SelectListItemBE> ListarTipoMante()
        {
            return instanciaDA.ListarTipoMante();
        }
        public List<SelectListItemBE> ListarEstadoSolicitud()
        {
            return instanciaDA.ListarEstadoSolicitud();
        }
        public List<SelectListItemBE> ListarPlanMante()
        {
            return instanciaDA.ListarPlanMante();
        }

        public SolicitudBE ObtenerSolicitudNueva()
        {
            return instanciaDA.ObtenerSolicitudNueva();
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
        public PlanBE ObtenerObtenerPlanNuevo()
        {
            return instanciaDA.ObtenerPlanNuevo();
        }
    }
}
