using System.Windows;

namespace BlueOceanPhotos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();

        public MainWindow()
        {
            this.DataContext = _mainWindowViewModel;
            InitializeComponent();
        }
    }
}
