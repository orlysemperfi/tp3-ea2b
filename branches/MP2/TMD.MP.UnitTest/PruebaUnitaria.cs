using TMD.Entidades;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;
using TMD.MP.LogicaNegocios.Excepcion;
using TMD.MP.Comun;
using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace TMD.MP.UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class PruebaUnitaria
    {
        public PruebaUnitaria()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }



        //[Test]
        //public void PropuestaInsertOK()
        //{
        //    IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
        //    PropuestaMejoraEntidad oPropuestaMejora = new PropuestaMejoraEntidad();
        //    oPropuestaMejora.codigo_Area = 1;
        //    oPropuestaMejora.tipo_Propuesta = "Mejora";
        //    oPropuestaMejora.codigo_Responsable = 1;
        //    oPropuestaMejora.codigo_Proceso = 1;
        //    oPropuestaMejora.descripcion = "Descripcion de mejora";
        //    oPropuestaMejora.fecha_Envio = Convert.ToDateTime("30/04/2013");
        //    oPropuestaMejora.causa = "Causa de la mejora";
        //    oPropuestaMejora.beneficios = "Beneficios";
        //    oPropuestaMejora.observaciones = "Observaciones realizadas";
        //    oPropuestaMejora.lstIndicadores = new List<IndicadorEntidad>();


        //    IndicadorEntidad oIndicador1 = new IndicadorEntidad();
        //    oIndicador1.codigo = 1;
        //    oIndicador1.marcado = "true";
        //    IndicadorEntidad oIndicador2 = new IndicadorEntidad();
        //    oIndicador2.codigo = 2;
        //    oIndicador2.marcado = "false";
        //    oPropuestaMejora.lstIndicadores.Add(oIndicador1);
        //    oPropuestaMejora.lstIndicadores.Add(oIndicador2);
        //    oPropuestaMejoraLogica.InsertarPropuestaMejora(oPropuestaMejora);

        //}

        [Test]
        [ExpectedException(typeof(BRuleException))]
        public void PropuestaInsertarError()
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            PropuestaMejoraEntidad oPropuestaMejora = new PropuestaMejoraEntidad();
            oPropuestaMejora.codigo_Area = 1;
            oPropuestaMejora.tipo_Propuesta = "Mejora";
            oPropuestaMejora.codigo_Responsable = 1;
            oPropuestaMejora.codigo_Proceso = 1;
            oPropuestaMejora.descripcion = "Descripcion de mejora";
            oPropuestaMejora.fecha_Envio = Convert.ToDateTime("30/04/2013");
            oPropuestaMejora.causa = "Causa de la mejora";
            oPropuestaMejora.beneficios = "Beneficios";
            oPropuestaMejora.observaciones = "Observaciones realizadas";
            oPropuestaMejora.lstIndicadores = new List<IndicadorEntidad>();
            IndicadorEntidad oIndicador1 = new IndicadorEntidad();
            oIndicador1.codigo = 1;
            oIndicador1.marcado = "false";
            IndicadorEntidad oIndicador2 = new IndicadorEntidad();
            oIndicador2.codigo = 2;
            oIndicador2.marcado = "false";
            oPropuestaMejora.lstIndicadores.Add(oIndicador1);
            oPropuestaMejora.lstIndicadores.Add(oIndicador2);
            oPropuestaMejoraLogica.InsertarPropuestaMejora(oPropuestaMejora);
        }

        [Test]
        [ExpectedException(typeof(BRuleException))]
        public void PropuestaActualizarError()
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            PropuestaMejoraEntidad oPropuestaMejora = new PropuestaMejoraEntidad();
            oPropuestaMejora.codigo_Propuesta = 1;
            oPropuestaMejora.codigo_Area = 1;
            oPropuestaMejora.tipo_Propuesta = "Mejora";
            oPropuestaMejora.codigo_Responsable = 1;
            oPropuestaMejora.codigo_Proceso = 1;
            oPropuestaMejora.descripcion = "Descripcion de mejora";
            oPropuestaMejora.fecha_Envio = Convert.ToDateTime("30/04/2013");
            oPropuestaMejora.causa = "Causa de la mejora";
            oPropuestaMejora.beneficios = "Beneficios";
            oPropuestaMejora.observaciones = "Observaciones realizadas";
            oPropuestaMejora.lstIndicadores = new List<IndicadorEntidad>();
            IndicadorEntidad oIndicador1 = new IndicadorEntidad();
            oIndicador1.codigo = 1;
            oIndicador1.marcado = "false";
            IndicadorEntidad oIndicador2 = new IndicadorEntidad();
            oIndicador2.codigo = 2;
            oIndicador2.marcado = "false";
            oPropuestaMejora.lstIndicadores.Add(oIndicador1);
            oPropuestaMejora.lstIndicadores.Add(oIndicador2);
            oPropuestaMejoraLogica.InsertarPropuestaMejora(oPropuestaMejora);
        }

        [Test]
        [ExpectedException(typeof(BRuleException))]
        public void PropuestaBorrarError()
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            PropuestaMejoraEntidad oPropuestaMejora = new PropuestaMejoraEntidad();
            oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(1);
            oPropuestaMejoraLogica.BorrarPropuestaMejora(oPropuestaMejora);
        }
    }
}
