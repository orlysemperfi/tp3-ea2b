using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface IHallazgoLogica
    {
        int Agregar(Hallazgo hallazgo);
        string Modificar(Hallazgo hallazgo);
        string Eliminar(int idHallazgo);
        List<Hallazgo> Obtener(Hallazgo filtro);
        List<Auditoria> ObtenerAuditoriasSeguimiento(int anhoAuditoria);
        List<Hallazgo> ObtenerHallazgosSeguimiento(int idAuditoria, int idHallazgo, string estado);
        string GrabarHallazgoSeguimiento(Hallazgo eHallazgo);

        List<Hallazgo> Obtener_Anio(int AnhoAuditoria);
    }
}
