using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface IProgramaAnualLogica
    {
        ProgramaAnualAuditoria ObtenerProgramaAnualDeAuditoria(int idUsuario);

        void GrabarProgramaAnual(ref ProgramaAnualAuditoria oProgramaAnualAuditoria);
        void AprobarProgramaAnual(ProgramaAnualAuditoria oProgramaAnual);
        void RechazarProgramaAnual(ProgramaAnualAuditoria oProgramaAnual);
    }
}
