using System;
using System.IO;

namespace FindManager
{
    /*
     * 
     * Поиск файлов по определенным расширениям документов.
     * 
     */
    public class FindManager : DirectoryManager
    {
        /*
         * Path - основной путь
         * DEFAULT_PATH - Начальный path, откуда будем брать файлы. 
         * OUTPUT_PATH - Конечный path, где будем создать директории и перекидывать файлы.
         */
        private string DEFAULT_PATH { get; set; }
        private string OUTPUT_PATH { get; set; }



        private bool DeleteOutputDirectory{get;set; }

        public enum ModeFile : byte
        {
            Copy, // Копирование
            Move, // Перемещение
            Ignore // Игнорирование, использование в качестве тестирования функционала, игнорирования работы с файлами. 
        }

        /*
         * Конструктор класса FindManager.
         * Получение директории по выбору пользователя. 
         * Проверка на безопасность. 
         */

        public FindManager(string default_path, string path_output, bool deleteOutputDirectory = false)
        {
            if(string.IsNullOrWhiteSpace(default_path))
                throw new ArgumentNullException(default_path, "Default path is NULL.");
            if (string.IsNullOrWhiteSpace(path_output))
                throw new ArgumentNullException(path_output, "Output path is NULL.");


            if ((IsPathExists(default_path) && IsPathExists(path_output)) != true)
            {
                DEFAULT_PATH = default_path;
                OUTPUT_PATH = path_output;
                DeleteOutputDirectory = deleteOutputDirectory;

                CreateDirectory(default_path); // Создаем, если пользователь указал неверный первичный путь
                CreateDirectory(path_output); // Создаем, если пользователь указал неверно вторичный путь.
            }
        }


         /*
         * Поиск файлов небезопасный, получение данных исключительно от программы.
         */
        public void SearchFiles(string PathNewDirectory, string PatternExtension, ModeFile modeFile)
        {
            foreach (var GetAllFiles in Directory.GetFiles(DEFAULT_PATH, "*.*".ToLower(), SearchOption.TopDirectoryOnly))
            {
                try
                {
                    var GetExtension = Path.GetExtension(GetAllFiles);
                    if (GetExtension != null && PatternExtension.Contains(GetExtension.ToLower()) && GetExtension.Length > 0)
                    {
                        FileInfo InfoFile = new FileInfo(GetAllFiles);
                        if (!File.Exists(Path.Combine(PathNewDirectory, InfoFile.Name)))
                        {
                            switch (modeFile)
                            {
                                case ModeFile.Copy:
                                    InfoFile.CopyTo(Path.Combine(PathNewDirectory, InfoFile.Name), true);
                                    break;
                                case ModeFile.Move:
                                    InfoFile.MoveTo(Path.Combine(PathNewDirectory, InfoFile.Name));
                                    break;
                                case ModeFile.Ignore:
                                    break;
                            }
                        }
                    }
                }
                catch (ArgumentException Message)
                {

                    throw new ArgumentException(Message.Message); //Выводим ошибку
                    
                }
            }
            
            if(DeleteOutputDirectory != false)
                DeleteDirectory(OUTPUT_PATH); // Удаление начальной папки
        }
    }
}
