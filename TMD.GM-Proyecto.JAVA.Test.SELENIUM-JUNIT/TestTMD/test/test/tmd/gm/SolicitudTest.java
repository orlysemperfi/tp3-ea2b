package test.tmd.gm;

import org.junit.Test;
import static org.junit.Assert.*;

public class SolicitudTest extends BaseTest{
        
        @Test
	public void test1SolicitudRegistrarOK() throws Exception {
                System.out.println("CASO1: REGISTRO EXITOSO");
		selenium.open("/");
		selenium.click("link=Solicitud");
		selenium.waitForPageToLoad("30000");
		selenium.click("id=btnNuevo");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.type("id=dpFechaFin", "08/12/2013");
		selenium.type("id=txtNumDocuRefe", "123456");
		selenium.click("id=btnBuscarEquipoSolicitud");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnBuscarEquipos");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("link=Seleccionar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnGrabar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		assertFalse("Error!!!. Equipo ya asociado",selenium.isTextPresent("Error"));
	}

	@Test
	public void test2SolicitudRegistrarErrorEquipoYaAsociado() throws Exception {
                System.out.println("CASO2: REGISTRO ERROR EQUIPO YA ASOCIADO");
		selenium.open("/");
		selenium.click("link=Solicitud");
		selenium.waitForPageToLoad("30000");
		selenium.click("id=btnNuevo");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.type("id=dpFechaFin", "08/12/2013");
		selenium.type("id=txtNumDocuRefe", "123456");
		selenium.click("id=btnBuscarEquipoSolicitud");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnBuscarEquipos");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("link=Seleccionar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnGrabar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		assertTrue("Error!!!. Equipo ya asociado",selenium.isTextPresent("Error"));
	}
        
        @Test
	public void test3SolicitudAnular() throws Exception {
		selenium.open("/");
		selenium.click("link=Solicitud");
		selenium.waitForPageToLoad("30000");
		selenium.click("id=btnBuscarEquipo");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnBuscarEquipos");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("link=Seleccionar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("id=btnBuscar");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		selenium.click("link=Anular");
		selenium.waitForCondition("selenium.browserbot.getCurrentWindow().$.active == 0", "5000");
		assertTrue(selenium.getConfirmation().matches("^¿Está seguro de eliminar el registro[\\s\\S]$"));
	}
	
}
