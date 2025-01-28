using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wcanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            root.Title = "mooi hoor";
            ic.UseCustomCursor = true;
            root.Cursor = Cursors.Pen;
            ic.DefaultDrawingAttributes.Color = Colors.Yellow;
            ic.DefaultDrawingAttributes.Width = 20;
            ic.DefaultDrawingAttributes.Height = 20;
            ic.DefaultDrawingAttributes.IsHighlighter = true;
            
        }


        private void Minimise_c(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Minimized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }


        private void Maximise_c(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (this.WindowState != WindowState.Normal)
            {
                this.WindowState = WindowState.Normal;
            }
        }


        private void Close_c(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }

}