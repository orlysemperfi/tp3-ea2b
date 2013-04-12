package test.tmd.gm;

import com.thoughtworks.selenium.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;
import java.util.regex.Pattern;

public class PlanTest extends BaseTest {
	
        @Test
	public void test1PlanRegistrarErrorActividad() throws Exception {
		selenium.open("/");
		selenium.click("link=Plan");
		selenium.waitForPageToLoad("30000");
		selenium.click("id=btnNuevo");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "10000");
		selenium.type("id=txtCodigo", "2013040601");
		selenium.type("id=txtNombre", "PLAN DE PRUEBA 01");
		selenium.click("id=btnGrabar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "10000");
		assertTrue("Error!!!. Debe registrar actividades al plan.",selenium.isTextPresent("Error"));
	}

	@Test
	public void test2PlanRegistrarOK() throws Exception {
                String codigoPlan = "2013040702";
		selenium.open("/");
		selenium.click("link=Plan");
		selenium.waitForPageToLoad("30000");
		selenium.click("id=btnNuevo");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.type("id=txtCodigo", codigoPlan);
		selenium.type("id=txtNombre", "PLAN MANT IMPRESORA 01");
		selenium.click("id=btnAgregar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.type("id=txtActividadDesc", "LIMPIEZA CABEZAL");
		selenium.select("id=ddlTipoActividad", "label=LIMPIEZA");
		selenium.type("id=ntbPersRequ", "1");
		selenium.type("id=ntbTiempoDura", "1");
		selenium.select("id=ddlTiempoUnme", "label=horas");
		selenium.select("id=ddlPrioridad", "label=Media");
		selenium.select("id=ddlFrecuencia", "label=Quincenal");
		selenium.click("id=btnAceptar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnGrabar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		assertFalse(selenium.isTextPresent("Error"));
	}
        
        //@Test
	public void test3PlanRegistrarErrorCodigoExiste() throws Exception {
                String codigoPlan = "2013040702";
		selenium.open("/");
		selenium.click("link=Plan");
		selenium.waitForPageToLoad("30000");
		selenium.click("id=btnNuevo");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.type("id=txtCodigo", codigoPlan);
		selenium.type("id=txtNombre", "PLAN MANT IMPRESORA 01");
		selenium.click("id=btnAgregar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.type("id=txtActividadDesc", "LIMPIEZA CABEZAL");
		selenium.select("id=ddlTipoActividad", "label=LIMPIEZA");
		selenium.type("id=ntbPersRequ", "1");
		selenium.type("id=ntbTiempoDura", "1");
		selenium.select("id=ddlTiempoUnme", "label=horas");
		selenium.select("id=ddlPrioridad", "label=Media");
		selenium.select("id=ddlFrecuencia", "label=Quincenal");
		selenium.click("id=btnAceptar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnGrabar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		assertFalse(selenium.isTextPresent("Error"));
	}
}
