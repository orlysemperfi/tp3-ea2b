using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Entidades;
using System.Web.SessionState;

namespace Ediable_Repeater
{

    public class DataAuditores
    {
        
        public int? idAuditoria { get; set; }

        public DataAuditores(int id)
        {
            idAuditoria = id;
        }
             
        public List<EmpleadoEntidad> Auditores
        {
            get
            {
                if (HttpContext.Current.Session[string.Format("PLANAUDITORIA-AUDITORES-{0}", idAuditoria)] == null)
                {
                    HttpContext.Current.Session[string.Format("PLANAUDITORIA-AUDITORES-{0}", idAuditoria)] = new List<EmpleadoEntidad>();
                }
                return HttpContext.Current.Session[string.Format("PLANAUDITORIA-AUDITORES-{0}", idAuditoria)] as List<EmpleadoEntidad>;
            }
        }
    }

    public class DataActividades
    {

        public int? idAuditoria { get; set; }

        public DataActividades(int id)
        {
            idAuditoria = id;
        }

        public int NextId
        {
            get
            {
                int id = 0;
                if (Actividades.Count != 0)
                {
                    id = Actividades.Max(c => c.IdActividad);
                }
                return ++id;
            }
        }

        public List<Actividad> Actividades
        {
            get
            {
                if (HttpContext.Current.Session[string.Format("PLANAUDITORIA-ACTIVIDADES-{0}", idAuditoria)] == null)
                {
                    HttpContext.Current.Session[string.Format("PLANAUDITORIA-ACTIVIDADES-{0}", idAuditoria)] = new List<Actividad>();
                }
                return HttpContext.Current.Session[string.Format("PLANAUDITORIA-ACTIVIDADES-{0}", idAuditoria)] as List<Actividad>;
            }
        }
    }

    public class DataAuditorias
    {
        private DataAuditorias() { }

        public int idProgramaAnual { get; set; }

        public int NextId
        {
            get
            {
                return (auditoria != null && auditoria.Count != 0) ? Auditoria.Max(c => c.IdAuditoria.Value) + 1 : 1;
            }
        }

        private List<Auditoria> auditoria = new List<Auditoria>();

        public List<Auditoria> Auditoria
        {
            get
            {
                return auditoria;
            }
            set
            {
                auditoria = value;
            }
        }

        public static DataAuditorias Instance
        {
            get
            {
                HttpSessionState session = HttpContext.Current.Session;

                if (session["PROGRAMAANUAL-AUDITORIA"] == null)
                {
                    session["PROGRAMAANUAL-AUDITORIA"] = new DataAuditorias();
                }

                return (DataAuditorias)session["PROGRAMAANUAL-AUDITORIA"];
            }
        }
    }
}