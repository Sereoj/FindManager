using FindManagerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SettingsManager;

namespace TestFindMananger
{
    [TestClass]
    public class App1
    {


        [TestMethod]
        public void TestMovingFiles()
        {
            var FirstDirectory = @"C:\Users\Admin\Desktop\Test\";
            var SecondDirectory = @"C:\Users\Admin\Desktop\Test\";

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

        //    foreach(var file in Files  )
        //    {
         //       _method1_TestArgsException = new FindManager(FirstDirectory, SecondDirectory, false).SearchFiles(file.Catalog, file.Extension, modeFile: FindManager.ModeFile.Ignore);
         //   }


            /*
             * type 2
             */
            var _method2_TestArgsException = new FindManager(FirstDirectory, SecondDirectory, false).SearchFiles(Files, modeFile: FindManager.ModeFile.Copy);

           // Assert.IsTrue(_method1_TestArgsException);
            Assert.IsTrue(_method2_TestArgsException);
            //Assert.IsNotNull(_method2_TestArgsException);



        }
    }
}
