namespace BlueOceanPhotos
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;

    public class MainWindowViewModel : INotifyPropertyChanged
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
            _chosenImage = new BitmapImage();
            Uri blankUri = new Uri("Images/EmptyImage.png", UriKind.Relative);
            _chosenImage.BeginInit();
            _chosenImage.UriSource = blankUri;
            _chosenImage.EndInit();
            OnPropertyChanged(nameof(ChosenImage));
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}