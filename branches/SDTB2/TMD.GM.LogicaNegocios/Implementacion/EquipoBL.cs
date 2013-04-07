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
    public class EquipoBL:IEquipoBL
    {
        #region Constructor
        private readonly IEquipoDA instanciaDA;
        public EquipoBL()
        {
            instanciaDA = new EquipoDA();
        }
        #endregion

        public List<EquipoBE> BuscarEquipos(EquipoBE equipoBE)
        {
            return instanciaDA.BuscarEquipos(equipoBE);
        }
        public List<EquipoBE> ListarEquiposTodos(EquipoBE equipoBE)
        {
            return instanciaDA.ListarEquiposTodos(equipoBE   );
        }
        public void Registrar(EquipoBE equipoBE)
        {
            instanciaDA.Registrar(equipoBE);
        }

        public void Actualizar(EquipoBE equipoBE)
        {
            instanciaDA.Actualizar(equipoBE);
        }

        public void Eliminar(EquipoBE equipoBE)
        {
            instanciaDA.Eliminar(equipoBE);
        }
        public EquipoBE Visualizar(EquipoBE equipoBE)
        {
            return instanciaDA.Visualizar(equipoBE);
        }
        
    }
}
