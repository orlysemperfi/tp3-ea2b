using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.LogicaNegocios;
using TMD.Entidades;

namespace TMD.MP.Controlador
{
    public class ProcesoControlador
    {
        public ProcesoLogica procesoLogica = new ProcesoLogica();

        public List<ProcesoEntidad> ObtenerListaProcesoTodas()
        {
            return procesoLogica.ObtenerListaProcesoTodas();
        }
    }
}
