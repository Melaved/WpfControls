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
        private static readonly string _jsonFilePath;

        /// <summary>
        /// Статический конструктор для инициализации пути к файлу.
        /// </summary>
        static FileSerializer()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var wpfControlsFolder = Path.Combine(appDataPath, "WpfControls");
            Directory.CreateDirectory(wpfControlsFolder);
            _jsonFilePath = Path.Combine(wpfControlsFolder, "wpfcontrols.json");
        }

        /// <summary>
        /// Сохраняет список контактов в файл в формате JSON.
        /// </summary>
        /// <param name="files">Список файлов для сохранения.</param>
        public static void SaveFiles(IEnumerable<FileItem> files)
        {
            var json = JsonConvert.SerializeObject(files, Formatting.Indented);
            File.WriteAllText(_jsonFilePath, json);
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
            if (File.Exists(_jsonFilePath))
            {
                var json = File.ReadAllText(_jsonFilePath);
                return JsonConvert.DeserializeObject<List<FileItem>>(json);
            }

            return new List<FileItem>();
        }
    }
}
