using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;

namespace ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<FileItem> Files { get; } = new();

        [RelayCommand]
        private void AddFiles(IEnumerable<string> filePaths)
        {
            foreach (var path in filePaths)
            {
                if (!Files.Any(f => f.FilePath == path))
                {
                    Files.Add(
                        new FileItem
                        {
                            FilePath = path
                        });
                }
            }
        }

        [RelayCommand]
        private void RemoveFile(FileItem file)
        {
            if (file != null && Files.Contains(file))
            {
                Files.Remove(file);
            }
        }
    }
}
