namespace BlueOceanPhotos
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using System.Windows;
    using Microsoft.Win32;
    using System.IO;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private Members
        private BitmapImage _chosenImage;
        private Uri _chosenImageUri;
        private string _fileName;
        private BitmapImage _originalImage;
        private int rotations = 0;
        private bool imageIsSaved = false;
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
                    OnPropertyChanged(nameof(ChosenImage));
                }
            }
        }

        public string FileName
        {
            get { return this._fileName; }
            set
            {
                if(this._fileName != value)
                {
                    this._fileName = value;
                    OnPropertyChanged(nameof(FileName));
                }
            }
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

        public ICommand NewImageCommand
        {
            get { return new DelegateCommand(NewImage); }
        }

        public ICommand OpenImageCommand
        {
            get { return new DelegateCommand(OpenImage); }
        }

        public ICommand RotateImageCommand
        {
            get { return new DelegateCommand(RotateImage); }
        }

        public ICommand CloseImageCommand
        {
            get { return new DelegateCommand(CloseImage); }
        }

        public ICommand SaveImageCommand
        {
            get { return new DelegateCommand(SaveImage); }
        }

        public ICommand ViewOriginalCommand
        {
            get { return new DelegateCommand(ViewOriginalImage); }
        }

        public ICommand RenameImageCommand
        {
            get { return new DelegateCommand(RenameImage); }
        }

        public ICommand ViewFullScreenCommand
        {
            get { return new DelegateCommand(ViewFullScreen); }
        }

        #endregion
        #region Public Methods
        public void Rename(string fileName)
        {
            this.FileName = fileName;
            imageIsSaved = false;
            OnPropertyChanged(nameof(FileName));
        }
        #endregion
        #region Private Methods
        //creates blank bitmap so user can draw on it
        private void NewImage()
        {
            //create new objects we will set the ChosenImage equal to
            ChosenImage = new BitmapImage();
            _chosenImageUri = new Uri("Images/Untitled.png", UriKind.Relative);

            //set new UriSource to our new image we created above
            ChosenImage.BeginInit();
            ChosenImage.UriSource = _chosenImageUri;
            ChosenImage.EndInit();

            //set original image equal to our unchanged original image
            OriginalImage = _chosenImage;

            //set filename property to untitled.png so we can display the image name
            FileName = "Untitled.png";

            //reset rotations because we are getting a new image so we don't need to keep track of old image's rotations
            rotations = 0;

            //update UI
            OnPropertyChanged(nameof(ChosenImage));
            OnPropertyChanged(nameof(FileName));
        }

        //opens file explorer so user can choose photo they want to open
        private void OpenImage()
        {
            try
            {
                //open the file explorer so user can choose the photo they want to open
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";

                //if we can open the image, open it in our application
                if (openFileDialog.ShowDialog() == true)
                {
                    //create new objects we will use for the new image
                    ChosenImage = new BitmapImage();
                    _chosenImageUri = new Uri(openFileDialog.FileName);

                    //set new UriSource to objects we created above
                    ChosenImage.BeginInit();
                    ChosenImage.UriSource = _chosenImageUri;
                    ChosenImage.EndInit();
                    
                    //set original image equal to our unchanged original image
                    OriginalImage = ChosenImage;

                    //set FileName property to the new image's name so we can display it, get ONLY the name, not full path
                    FileName = Path.GetFileName(openFileDialog.FileName);
                    
                    //reset rotations because we are getting a new image so we don't need to keep track of old image's rotations
                    rotations = 0;

                    //update UI
                    OnPropertyChanged(nameof(FileName));
                    OnPropertyChanged(nameof(ChosenImage));
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error importing image!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RotateImage()
        {
            //add one so we know we're on the next rotation
            rotations++;

            //keep track of what rotation we're on
            if (rotations == 5)
            {
                rotations = 1;
            }
            
            //set image is saved to false because we rotated it and it therefore isn't saved anymore
            imageIsSaved = false;

            //switch through rotations
            switch (rotations)
            {
                //rotate to 90 degrees
                case 1:
                    _chosenImage = new BitmapImage();
                    _chosenImage.BeginInit();
                    _chosenImage.Rotation = Rotation.Rotate90;
                    _chosenImage.UriSource = _chosenImageUri;
                    _chosenImage.EndInit();
                    break;
                //rotate to 180 degrees
                case 2:
                    _chosenImage = new BitmapImage();
                    _chosenImage.BeginInit();
                    _chosenImage.Rotation = Rotation.Rotate180;
                    _chosenImage.UriSource = _chosenImageUri;
                    _chosenImage.EndInit();
                    break;
                //rotate to 270 degrees
                case 3:
                    _chosenImage = new BitmapImage();
                    _chosenImage.BeginInit();
                    _chosenImage.Rotation = Rotation.Rotate270;
                    _chosenImage.UriSource = _chosenImageUri;
                    _chosenImage.EndInit();
                    break;
                //rotate back to 0 degrees
                case 4:
                    _chosenImage = new BitmapImage();
                    _chosenImage.BeginInit();
                    _chosenImage.Rotation = Rotation.Rotate0;
                    _chosenImage.UriSource = _chosenImageUri;
                    _chosenImage.EndInit();
                    break;
            }

            //update UI
            OnPropertyChanged(nameof(ChosenImage));
        }

        //close whatever image is currently open, basically just set it to null
        private void CloseImage()
        {
            //if the user doesn't have a chosen image then we can't close an image
            if(ChosenImage == null || FileName == null)
            {
                MessageBox.Show("You don't have any image open.", "Notice", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(imageIsSaved == false)
            {
                //notify user that they are closing the image without saving it
                var userChoice = MessageBox.Show("Do you want to close the image without saving?", "Notice", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                //if the user wants to close the image without saving it, do so
                if(userChoice == MessageBoxResult.Yes)
                {
                    //set image to null so it doesn't show in the UI anymore
                    ChosenImage = null;

                    //set original image to null because since we closed the image there is no longer an original image
                    OriginalImage = null;

                    //set FileName to null so it's not displayed anymore
                    FileName = null;

                    //reset rotations because we are closing our image so we don't need to keep track of its rotations
                    rotations = 0;

                    //update UI
                    OnPropertyChanged(nameof(ChosenImage));
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }
        
        //save current image
        private void SaveImage()
        {
            //create filestream object to hold the bitmap
            using(FileStream stream = new FileStream(FileName, FileMode.Create))
            {
                //create a PngBitmapEncoder object
                PngBitmapEncoder encoder = new PngBitmapEncoder();

                //add bitmapframe to the encoder's frames collection
                encoder.Frames.Add(BitmapFrame.Create(ChosenImage));

                //save encoder's data into file stream
                encoder.Save(stream);
            }

            //we saved the image so set issaved to true
            imageIsSaved = true;
        }

        //allows user to see original unchanged image
        private void ViewOriginalImage()
        {
            //create object of our original image window and show it, passing the image to the class
            ImageWindow imageWindow = new ImageWindow(OriginalImage);
            imageWindow.Show();
        }

        //allows user to rename image
        private void RenameImage()
        {
            RenameWindow renameWindow = new RenameWindow(FileName, this);
            renameWindow.Show();
            imageIsSaved = false;
        }

        //allows user to view the image fullscreen
        private void ViewFullScreen()
        {
            FullScreenWindow fullScreenWindow = new FullScreenWindow(ChosenImage);
            fullScreenWindow.Show();
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