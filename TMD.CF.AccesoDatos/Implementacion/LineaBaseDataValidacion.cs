using System;
using System.Collections.Generic;
using TMD.CF.AccesoDatos.Contrato;

namespace TMD.CF.AccesoDatos.Implementacion
{
    public class LineaBaseDataValidacion : ILineaBaseData
    {
        private readonly ILineaBaseData _lineBaseData;

        public LineaBaseDataValidacion(ILineaBaseData lineaBaseData)
        {
            _lineBaseData = lineaBaseData;
        }
        
        public void Agregar(Entidades.LineaBase lineaBase)
        {
            if (lineaBase != null)
            {
                _lineBaseData.Agregar(lineaBase);
            }
            else
            {
                throw new ArgumentNullException("lineaBase");
            }
        }

        public void Actualizar(Entidades.LineaBase lineaBase)
        {
            if (lineaBase != null)
            {
                _lineBaseData.Actualizar(lineaBase);
            }
            else
            {
                throw new ArgumentNullException("lineaBase");
            }
        }

        public List<Entidades.LineaBase> ListarPorProyecto(Entidades.Proyecto proyecto, Entidades.Usuario usuario = null)
        {
            if (proyecto != null)
            {
                return _lineBaseData.ListarPorProyecto(proyecto);
            }
            throw new ArgumentNullException("proyecto");
        }

        public Entidades.LineaBase ObtenerPorProyectoFase(Entidades.ProyectoFase proyectoFase)
        {
            if (proyectoFase != null)
            {
                return _lineBaseData.ObtenerPorProyectoFase(proyectoFase);
            }
            throw new ArgumentNullException("proyectoFase");
        }
    }
}
