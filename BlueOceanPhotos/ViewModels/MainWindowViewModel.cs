namespace BlueOceanPhotos
{
    using System.Threading;
    using System.Windows.Input;

    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Thread.Sleep(3000);
        }

        public ICommand NewImage
        {
            get { return new DelegateCommand(CreateNewImage); }
        }

        public void CreateNewImage()
        {

        }
    }
}