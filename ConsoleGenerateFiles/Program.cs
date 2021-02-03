using System;
using System.IO;
using FindManagerLib;

namespace ConsoleGenerateFiles
{
    class Program
    {
        private const string PATH = @"C:\Users\Admin\Desktop\Test";

        static void Main(string[] args)
        {
            Console.WriteLine("Укажите количество файлов для тестирования:");


            if( int.TryParse( Console.ReadLine(), out int num ) && num > 0  )
            {
                if (!PATH.IsPathExists())
                {
                    PATH.CreateDirectory();
                    for(int index = 1; index <= num ; index++)
                        File.Create(Path.Combine(PATH + @"\\", $"file{index}.txt"));
                }

            }
            else
            {
                Console.WriteLine("Обнаружена ошибка!\n{0}", new Exception().Message);
            }
            Console.ReadLine();
        }
    }
}
