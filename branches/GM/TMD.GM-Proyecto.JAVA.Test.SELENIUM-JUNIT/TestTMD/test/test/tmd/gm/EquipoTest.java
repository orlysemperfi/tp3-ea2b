/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package test.tmd.gm;

import com.thoughtworks.selenium.*;
import org.junit.*;
import static org.junit.Assert.*;

/**
 *
 * @author Carlos
 */
public class EquipoTest extends BaseTest{

    @Test
    public void test1EquipoRegistrarOK() throws Exception {
        String codigoEquipo = "201304070";
        selenium.open("/");
        selenium.click("link=Equipo");
        selenium.waitForPageToLoad("30000");
        selenium.click("id=btnNuevoEquipo");
        selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
        selenium.type("id=txtCodigoEquipo", codigoEquipo);
        selenium.type("id=txtNombreEquipo", "Equipo Desktop");
        selenium.type("id=txtSerieEquipo", "8745321123");
        selenium.type("id=txtMarcaEquipo", "HP");
        selenium.type("id=txtModeloEquipo", "HP");
        selenium.type("id=txtCaracteristicaEquipo", "DESKTOP HP");
        selenium.type("id=txtFechaCompra", "07/04/2013");
        selenium.type("id=txtFechaExpira", "11/05/2014");        
        selenium.select("id=ddlArea", "label=CONTABILIDAD");
        selenium.select("id=ddlTipoEquipo", "label=DESKTOP");
        selenium.select("id=ddlPlanMant", "label=PLAN DESKTOP");
        selenium.select("id=ddlProcedEquipo", "label=Propio");
        selenium.click("id=checkEstado");
        selenium.click("id=btnRegistrar");
        selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
        assertFalse("Error!!!",selenium.isTextPresent("Error"));
    }
    
    //@Test
    public void test2EquipoRegistrarError() throws Exception {
        String codigoEquipo = "2013040703";
        selenium.open("/");
        selenium.click("link=Equipo");
        selenium.waitForPageToLoad("30000");
	selenium.click("id=btnNuevoEquipo");
        selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
        selenium.type("id=txtCodigoEquipo", codigoEquipo);
        selenium.type("id=txtNombreEquipo", "Equipo desktop");
        selenium.type("id=txtSerieEquipo", "123456789");
        selenium.type("id=txtMarcaEquipo", "Samsung");
        selenium.type("id=txtModeloEquipo", "Desktop");
        selenium.type("id=txtCaracteristicaEquipo", "Desktop");
	selenium.type("id=txtFechaCompra", "07/04/2013");
        selenium.type("id=txtFechaExpira", "07/04/2014");
        selenium.click("xpath=(//li[@id='ddlArea_option_selected'])[3]");
        selenium.click("xpath=(//li[@id='ddlTipoEquipo_option_selected'])[3]");
        selenium.click("xpath=(//li[@id='ddlProcedEquipo_option_selected'])[3]");
        selenium.click("id=checkEstado");
        selenium.click("id=btnRegistrar");
        selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
        assertFalse("Error!!!. Equipo ya existe",selenium.isTextPresent("Error"));
    }
}
