﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BlueOceanPhotos
{
    public class ImageWindowViewModel
    {
        private BitmapImage _chosenImage;

        public ImageWindowViewModel(BitmapImage chosenImage)
        {
            this._chosenImage = chosenImage;
        }

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
    }
}
