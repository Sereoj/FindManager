using System.IO;

namespace FindManager
{
    public class DirectoryManager
    {
        /*
         * TODO: Класс для псевдо-работы с папками.
         * Базовый класс
         * Такие легкие действия, как создать, проверить, удалить. Без какой-то либо проверки!
         */

        /*
         * Создание папки
         * 
         */
        public void CreateDirectory(string Path)
        {
            Directory.CreateDirectory(Path);
        }
        /*
         * Проверка директории
         */
        public bool IsPathExists(string Path)
        {
            return !Directory.Exists(Path) ? true : false;
        }

        public void DeleteDirectory(string Path)
        {
            Directory.Delete(Path);
        }




    }
}
