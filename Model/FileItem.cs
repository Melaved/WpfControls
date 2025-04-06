using CommunityToolkit.Mvvm.ComponentModel;

namespace Model
{
    /// <summary>
    /// Класс, представляющий файл в приложении.
    /// </summary>
    public partial class FileItem : ObservableObject
    {
        /// <summary>
        /// Полный путь к файлу.
        /// </summary>
        [ObservableProperty]
        private string _filePath;

        /// <summary>
        /// Получает имя файла (без пути).
        /// </summary>
        public string Name => Path.GetFileName(FilePath);

        /// <summary>
        /// Определяет, является ли файл допустимым для работы с приложением.
        /// </summary>
        public bool IsValid => Path.GetExtension(FilePath) is ".exe" or ".dll";
    }
}
