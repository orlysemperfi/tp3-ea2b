using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Entidades;
using Ediable_Repeater;

namespace TMD.CF.Site.Vistas.ACP
{
    public interface IProgramaAnualVista
    {
        int IdProgramaAnual { set; }

        int AnhoPrograma { get; set; }

        int IdUsuarioCreacion { get; }

        string UsuarioCreacion { set; }

        string UsuarioAprobacion{ set; }

        string Estado { set; }

        List<Auditoria> ObjAuditorias { set; }

        string IsView { set; }

        string tempNroAuditoria { get;  set; }

        Auditoria Auditoria { get; set; }

        string Mensaje { set; }

        string IsValid { set; }
    }
}