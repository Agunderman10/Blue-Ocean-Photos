namespace BlueOceanPhotos
{
    using System.Windows;
    using System.Windows.Media.Imaging;
    
    public partial class ImageWindow : Window
    {
        ImageWindowViewModel imageWindowViewModel;

        public ImageWindow(BitmapImage originalImage)
        {
            //create object of the View Model and set this data context to it, pass the image so we can display it through
            //our View Model
            imageWindowViewModel = new ImageWindowViewModel(originalImage);
            this.DataContext = imageWindowViewModel;

            InitializeComponent();
        }
    }
}
