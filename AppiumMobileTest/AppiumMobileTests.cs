

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects;

namespace AppiumMobileTests
{
    public class AppiumMobileTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\contactbook-androidclient.apk";
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]

        public void OpenApp()
        {
            
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
        }

        [TearDown]

        public void CloseApp() 
        { 
              driver.Quit();
        }

        [Test]

        public void Test_SearchAssertContact()
        {
            var inputUrlField = driver.FindElementById("contactbook.androidclient:id/editTextApiUrl");
            inputUrlField.Clear();
            inputUrlField.SendKeys("https://contactbook.velio4ka.repl.co/api");

            var buttonConnect = driver.FindElementById("contactbook.androidclient:id/buttonConnect");
            buttonConnect.Click();

            Thread.Sleep(3000);

            var inputSearchField = driver.FindElementById("contactbook.androidclient:id/editTextKeyword");
            inputSearchField.SendKeys("steve");

            var searchButton = driver.FindElementById("contactbook.androidclient:id/buttonSearch");
            searchButton.Click();

            Thread.Sleep(3000);

            var fieldFirstName = driver.FindElementById("contactbook.androidclient:id/textViewFirstName");
            var fieldLastName = driver.FindElementById("contactbook.androidclient:id/textViewLastName");

            Assert.That(fieldFirstName.Text, Is.EqualTo("Steve"));
            Assert.That(fieldLastName.Text, Is.EqualTo("Jobs"));

        }


    }
}