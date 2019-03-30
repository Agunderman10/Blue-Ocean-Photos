using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlueOceanPhotos
{
    /// <summary>
    /// Interaction logic for RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        private string _fileName;

        public RenameWindow(string fileName)
        {
            _fileName = fileName;
            RenameWindowViewModel _renameWindowViewModel = new RenameWindowViewModel(_fileName);
            this.DataContext = _renameWindowViewModel;
            InitializeComponent();
        }
    }
}
