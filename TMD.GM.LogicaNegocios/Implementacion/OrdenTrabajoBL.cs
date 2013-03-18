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
    public class OrdenTrabajoBL : IOrdenTrabajoBL
    {
        #region Constructor
        private readonly IOrdenTrabajoDA instanciaDA;
        public OrdenTrabajoBL()
        {
            instanciaDA = new OrdenTrabajoDA();
        }
        #endregion

        public List<OrdenTrabajoBE> ListarOrdenTrabajo(DateTime? pd_Fini, DateTime? pd_Ffin)
        {
            return instanciaDA.ListarOrdenTrabajo(pd_Fini, pd_Ffin);
        }
    }
}
