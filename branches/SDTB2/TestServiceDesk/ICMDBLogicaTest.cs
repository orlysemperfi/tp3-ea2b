using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.SD.LogicaNegocio_Atencion.Implementacion;
using TMD.SD.AccesoDatos_Atencion.Implementacion;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TMD.Entidades;
using System.Collections.Generic;

namespace TestServiceDesk
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para ICMDBLogicaTest y se pretende que
    ///contenga todas las pruebas unitarias ICMDBLogicaTest.
    ///</summary>
    [TestClass()]
    public class ICMDBLogicaTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
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

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual ICMDBLogica CreateICMDBLogica()
        {
            // TODO: Crear instancia de una clase concreta apropiada.
            //ICMDBLogica target = null;
            ICMDBLogica target = new CMDBLogica(new CMDBData("TMD"));
            return target;
        }

        /// <summary>
        ///Una prueba de listaCMDBProyecto
        ///</summary>
        [TestMethod()]
        public void listaCMDBProyectoTest()
        {

            
            ICMDBLogica target = CreateICMDBLogica(); // TODO: Inicializar en un valor adecuado
            int codigoProyecto = 1; // TODO: Inicializar en un valor adecuado
            List<CMDB> expected = null; // TODO: Inicializar en un valor adecuado
            List<CMDB> actual;
            actual = target.listaCMDBProyecto(codigoProyecto);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }
    }
}
