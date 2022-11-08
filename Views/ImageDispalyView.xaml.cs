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

namespace ImageShow.Views
{
    /// <summary>
    /// ImageDispalyView.xaml 的交互逻辑
    /// </summary>
    public partial class ImageDispalyView : UserControl
    {
        public ImageDispalyView()
        {
            InitializeComponent();
        }

        private System.Windows.Point mousePos { get; set; }

        #region 放大、缩小图片
        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var position = e.GetPosition(xImage);
            var m = xMatrix.Value;
            if (e.Delta > 0)
            {
                m.ScaleAtPrepend(1.1, 1.1, position.X, position.Y);
            }
            else
            {
                m.ScaleAtPrepend(1 / 1.1, 1 / 1.1, position.X, position.Y);
            }
            xMatrix = new MatrixTransform(m);
            xImage.RenderTransform = xMatrix;
        }
        #endregion

        #region 双击恢复原图
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                var m = new Matrix();
                xMatrix = new MatrixTransform(m);
                xImage.RenderTransform = xMatrix;
            }

        }
        #endregion

        #region 右键移动图片
        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(xImageGrid);
            mousePos = position;
            xImage.CaptureMouse();
        }

        private void Image_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            xImage.ReleaseMouseCapture();
        }

        private void Image_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (xImage.IsMouseCaptured)
            {
                var pos = e.GetPosition(xImageGrid);
                var m = xMatrix.Value;

                m.OffsetX += pos.X - mousePos.X;
                m.OffsetY += pos.Y - mousePos.Y;
                xMatrix = new MatrixTransform(m);
                xImage.RenderTransform = xMatrix;
                mousePos = pos;
            }
        }
        #endregion



    }
}
