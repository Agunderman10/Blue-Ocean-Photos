namespace BlueOceanPhotos
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        //pass the file name, object of the mainWindowViewModel and an object of this to the RenameWindowViewModel
        public RenameWindow(string fileName, MainWindowViewModel mainWindowViewModel)
        {
            RenameWindowViewModel _renameWindowViewModel = new RenameWindowViewModel(fileName, mainWindowViewModel, this);
            this.DataContext = _renameWindowViewModel;

            InitializeComponent();
        }
    }
}
