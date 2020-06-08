using System;

namespace SettingsManager
{
    [Serializable]
    public class Setting
    {
        /*
         * Catalog - название новой папки для каждого объекта
         * Extension - Расширение объектов для формирование Каталога.
         */
        public string Catalog { get; set; }
        public string Extension { get; set; }
    }

}
