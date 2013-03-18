using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface IPlanDA
    {
        PlanBE ObtenerPlanNuevo();
        List<SelectListItemBE> ListarPlanMante();
        List<PlanBE> ListarPlanManteTodos();
        void RegistrarPlan(PlanBE planBE);
        void ActualizarPlan(PlanBE planBE);
        void EliminarPlan(PlanBE planBE);
        PlanBE VisualizarPlan(PlanBE planBE);
    }
}
