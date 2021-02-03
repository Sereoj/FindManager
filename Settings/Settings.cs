using System;
using System.Xml.Serialization;

namespace SettingsManager
{
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
