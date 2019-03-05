namespace BlueOceanPhotos
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using System.Diagnostics;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private Members
        private BitmapImage _chosenImage;
        #endregion
        #region Constructors
        public MainWindowViewModel()
        {
            //sleep for 3 seconds so we can show splash screen
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

        public ICommand OpenImageCommand
        {
            get { return new DelegateCommand(OpenImage); }
        }

        #endregion
        #region Private Methods
        //creates blank bitmap so user can draw on it
        private void CreateNewImage()
        {
            _chosenImage = new BitmapImage();
            Uri blankUri = new Uri("Images/EmptyImage.png", UriKind.Relative);
            _chosenImage.BeginInit();
            _chosenImage.UriSource = blankUri;
            _chosenImage.EndInit();
            OnPropertyChanged(nameof(ChosenImage));
        }

        //opens file explorer so user can choose photo they want to open
        private void OpenImage()
        {
            //open file explorer
            Process.Start("explorer.exe");
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