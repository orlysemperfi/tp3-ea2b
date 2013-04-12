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

        public List<OrdenTrabajoBE> ListarOrdenTrabajo(OrdenTrabajoFiltroBE entidad)
        {
            return instanciaDA.ListarOrdenTrabajo(entidad);
        }

        public void Registrar(OrdenTrabajoBE entidad)
        {
            instanciaDA.Registrar(entidad);
        }

        public void Actualizar(OrdenTrabajoBE entidad)
        {
            instanciaDA.Actualizar(entidad);
        }

        public void Eliminar(OrdenTrabajoBE entidad)
        {
            instanciaDA.Eliminar(entidad);
        }
        public OrdenTrabajoBE Visualizar(OrdenTrabajoBE entidad)
        {
            return instanciaDA.Visualizar(entidad);
        }
        public List<OrdenTrabajoDetalleBE> VisualizarDetalle(OrdenTrabajoBE entidad)
        {
            return instanciaDA.VisualizarDetalle(entidad);
        }
        public List<OrdenTrabajoEquipoBE> ListarEquiposPendientes(OrdenTrabajoFiltroBE filtro)
        {
            return instanciaDA.ListarEquiposPendientes(filtro);
        }

        public List<OrdenTrabajoDetalleBE> ListarActividadesEquiposPendientes(OrdenTrabajoFiltroBE filtro)
        {
            return instanciaDA.ListarActividadesEquiposPendientes(filtro);
        }
        public OrdenTrabajoBE ObtenerOrdenTrabajoNueva()
        {
            return instanciaDA.ObtenerOrdenTrabajoNueva();
        }
        public void Registrar(List<OrdenTrabajoBE> entidades)
        {
            instanciaDA.Registrar(entidades);
        }
        public OrdenTrabajoEquipoBE ObtenerDisponibilidadResponsable(OrdenTrabajoFiltroBE filtro)
        {
            return instanciaDA.ObtenerDisponibilidadResponsable(filtro);
        }
    }
}
