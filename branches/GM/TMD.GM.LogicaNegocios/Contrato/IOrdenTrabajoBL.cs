using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.LogicaNegocios.Contrato
{
    public interface IOrdenTrabajoBL
    {
        List<OrdenTrabajoBE> ListarOrdenTrabajo(DateTime? pd_Fini, DateTime? pd_Ffin);
    }
}
