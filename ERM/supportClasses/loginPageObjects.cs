using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.supportClasses
{
    class loginPageObjects
    {

        public string url = "https://localhost:44449/";
        public string OrdersXpath = "//a[contains(text(),\"Orders\")]";
        public string CreateNewXpath = "(//button[@type=\"button\"])[2]";
        public string RowCross = "(//tr/td[contains(text(),\"{0}\")]/following-sibling::td)[8]/i";
        public string MrnInputbarId = "mrn";
        public string FstNmeInpId = "first-name";
        public string LstNmeInpId = "last-name";
        public string AccNumId = "accession-number";
        public string OrgCodeDrpDwnId = "org-code";
        public string LumOptnText = "LUM";
        public string SiteDrpDwnId = "site-id";
        public string BeachOptnText= "101";
        public string ModalityDrpDwnId = "modality";
        public string MriOprionText = "MR";
        public string CalenderId = "study-date-time";
        public string SubmitBtnXpath = "//button[@type=\"submit\"]";
        

    }
}