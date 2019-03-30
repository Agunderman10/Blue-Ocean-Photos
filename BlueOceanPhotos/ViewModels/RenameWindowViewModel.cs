using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueOceanPhotos
{
    public class RenameWindowViewModel
    {
        private string _fileName;

        public RenameWindowViewModel(string fileName)
        {
            _fileName = fileName;
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
    }
}