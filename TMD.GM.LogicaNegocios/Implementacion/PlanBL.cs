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
    public class PlanBL:IPlanBL
    {
        #region Constructor
        private readonly IPlanDA instanciaDA;
        public PlanBL()
        {
            instanciaDA = new PlanDA();
        }
        #endregion

        public PlanBE ObtenerObtenerPlanNuevo()
        {
            return instanciaDA.ObtenerPlanNuevo();
        }
        public List<SelectListItemBE> ListarPlanMante()
        {
            return instanciaDA.ListarPlanMante();
        }
        public List<PlanBE> ListarPlanManteTodos()
        {
            return instanciaDA.ListarPlanManteTodos();
        }

        public void RegistrarPlan( PlanBE planBE)
        {
            instanciaDA.RegistrarPlan(planBE);
        }

        public void ActualizarPlan(PlanBE planBE)
        {
            instanciaDA.ActualizarPlan(planBE);
        }

        public void EliminarPlan(PlanBE planBE)
        {
            instanciaDA.EliminarPlan(planBE);
        }
        public PlanBE VisualizarPlan(PlanBE planBE)
        {
            return instanciaDA.VisualizarPlan(planBE);
        }
    }
}
