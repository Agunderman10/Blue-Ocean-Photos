namespace BlueOceanPhotos
{
    using System.Windows.Media.Imaging;

    public class FullScreenWindowViewModel
    {
        private BitmapImage _chosenImage;

        public FullScreenWindowViewModel(BitmapImage chosenImage)
        {
            this._chosenImage = chosenImage;
        }

        public BitmapImage ChosenImage
        {
            get { return this._chosenImage; }
            set
            {
                if(this._chosenImage != value)
                {
                    this._chosenImage = value;
                }
            }
        }
    }
}
