using FindManagerLib;
using SettingsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFindManager
{
    class Program
    {

        static void Main(string[] args)
        {
            var Files = new List<Setting>
            {
                new Setting(){ Catalog = "Word", Extension = "*.docx,*.dotx,*.doc,*.dot" },
                new Setting(){ Catalog = "Excel", Extension = "*.xlsx,*.xlsm,*.xltx,*.xltm,*.xlam,*.xls,*.xlt,*.xla" },
                new Setting(){ Catalog = "Access", Extension = "*.accdb,*.mdb" },
                new Setting(){ Catalog = "Image", Extension = "*.bmp,*.tif,*.jpg,*.gif,*.png,*.ico" },
                new Setting(){ Catalog = "Text files", Extension = "*.txt,*.log" },
                new Setting(){ Catalog = "Project", Extension = "*.mpp" },
                new Setting(){ Catalog = "Archive", Extension = "*.rar,*.zip,*.7z" },
                new Setting(){ Catalog = "eBook", Extension = "*.fb2,*.epub,*.mobi,*.pdf,*.djvu" },
                new Setting(){ Catalog = "Media", Extension = "*.avi,*.mp4,*.mpeg,*.wmv,*.mp3" }
            };
            Console.WriteLine("Введите первичный путь:");
            var FirstFile = Console.ReadLine();
            Console.WriteLine("Введите вторичный путь:");
            var SecondPath = Console.ReadLine();

            if ((string.IsNullOrWhiteSpace(FirstFile) && string.IsNullOrWhiteSpace(SecondPath)) != true)
            {
                var FindManager = new FindManager(FirstFile, SecondPath, false);

                Console.WriteLine("Введите значение, указывающие на метод работы с файлами:\n0 - Copy\n1 - Move\n2 - Ignore\nУказать строго цифру!");

                if(byte.TryParse( Console.ReadLine() , out byte num )  )
                {
                    switch(num)
                    {
                        case 0:
                            FindManager.SearchFiles(Files, modeFile: FindManager.ModeFile.Copy);
                            break;
                        case 1:
                            FindManager.SearchFiles(Files, modeFile: FindManager.ModeFile.Move);
                            break;
                        case 2:
                            FindManager.SearchFiles(Files, modeFile: FindManager.ModeFile.Ignore);
                            break;
                        default:
                            Console.WriteLine("Неверно указан параметр");
                            break;
                    }
                }

                while(true)
                {
                    Console.WriteLine(FindManager.ToString()); 

                    if(FindManager.ToString() == "Success")
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
