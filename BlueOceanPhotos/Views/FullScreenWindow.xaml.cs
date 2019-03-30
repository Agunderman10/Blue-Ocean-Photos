namespace BlueOceanPhotos
{
    using System.Windows;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for FullScreenWindow.xaml
    /// </summary>
    public partial class FullScreenWindow : Window
    {
        //pass the chosen image to the FullScreenWindowViewModel and set DataContext
        public FullScreenWindow(BitmapImage chosenImage)
        {
            FullScreenWindowViewModel fullScreenWindowViewModel = new FullScreenWindowViewModel(chosenImage);
            this.DataContext = fullScreenWindowViewModel;

            InitializeComponent();
        }
    }
}
