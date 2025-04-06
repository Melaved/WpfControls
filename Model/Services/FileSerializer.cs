using Newtonsoft.Json;

namespace Model.Services
{
    /// <summary>
    /// Класс для сериализации и десериализации списка файлов в формате JSON.
    /// </summary>
    public static class FileSerializer
    {
        /// <summary>
        /// Путь к файлу, в который сохраняются контакты.
        /// </summary>
        private static readonly string _JsonFilePath;

        /// <summary>
        /// Статический конструктор для инициализации пути к файлу.
        /// </summary>
        static FileSerializer()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var contactsFolder = Path.Combine(appDataPath, "Contacts");
            Directory.CreateDirectory(contactsFolder);
            _JsonFilePath = Path.Combine(contactsFolder, "contacts.json");
        }

        /// <summary>
        /// Сохраняет список контактов в файл в формате JSON.
        /// </summary>
        /// <param name="contacts">Список контактов для сохранения.</param>
        public static void SaveFiles(IEnumerable<FileItem> contacts)
        {
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(_JsonFilePath, json);
        }

        /// <summary>
        /// Загружает список файлов из файла JSON.
        /// </summary>
        /// <returns>
        /// Возвращает список файлов, если файл существует и успешно десериализован.
        /// В противном случае возвращает пустой список.
        /// </returns>
        public static List<FileItem> LoadFiles()
        {
            if (File.Exists(_JsonFilePath))
            {
                var json = File.ReadAllText(_JsonFilePath);
                return JsonConvert.DeserializeObject<List<FileItem>>(json);
            }

            return new List<FileItem>();
        }
    }
}
