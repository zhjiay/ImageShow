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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using ImageShow.ViewModels;
using ImageShow.Views;

namespace ImageShow
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dispalyViews = new List<ImageDispalyView>() { xView1, xView2, xView3, xView4 };
        }

        List<ImageDispalyView> dispalyViews;


        public string imageFilePath = "";
        int viewIndex;
        private void xButton1_Click(object sender, RoutedEventArgs e)//选择图片文件
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\Images\\";
            openFileDialog.Filter = "Image|*.png;*.bmp;*.jepg";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageFilePath=openFileDialog.FileName;
            }
            xFilepath.Text = imageFilePath;
        }

        private void xButton2_Click(object sender, RoutedEventArgs e)//显示图片
        {
            viewIndex = new Random().Next(0, 4);
            try
            {
                Mat image = new Mat();
                image = new Mat(imageFilePath,ImreadModes.ReducedColor2);
                dispalyViews[viewIndex].DataContext = new Product(image);

                //xImage.Source = image.ToBitmapSource();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void xButton3_Click(object sender, RoutedEventArgs e)//清除图片
        {
            dispalyViews[viewIndex].DataContext = null;
        }


    }
}
