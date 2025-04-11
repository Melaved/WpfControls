using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using Model.Services;

namespace ViewModel
{
    /// <summary>
    /// Класс, представляющий основную ViewModel приложения.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Возвращает коллекцию файлов.
        /// Инициализируется данными из файла при создании ViewModel.
        /// </summary>
        public ObservableCollection<FileItem> Files { get; } = new (FileSerializer.LoadFiles());


        /// <summary>
        /// Команда для добавления файлов в коллекцию.
        /// </summary>
        /// <param name="filePaths">Коллекция путей к добавляемым файлам.</param>
        [RelayCommand]
        public void AddFiles(IEnumerable<string> filePaths)
        {

            foreach (var path in filePaths)
            {
                // TODO: использовать All, назвать нормально аргумент лямбда функции.(completed)
                if (Files.Count == 0 || Files.All(file => file.FilePath != path))
                {
                    Files.Add(new FileItem { FilePath = path });
                }
            }
            FileSerializer.SaveFiles(Files);
        }

        /// <summary>
        /// Команда для удаления файла из коллекции.
        /// </summary>
        /// <param name="file">Экземпляр <see cref="FileItem"/> для удаления.</param>
        [RelayCommand]
        private void RemoveFile(FileItem file)
        {
            if (file != null && Files.Contains(file))
            {
                Files.Remove(file);
                FileSerializer.SaveFiles(Files);
            }
        }
    }
}
