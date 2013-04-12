package test.tmd.gm;

import org.junit.Test;
import static org.junit.Assert.*;

public class OrdenTrabajoTest extends BaseTest{
    
	@Test
	public void testOrdenTrabajo() throws Exception {
		selenium.open("/OrdenTrabajo/OrdenTrabajoConsulta");
		selenium.click("id=btnNuevo");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("//div[@id='divOTGenerar']/fieldset/fieldset/span[2]/span/span");
		selenium.click("link=1");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("xpath=(//button[@id='btnBuscar'])[2]");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=checkboxEqui4");
		selenium.click("css=span.k-icon.k-i-arrow-e");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=checkboxActi1");
		selenium.click("id=checkboxActi2");
		selenium.click("id=btnAsignar");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("link=Ver");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("//div[10]/div/a/span");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("link=Asignar");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("css=div.k-block > fieldset > fieldset.fieldset_left > button.k-button");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("xpath=(//button[@id='btnBuscar'])[2]");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("link=Seleccionar");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("css=div.divLoading");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnSeleccionar");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnGenerar");
                selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		assertTrue(selenium.getConfirmation().matches("^¿Está seguro de generar las Órdenes[\\s\\S]$"));
	}
}
