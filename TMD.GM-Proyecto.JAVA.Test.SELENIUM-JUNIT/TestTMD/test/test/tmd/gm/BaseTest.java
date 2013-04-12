package test.tmd.gm;

import com.thoughtworks.selenium.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;
import java.util.regex.Pattern;
import org.junit.AfterClass;
import org.junit.BeforeClass;

public class BaseTest {
    
	protected static Selenium selenium;

	@BeforeClass
	public static void setUp() throws Exception {
            	selenium = new DefaultSelenium("localhost", 4444, "*firefox", "http://localhost:5101/");
		selenium.start();
	}

	@AfterClass
	public static void tearDown() throws Exception {
		selenium.stop();
	}
}
