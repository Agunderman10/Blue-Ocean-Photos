namespace BlueOceanPhotos
{
    using System.Windows;

    public partial class RenameWindow : Window
    {
        RenameWindowViewModel renameWindowViewModel = new RenameWindowViewModel();
        public RenameWindow()
        {
            this.DataContext = renameWindowViewModel;
            InitializeComponent();
        }
    }
}
