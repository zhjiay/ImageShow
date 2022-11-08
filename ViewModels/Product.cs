using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;

namespace ImageShow.ViewModels
{
    public class Product
    {
        public Mat ImageMat { get; set; }
        
        public BitmapSource TheBitmapSource { get; set; }
        public Product(Mat mat)
        {
            ImageMat = mat;
            TheBitmapSource=mat.ToBitmapSource();

        }
    }
}
