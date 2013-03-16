using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.LogicaNegocios;
using TMD.Entidades;

namespace TMD.MP.Controlador
{
    public class AreaControlador
    {
        public AreaLogica areaLogica = new AreaLogica();

        public List<AreaEntidad> ObtenerListaAreaTodas()
        {
            return areaLogica.ObtenerListaAreaTodas();
        }
    }
}
