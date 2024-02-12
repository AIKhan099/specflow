using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using ERM.supportClasses;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using SeleniumExtras.WaitHelpers;
namespace ConsoleApp1

{
    [Binding]
    internal class seleniumSetMethod
    {
        public static object SeleniumExtras { get; private set; }
        public static object ExpectedConditions { get; private set; }

        /* 
        This method sends/types string in the input field.
        arguments:
        driver  : it will take the current running state of browser.
        element : it take the element that could be either, id, name or X_path.
        elementType : It takes the type of element such as id, name or x-path.
        */




        public static void EnterText( string element, ProperType elementType, string value, IWebDriver driver)
        {
            /*
             This method enters the value/text in the input bar.
             */
            if (elementType == ProperType.Id)
            {
                
                driver.FindElement(By.Id(element)).SendKeys(value);
            }
            if (elementType == ProperType.Name)
            {
                driver.FindElement(By.Name(element)).SendKeys(value);
            }
            if (elementType == ProperType.X_Path)
            {
                driver.FindElement(By.XPath(element)).SendKeys(value);
            }
        }

        public static void Click( string element, ProperType elementType, IWebDriver driver) 
        {
            /*
             This method clicks any clickable element.
             */

            if (elementType == ProperType.Id)
            {
                driver.FindElement(By.Id(element)).Click();
            }
            if (elementType == ProperType.Name)
            {
                driver.FindElement(By.Name(element)).Click();
            }
            if (elementType == ProperType.X_Path)
            {
                driver.FindElement(By.XPath(element)).Click();
            }

        }

        public static string GetText(string element, ProperType elementType, IWebDriver driver)
        {
            /*
             This method gets the text.
             */

            if (elementType == ProperType.Id)
            {
                IWebElement Text_WE = driver.FindElement(By.Id(element));
                string text = Text_WE.Text;
                return text;
            }
            else if (elementType == ProperType.Name)
            {
                //return driver.FindElement(By.Name(element)).Text;
                IWebElement Text_WE = driver.FindElement(By.Name(element));
                string text = Text_WE.Text;
                return text;
            }
            else if(elementType == ProperType.X_Path)
            {
                //return driver.FindElement(By.XPath(element)).Text;
                IWebElement Text_WE = driver.FindElement(By.XPath(element));
                string text = Text_WE.Text;
                return text;
            }

            else
            {
                return "Wrong Property Type";
            }

        }

        public static void ExplicitWait(string element, ProperType elementType, IWebDriver driver)
        {
            if (elementType == ProperType.X_Path)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement firstResult = wait.Until(driver => driver.FindElement(By.XPath(element)));
            }
            if (elementType == ProperType.Id)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement firstResult = wait.Until(driver => driver.FindElement(By.Id(element)));
            }
            if (elementType == ProperType.Name)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement firstResult = wait.Until(driver => driver.FindElement(By.Name(element)));
            }
        }


        public static void SelectDropDown( string element, ProperType elementType, string value, IWebDriver driver)
        {
            /*
                This method select the drop down.

                Here, you will find a bit different approach. SelectElement (which is OpenQA.Selenium.Support.UI supported)
                actually takes in IWebElement. And, driver.FindElement(By.Id(element)) actually returns IWebElement.
                
             */

            if (elementType == ProperType.Id)
            {
                //new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
                new SelectElement(driver.FindElement(By.Id(element))).SelectByValue(value);
            }
            if (elementType == ProperType.Name)
            {
                new SelectElement(driver.FindElement(By.Name(element))).SelectByValue(value);
            }
            if (elementType == ProperType.X_Path)
            {
                new SelectElement(driver.FindElement(By.XPath(element))).SelectByValue(value);
            }

        }

    }
}
