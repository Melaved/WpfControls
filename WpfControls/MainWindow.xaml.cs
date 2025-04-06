using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Главное окно приложения.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализирует главное окно приложения и устанавливает контекст данных.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки добавления файлов.
        /// </summary>
        /// <param name="sender">Источник события (кнопка "+").</param>
        /// <param name="e">Данные события <see cref="RoutedEventArgs"/>.</param>
        private void AddFiles_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                Filter = "All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true || DataContext is not MainViewModel vm)
                return;

            vm.AddFilesCommand.Execute(dialog.FileNames);
        }

    }
}