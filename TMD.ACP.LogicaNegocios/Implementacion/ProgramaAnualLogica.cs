using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.Core;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Implementacion;

namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class ProgramaAnualLogica : IProgramaAnualLogica
    {
        private readonly IAuditoriaData _objData;
        private readonly IEmpleadoData _objDataEmpleado;

        public ProgramaAnualLogica()
        {
            _objData = new AuditoriaData("TMD");
            _objDataEmpleado = new EmpleadoData("TMD");
        }

        public ProgramaAnualAuditoria ObtenerProgramaAnualDeAuditoria(int IdUsuario)
        {
            ProgramaAnualAuditoria oProgramaAnual = _objData.ObtenerProgramaAnualAuditorias();

            //Si existe un programa anual obtengo datos y grid de auditorias en solo lectura, de lo contrario muestra informacion por defecto
            if (oProgramaAnual != null)
            {
                oProgramaAnual.ObjAuditorias = ListarAuditoriasPorAnio(oProgramaAnual.AnhoPrograma);
            }
            else
            {
                EmpleadoEntidad empleado = _objDataEmpleado.ObtenerEmpleado(IdUsuario);

                oProgramaAnual = new ProgramaAnualAuditoria {
                    AnhoPrograma = DateTime.Today.Year,
                    UsuarioCreacion = empleado == null ? "" : empleado.nombre + " " + empleado.apellidopaterno,
                    UsuarioAprobacion = "",
                    Estado = EstadoProgramaAnual.Creado,
                    IdProgramaAnual = 0,
                };
            }

            return oProgramaAnual;
        }

        public List<Auditoria> ListarAuditoriasPorAnio(int anhoAuditoria)
        {
            return _objData.ListarAuditoriasPorAnio(anhoAuditoria);
        }

        public void GrabarProgramaAnual(ref ProgramaAnualAuditoria oProgramaAnual)
        {
            oProgramaAnual.Estado = EstadoProgramaAnual.Creado;
            oProgramaAnual.IdProgramaAnual = _objData.GrabarProgramaAnualAuditoria(oProgramaAnual);

            foreach (Auditoria eAuditoria in oProgramaAnual.ObjAuditorias)
            {
                eAuditoria.idPrograma = oProgramaAnual.IdProgramaAnual;
                eAuditoria.Estado = EstadoAuditoria.Creado;
                _objData.GrabarAuditoria(eAuditoria);
            }

            oProgramaAnual.ObjAuditorias = _objData.ListarAuditoriasPorAnio(oProgramaAnual.AnhoPrograma);
        }
    }
}
