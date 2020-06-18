using SettingsManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FindManagerLib
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

        /*
         * Output Message for UI
         */
        private string findmessage;

        private string FindMessage {
            get
            {
                return findmessage;
            }
            set
            {
                findmessage = value;
            }
         }

        /*
         * DeleteDefaultDirectory - Удаление начальной папки после сортировки.
         */
        private bool DeleteDefaultDirectory { get; set; }

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
            if (string.IsNullOrWhiteSpace(default_path))
                throw new ArgumentNullException(default_path, "Default path is NULL.");
            if (string.IsNullOrWhiteSpace(path_output))
                throw new ArgumentNullException(path_output, "Output path is NULL.");


            if ((IsPathExists(default_path) && IsPathExists(path_output)) != true)
            {
                DEFAULT_PATH = default_path;
                OUTPUT_PATH = path_output;
                DeleteDefaultDirectory = deleteOutputDirectory;

                CreateDirectory(default_path); // Создаем, если пользователь указал неверный первичный путь
                CreateDirectory(path_output); // Создаем, если пользователь указал неверно вторичный путь.
            }
        }

        /*
        * Поиск файлов небезопасный, получение данных исключительно от программы.
        * Первая функция.
        */
        public bool SearchFiles(List<Setting> Files, ModeFile modeFile)
        {
            foreach ( var file in Files )
            {
                SearchFiles(file.Catalog, file.Extension, modeFile);
            }
            return false;
        }

        /*
        * Поиск файлов небезопасный, получение данных исключительно от программы.
        * Вторая функция.
        */
        public bool SearchFiles(string PathNewDirectory, string PatternExtension, ModeFile modeFile)
        {
            var NewDirectory = OUTPUT_PATH + PathNewDirectory + @"\";
            if(IsPathExists(NewDirectory))
            CreateDirectory(NewDirectory);

            foreach (var GetAllFiles in Directory.GetFiles(DEFAULT_PATH, PatternExtension.ToLower(), SearchOption.TopDirectoryOnly))
            {
                try
                {
                    var GetExtension = Path.GetExtension(GetAllFiles);
                    if (GetExtension != null && PatternExtension.Contains(GetExtension.ToLower()) && GetExtension.Length > 0)
                    {
                        FileInfo InfoFile = new FileInfo(GetAllFiles);
                        if (!File.Exists(Path.Combine(NewDirectory, InfoFile.Name)))
                        {
                            switch (modeFile)
                            {
                                case ModeFile.Copy:
                                    InfoFile.CopyTo(Path.Combine(NewDirectory, InfoFile.Name), true);
                                    break;
                                case ModeFile.Move:
                                    InfoFile.MoveTo(Path.Combine(NewDirectory, InfoFile.Name));
                                    break;
                                case ModeFile.Ignore:
                                    break;
                            }

                            return true;
                        }
                    }
                }
                catch (ArgumentException Message)
                {
                    FindMessage = Message.Message;

                }
            }
            FindMessage = "Success";
            if (DeleteDefaultDirectory != false)
                DeleteDirectory(DEFAULT_PATH); // Удаление начальной папки

            return false;
        }
        public override string ToString()
        {
            return FindMessage;
        }
    }
}
