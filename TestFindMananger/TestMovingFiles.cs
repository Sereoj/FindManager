using FindManagerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SettingsManager;
using System.Collections.Generic;

namespace TestFindMananger
{
    [TestClass]
    public class App1
    {
        private bool _method1_TestArgsException;
        private bool _method2_TestArgsException;

        [TestInitialize]
        public void TestMovingFiles()
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
             * type 1
             */

            foreach(var file in Files  )
            {
                new FindManager(FirstDirectory, SecondDirectory, false).SearchFiles(file.Catalog, file.Extension, modeFile: FindManager.ModeFile.Ignore);
            }


            /*
             * type 2
             */
            new FindManager(FirstDirectory, SecondDirectory, false).SearchFiles(Files, modeFile: FindManager.ModeFile.Ignore);


            _method1_TestArgsException = new FindManager(FirstDirectory, SecondDirectory, false).SearchFiles("", "", FindManager.ModeFile.Ignore);

            _method2_TestArgsException = new FindManager("", "", false).SearchFiles(Files, modeFile: FindManager.ModeFile.Ignore); //Тест на TestArgsException 

            Assert.AreEqual(true, _method1_TestArgsException);
            Assert.AreEqual(true, _method2_TestArgsException);



        }
    }
}
