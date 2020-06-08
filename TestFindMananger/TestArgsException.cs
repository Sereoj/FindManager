using FindManagerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SettingsManager;
using System.Collections.Generic;


namespace TestFindMananger
{

    [TestClass]
    public class App
    {
        private bool _method1_TestArgsException;
        private bool _method2_TestArgsException;

        [TestMethod]
        public void TestArgsException()
        {
            var FirstDirectory = "";
            var SecondDirectory = "";

            var Files = new List<Setting>
            {
                new Setting()
                {
                    Catalog = "Text Files",
                    Extension = "*.txt"
                },
                new Setting()
                {
                    Catalog = "Others",
                    Extension = "*.txt1, *.txt1"
                }

            };

            /*
             * Тест на TestArgsException 
             */
            _method1_TestArgsException = new FindManager(FirstDirectory, SecondDirectory, false).SearchFiles("", "", FindManager.ModeFile.Ignore);

            _method2_TestArgsException = new FindManager("", "", false).SearchFiles(Files, modeFile: FindManager.ModeFile.Ignore); //Тест на TestArgsException 

        }

        /*
         * Валидация на Null
         */
        [TestMethod]
        public void CheckerIsNull()
        {
            Assert.IsNotNull(_method1_TestArgsException);
            Assert.IsNotNull(_method2_TestArgsException);
        }
    }
}
