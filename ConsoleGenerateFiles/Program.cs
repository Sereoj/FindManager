using System;
using System.IO;
using FindManagerLib;

namespace ConsoleGenerateFiles
{
    class Program
    {
        private const string PATH = ""; // В конце обязательно \\

        static void Main(string[] args)
        {
            var DirectoryManager = new DirectoryManager();

            Console.WriteLine("Укажите количество файлов для тестирования:");


            if( int.TryParse( Console.ReadLine(), out int num ) && num > 0  )
            {
                if(!DirectoryManager.IsPathExists(PATH) )
                {
                    DirectoryManager.CreateDirectory(PATH);
                    for(int index = 0; index <= num ; index++)
                        File.Create(Path.Combine(PATH, $"file{index}.txt"));
                }

            }
            else
            {
                Console.WriteLine("Обнаружена ошибка!\n{0}", new Exception().Message);
            }

        }
    }
}
