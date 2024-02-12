using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using RestSharp;
using System.Net;

namespace ERM.StepDefinitions
{
    [Binding]
    public class UpworkTest
    {
        loginPageObjects loginObjects = new loginPageObjects();

        IWebDriver driver;

        public UpworkTest(IWebDriver driver)
        {
            this.driver = driver;

        }

        // Scenario #1 
        [Given(@"I am at VCC login page\.")]
        public void GivenIAmAtVCCLoginPage_()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.google.com/");
                Console.WriteLine("Open Url");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }



        [Given(@"I am at home page\.")]
        public void GivenIAmAtHomePage_()
        {
           
            driver.Navigate().GoToUrl(loginObjects.url);
            Console.WriteLine("Open Url");
            //Thread.Sleep(3000);
        }

        [When(@"I click on orders\.")]
        public void WhenIClickOnOrders_()
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.OrdersXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element:loginObjects.OrdersXpath, elementType:ProperType.X_Path,driver:driver);
            
        }

        [When(@"I deleted the record with ""([^""]*)"" Accession Number\.")]
        public void WhenIDeletedTheRecordWithAccessionNumber_(string p0)
        {

            try
            {
                seleniumSetMethod.ExplicitWait(element: String.Format(loginObjects.RowCross, p0), elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: String.Format(loginObjects.RowCross, p0), ProperType.X_Path, driver: driver);
                Thread.Sleep(5000);
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);
            }
            catch(Exception e) { }
            
        }

        [When(@"I click on Create New Button\.")]
        public void WhenIClinkOnCreateNewButton_()
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.CreateNewXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: loginObjects.CreateNewXpath, ProperType.X_Path, driver: driver);
            
        }

        [When(@"I enter ""([^""]*)"" at mrn input bar\.")]
        public void WhenIEnterAtMrnInputBar_(string p0)
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.MrnInputbarId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: loginObjects.MrnInputbarId, ProperType.Id, value:p0,driver: driver);
        }

        [When(@"I enter ""([^""]*)"" in first name input bar\.")]
        public void WhenIEnterInFirstNameInputBar_(string awais)
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.FstNmeInpId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: loginObjects.FstNmeInpId, ProperType.Id, value: awais, driver: driver);
        }

        [When(@"I enter ""([^""]*)"" in last name inout bar\.")]
        public void WhenIEnterInLastNameInoutBar_(string imran)
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.LstNmeInpId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: loginObjects.LstNmeInpId, ProperType.Id, value: imran, driver: driver);

        }

        [When(@"I enter ""([^""]*)"" in accession number input bar\.")]
        public void WhenIEnterInAccessionNumberInputBar_(string p0)
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.AccNumId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: loginObjects.AccNumId, ProperType.Id, value: p0, driver: driver);
            
        }

        [When(@"I select Lumus organization\.")]
        public void WhenISelectLumusOrganization_()
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.OrgCodeDrpDwnId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.SelectDropDown(element: loginObjects.OrgCodeDrpDwnId, ProperType.Id, value:loginObjects.LumOptnText, driver: driver);

        }

        [When(@"I select Northern Beaches Hospital in site id drop down\.")]
        public void WhenISelectNorthernBeachesHospitalInSiteIdDropDown_()
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.SiteDrpDwnId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.SelectDropDown(element: loginObjects.SiteDrpDwnId, ProperType.Id, value: loginObjects.BeachOptnText, driver: driver);

        }
        [When(@"I select the MRI modality\.")]
        public void WhenISelectTheMRIModality_()
        {
            seleniumSetMethod.ExplicitWait(element: loginObjects.ModalityDrpDwnId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.SelectDropDown(element: loginObjects.ModalityDrpDwnId, ProperType.Id, value: loginObjects.MriOprionText, driver: driver);
            Thread.Sleep(2000);
        }


        

        [When(@"I enter the date ""([^""]*)"" and time ""([^""]*)"" from the calender\.")]
        public void WhenIEnterTheDateAndTimeFromTheCalender_(string p0, string p1)
        {
            
            seleniumSetMethod.ExplicitWait(element: loginObjects.CalenderId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: loginObjects.CalenderId, ProperType.Id, value: p0, driver: driver);
            IWebElement dd = driver.FindElement(By.Id(loginObjects.CalenderId));
            dd.SendKeys(Keys.Tab);

            seleniumSetMethod.EnterText(element: loginObjects.CalenderId, ProperType.Id, value: p1, driver: driver);
            Thread.Sleep(2000);
        }

        [When(@"I enter the submit button\.")]
        public void WhenIEnterTheSubmitButton_()
        {
            seleniumSetMethod.Click(element: loginObjects.SubmitBtnXpath, ProperType.X_Path, driver: driver);
            Thread.Sleep(10000);
        }

        
        [Given(@"I send the Get request to get all the orders\.")]
        public void GivenISendTheGetRequestToGetAllTheOrders_()
        {
            RestClient client = new RestClient("https://localhost:44449");
            RestRequest request = new RestRequest("api/Orders", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Given(@"I send the Get request to get all the patients\.")]
        public void GivenISendTheGetRequestToGetAllThePatients_()
        {
            RestClient client = new RestClient("https://localhost:44449");
            RestRequest request = new RestRequest("api/Patients", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }



    }
}
