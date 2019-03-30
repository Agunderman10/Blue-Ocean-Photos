namespace BlueOceanPhotos
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        public RenameWindow(string fileName, MainWindowViewModel mainWindowViewModel)
        {
            RenameWindowViewModel _renameWindowViewModel = new RenameWindowViewModel(fileName, mainWindowViewModel, this);
            this.DataContext = _renameWindowViewModel;

            InitializeComponent();
        }
    }
}
