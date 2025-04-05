using CommunityToolkit.Mvvm.ComponentModel;

namespace Model
{
    public partial class FileItem : ObservableObject
    {
        /// <summary>
        /// Хранит путь к файлу.
        /// </summary>
        [ObservableProperty]
        private string _filePath;

        /// <summary>
        /// Возвращает имя файла.
        /// </summary>
        public string Name => Path.GetFileName(FilePath);

        public bool IsValid => Path.GetExtension(FilePath) is ".exe" or ".dll";
    }
}
