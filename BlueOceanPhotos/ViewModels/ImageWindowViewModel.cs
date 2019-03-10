namespace BlueOceanPhotos
{
    using System.Windows.Media.Imaging;

    public class ImageWindowViewModel
    {
        private BitmapImage _originalImage;
        private double _imageHeight;
        private double _imageWidth;

        public ImageWindowViewModel(BitmapImage originalImage)
        {
            this._originalImage = originalImage;
            
            //set image height and width equal to the original image's height and width
            ImageHeight = OriginalImage.Height;
            ImageWidth = OriginalImage.Width;
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

        public double ImageHeight
        {
            get { return this._imageHeight; }
            set
            {
                if(this._imageHeight != value)
                {
                    this._imageHeight = value;
                }
            }
        }

        public double ImageWidth
        {
            get { return this._imageWidth; }
            set
            {
                if(this._imageWidth != value)
                {
                    this._imageWidth = value;
                }
            }
        }
    }
}
