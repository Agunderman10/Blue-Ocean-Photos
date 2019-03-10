namespace BlueOceanPhotos
{
    using System.Windows;
    
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();

        public MainWindow()
        {
            //set this data context to the mainwindowviewmodel
            this.DataContext = _mainWindowViewModel;
            InitializeComponent();
        }
    }
}
