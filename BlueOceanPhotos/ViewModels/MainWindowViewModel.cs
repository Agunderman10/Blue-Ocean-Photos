namespace BlueOceanPhotos
{
    using System.Threading;
    using System.Windows.Input;

    public class MainWindowViewModel
    {
        #region Private Members

        #endregion
        #region Constructors
        public MainWindowViewModel()
        {
            Thread.Sleep(3000);
        }
        #endregion
        #region Public Properties
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