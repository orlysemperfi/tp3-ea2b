using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Entidades;

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

        public int? idProgramaAnual { get; set; }

        public DataAuditorias(int id)
        {
            idProgramaAnual = id;
        }

        public int NextId
        {
            get
            {
                int id = 0;
                if (Auditoria.Count != 0)
                {
                    id = Auditoria.Max(c => c.IdAuditoria.Value);
                }
                return ++id;
            }
        }

        public List<Auditoria> Auditoria
        {
            get
            {
                if (HttpContext.Current.Session[string.Format("PROGRAMAANUAL-AUDITORIA-{0}", idProgramaAnual)] == null)
                {
                    HttpContext.Current.Session[string.Format("PROGRAMAANUAL-AUDITORIA-{0}", idProgramaAnual)] = new List<Auditoria>();
                }
                return HttpContext.Current.Session[string.Format("PROGRAMAANUAL-AUDITORIA-{0}", idProgramaAnual)] as List<Auditoria>;
            }
        }
    }
}