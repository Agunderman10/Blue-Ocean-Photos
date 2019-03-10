namespace BlueOceanPhotos
{
    using System.Windows.Media.Imaging;

    public class ImageWindowViewModel
    {
        private BitmapImage _originalImage;

        public ImageWindowViewModel(BitmapImage originalImage)
        {
            this._originalImage = originalImage;
        }

        public BitmapImage OriginalImage
        {
            get { return this._originalImage; }
            set
            {
                if(this._originalImage != value)
                {
                    this._originalImage = value;
                }
            }
        }
    }
}
