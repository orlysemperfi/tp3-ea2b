using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.LogicaNegocios.Contrato
{
    public interface IOrdenTrabajoBL
    {
        List<OrdenTrabajoBE> ListarOrdenTrabajo(OrdenTrabajoFiltroBE entidad);
        void Registrar(OrdenTrabajoBE entidad);
        void Registrar(List<OrdenTrabajoBE> entidades);
        void Actualizar(OrdenTrabajoBE entidad);
        void Eliminar(OrdenTrabajoBE entidad);
        OrdenTrabajoBE Visualizar(OrdenTrabajoBE entidad);
        List<OrdenTrabajoDetalleBE> VisualizarDetalle(OrdenTrabajoBE entidad);
        List<OrdenTrabajoEquipoBE> ListarEquiposPendientes(OrdenTrabajoFiltroBE filtro);
        List<OrdenTrabajoDetalleBE> ListarActividadesEquiposPendientes(OrdenTrabajoFiltroBE filtro);
        OrdenTrabajoBE ObtenerOrdenTrabajoNueva();
    }
}
