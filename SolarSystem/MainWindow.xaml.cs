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

// System.Threading.Timer

namespace SolarSystem {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		
		Ellipse sun = new Ellipse();
		Ellipse mercury = new Ellipse();
		Ellipse venus = new Ellipse();
		Ellipse earth = new Ellipse();
		Ellipse mars = new Ellipse();

		public MainWindow() {
			InitializeComponent();


			sun.Width = 80;
			sun.Height = 80;
			RadialGradientBrush sunFill = new RadialGradientBrush(Brushes.Yellow.Color, Brushes.Orange.Color);
			sun.Fill = sunFill;
			sun.Margin = new Thickness(360, 360, 0, 0);

			mercury.Margin = new Thickness(480, 360, 0, 0);
			mercury.Width = 10;
			mercury.Height = 10;
			mercury.Fill = Brushes.Gray;

			venus.Width = 20;
			venus.Height = 20;
			venus.Fill = Brushes.Orange;

			earth.Width = 30;
			earth.Height = 30;
			earth.Fill = Brushes.Green;

			mars.Width = 25;
			mars.Height = 25;
			mars.Fill = Brushes.Red;


			canvas.Children.Add(sun);
			canvas.Children.Add(mercury);
			canvas.Children.Add(venus);
			canvas.Children.Add(earth);
			canvas.Children.Add(mars);

			// Create and start timer
			DispatcherTimer dt = new DispatcherTimer();
			dt.Interval = TimeSpan.FromMilliseconds(10);
			dt.Tick += Update;
			dt.Start();
		}
		double angle = 0;
		void Update(object sender, EventArgs evnt) {
			if (canvas.Width == 0 || canvas.Height == 0)
				return;
			Orbit(mercury, 100, angle);
			Orbit(venus, 150, angle + 70);
			Orbit(earth, 200, angle + 170);
			Orbit(mars, 300, angle + 250);

			if (angle >= 360)
				angle = 0;
			else
				angle += 1;
		}

		void Orbit(Shape shape, double distance, double degree) {
			degree *= 0.0174532925;
			double x_rot = 400 - distance * Math.Cos(degree);
			double y_rot = 400 - distance * Math.Sin(degree);

			shape.Margin = new Thickness(x_rot, y_rot, 0, 0);
		}
	}
}
