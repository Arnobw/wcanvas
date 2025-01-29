﻿using System.Diagnostics.Eventing.Reader;
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




    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            ic.DefaultDrawingAttributes.Color = Colors.Yellow;
            ic.DefaultDrawingAttributes.Width = 10;
            ic.DefaultDrawingAttributes.Height = 10;
            ic.DefaultDrawingAttributes.IsHighlighter = true;
            
           
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
            if (ic.EditingMode != InkCanvasEditingMode.EraseByPoint)
            {
                ic.EditingMode = InkCanvasEditingMode.EraseByPoint;

            }
            else
            {
                ic.EditingMode = InkCanvasEditingMode.Ink;

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
                ic.EditingMode = InkCanvasEditingMode.None;
                root.IsHitTestVisible = false;
                pin_c.Background = Brushes.Blue;
            }
            else
            {
                root.Topmost = false;
                root.Background = (Brush)new BrushConverter().ConvertFrom("#01ffffff");
                ic.IsHitTestVisible = true;
                ic.EditingMode = InkCanvasEditingMode.Ink;

                pin_c.Background = Brushes.White;

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