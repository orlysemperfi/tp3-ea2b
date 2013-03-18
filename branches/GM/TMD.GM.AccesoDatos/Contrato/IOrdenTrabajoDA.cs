using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface IOrdenTrabajoDA
    {
        //PlanBE ObtenerPlanNuevo();
        //List<SelectListItemBE> ListarPlanMante();
        List<OrdenTrabajoBE> ListarOrdenTrabajo(DateTime? pd_Fini, DateTime? pd_Ffin);
        //void RegistrarPlan(PlanBE planBE);
        //void ActualizarPlan(PlanBE planBE);
        //PlanBE VisualizarPlan(PlanBE planBE);
    }
}
