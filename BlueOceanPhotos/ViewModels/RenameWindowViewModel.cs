using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlueOceanPhotos
{
    public class RenameWindowViewModel
    {
        private string _fileName;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly RenameWindow _renameWindow;

        public RenameWindowViewModel(string fileName, MainWindowViewModel mainWindowViewModel, RenameWindow renameWindow)
        {
            this._fileName = fileName;
            this._mainWindowViewModel = mainWindowViewModel;
            this._renameWindow = renameWindow;
        }

        public string FileName
        {
            get { return this._fileName; }
            set
            {
                if(this._fileName != value)
                {
                    this._fileName = value;
                }
            }
        }

        public ICommand RenameCommand
        {
            get { return new DelegateCommand(Rename); }
        }

        private void Rename()
        {
            this._mainWindowViewModel.Rename(FileName);
            this._renameWindow.Close();
        }
    }
}