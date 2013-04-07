using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface IComunDA
    {
        List<SelectListItemBE> ListarTipoMante();
        List<SelectListItemBE> ListarEstadoSolicitud();
        List<SelectListItemBE> ListarEstadoOT();
        List<SelectListItemBE> ListarTipoActividad();
        List<SelectListItemBE> ListarTipoEquipo();
        List<SelectListItemBE> ListarAreas();
        List<SelectListItemBE> ListarTiempoUniMed();
        List<SelectListItemBE> ListarPrioridad();
        List<SelectListItemBE> ListarFrecuencia();
        List<SelectListItemBE> ListarProcedencia();
        
    }
}
