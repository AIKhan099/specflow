using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    enum ProperType
    {
        Id,
        Name,
        X_Path,

    }


    internal class propertiesCollection
    {
        public static IWebDriver driver { get; set; }
    }
}
