namespace BlueOceanPhotos
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using System.Diagnostics;
    using System.Windows;
    using Microsoft.Win32;

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

        public ICommand NewImageCommand
        {
            get { return new DelegateCommand(NewImage); }
        }

        public ICommand OpenImageCommand
        {
            get { return new DelegateCommand(OpenImage); }
        }

        #endregion
        #region Private Methods
        //creates blank bitmap so user can draw on it
        private void NewImage()
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
            //open the file explorer so user can choose the photo they want to open
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            //if we can open the image, open it in our application
            if (openFileDialog.ShowDialog() == true)
            {
                ChosenImage = new BitmapImage();
                Uri openedImageUri = new Uri(openFileDialog.FileName);
                ChosenImage.BeginInit();
                ChosenImage.UriSource = openedImageUri;
                ChosenImage.EndInit();
                OnPropertyChanged(nameof(ChosenImage));
            }
            else
            {
                //show error message if we can't open image
                MessageBox.Show("Error importing photo!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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