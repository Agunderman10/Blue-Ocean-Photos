namespace BlueOceanPhotos
{
    using System.Threading;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;

    public class MainWindowViewModel
    {
        #region Private Members
        private BitmapImage _chosenImage;
        #endregion
        #region Constructors
        public MainWindowViewModel()
        {
            Thread.Sleep(3000);
        }
        #endregion
        #region Public Properties
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

        public ICommand NewImage
        {
            get { return new DelegateCommand(CreateNewImage); }
        }
        #endregion
        #region Private Methods
        private void CreateNewImage()
        {
            
        }
        #endregion
    }
}