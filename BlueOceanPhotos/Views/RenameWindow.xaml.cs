namespace BlueOceanPhotos
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        private string _fileName;
        private MainWindowViewModel _mainWindowViewModel;

        public RenameWindow(string fileName, MainWindowViewModel mainWindowViewModel)
        {
            this._fileName = fileName;
            this._mainWindowViewModel = mainWindowViewModel;
            RenameWindowViewModel _renameWindowViewModel = new RenameWindowViewModel(_fileName, _mainWindowViewModel, this);
            this.DataContext = _renameWindowViewModel;
            InitializeComponent();
        }
    }
}
