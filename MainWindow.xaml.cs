using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
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
using Color = System.Windows.Media.Color;

namespace wcanvas



{




    public partial class MainWindow : Window
    {
        public Color current_brush = Colors.Yellow;



        public MainWindow()
        {

            InitializeComponent();
            ic.DefaultDrawingAttributes.Color = Colors.Yellow;
            ic.DefaultDrawingAttributes.Width = 10;
            ic.DefaultDrawingAttributes.Height = 10;


        }


        private void Set_brush_Colour(object sender, RoutedEventArgs e)
        {
            current_brush = Colors.Red;
            ic.DefaultDrawingAttributes.Color = current_brush;
        }

        private void Set_highlighter(object sender, RoutedEventArgs e)
        {
            if (ic.DefaultDrawingAttributes.IsHighlighter == false)
            {
                ic.DefaultDrawingAttributes.IsHighlighter = true;
                Brush bg_brush = new SolidColorBrush(current_brush);
                highlighter.Background = bg_brush;
                highlighter.Background.Opacity = 0.5;
            }
            else
            {
                ic.DefaultDrawingAttributes.IsHighlighter = false;
                highlighter.Background = Brushes.LightGray;
            }

        }

        private void Minimise_c(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Minimized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }



        private void Erase_b(object sender, RoutedEventArgs e)
        {
            if (ic.EditingMode != InkCanvasEditingMode.EraseByStroke)
            {
                ic.EditingMode = InkCanvasEditingMode.EraseByStroke;
                eraser.Background = Brushes.PaleGreen;

            }
            else
            {
                ic.EditingMode = InkCanvasEditingMode.Ink;
                eraser.Background = Brushes.LightGray;

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

        private void Clickthrough_c(object sender, RoutedEventArgs e)
        {
            if (root.Topmost != true)
            {
                root.Topmost = true;
                root.Background = null;
                ic.Background = null;
                ic.EditingMode = InkCanvasEditingMode.None;
                ic.IsHitTestVisible = false;
                pin_c.Background = Brushes.PaleGreen;
            }
            else
            {
                root.Topmost = false;
                root.Background = (Brush)new BrushConverter().ConvertFrom("#01ffffff");
                ic.IsHitTestVisible = true;
                ic.EditingMode = InkCanvasEditingMode.Ink;

                pin_c.Background = Brushes.LightGray;

            }

        }

        private void Close_c(object sender, RoutedEventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to stop stroking?",
            "Stop stroking?", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {

                this.Close();
            }
            else
            {
                // we keep stroking  
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Clear_c(object sender, RoutedEventArgs e)
        {


            if (MessageBox.Show("Clear entire canvas?",
            "asdljkjdfr;;", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                ic.Strokes.Clear();
            }
            else
            {
                // we keep stroking  
            }
        }
        private void Undo_c(object sender, RoutedEventArgs e)
        {
            if (ic.Strokes.Count > 0)
            {
                ic.Strokes.RemoveAt(ic.Strokes.Count - 1);
            }
            else
            {
                // Else Do Nothing.
            }
        }


    }
}