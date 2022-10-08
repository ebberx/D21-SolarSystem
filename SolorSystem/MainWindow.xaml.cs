using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace SolorSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Ellipse sun = new Ellipse();
        Ellipse mercury = new Ellipse();
        Ellipse venus = new Ellipse();
        Ellipse earth = new Ellipse();
        Ellipse mars = new Ellipse();

        public MainWindow() {
            InitializeComponent();

            sun.Margin = new Thickness(360, 360, 0, 0);
            sun.Width = 80;
            sun.Height = 80;
            RadialGradientBrush sunFill = new RadialGradientBrush(Brushes.Yellow.Color, Brushes.Orange.Color);
            sun.Fill = sunFill;

            mercury.Margin = new Thickness(480, 360, 0, 0);
            mercury.Width = 10;
            mercury.Height = 10;
            mercury.Fill = Brushes.Gray;


            canvas.Children.Add(sun);
            canvas.Children.Add(mercury);

            // Create and start timer
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1);
            dt.Tick += Update;
            dt.Start();
        }

        void Update(object sender, EventArgs evnt) {
            Orbit(mercury, sun, 0.001);
        }

        void Orbit(Shape shape, Shape around, double degree) {

            double x = shape.Margin.Left;
            double y = shape.Margin.Top;
            
            double x_rot = ((x- around.Margin.Left) * Math.Cos(degree)) - ((around.Margin.Top - y) * Math.Sin(degree)) + around.Margin.Left;
            double y_rot = around.Margin.Top - ((around.Margin.Top - y) * Math.Cos(degree)) + ((x - around.Margin.Left) * Math.Sin(degree)); 
            
            shape.Margin = new Thickness(x_rot, y_rot, 0, 0);
        }
    }
}
