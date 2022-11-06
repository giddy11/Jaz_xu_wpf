using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chart2DCoordinateSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddGraphics();
        }

        private void AddGraphics()
        {
            line1 = new Line();
            line1.X1 = XNormalize(3.0);
            line1.Y1 = YNormalize(4.0);
            line1.X2 = XNormalize(9.0);
            line1.Y2 = YNormalize(10.0);

            line1.Stroke = Brushes.Blue;
            line1.StrokeThickness = 2;
            plotCanvas.Children.Add(line1);

            polyline1 = new Polyline();
            polyline1.Points.Add(new Point(XNormalize(8), YNormalize(8)));
            polyline1.Points.Add(new Point(XNormalize(6), YNormalize(6)));
            polyline1.Points.Add(new Point(XNormalize(6), YNormalize(4)));
            polyline1.Points.Add(new Point(XNormalize(4), YNormalize(4)));
            polyline1.Points.Add(new Point(XNormalize(4), YNormalize(6)));
            polyline1.Points.Add(new Point(XNormalize(6), YNormalize(6)));
            polyline1.Stroke = Brushes.Red;
            polyline1.StrokeThickness = 5;
            plotCanvas.Children.Add(polyline1);
        }

        private double YNormalize(double y)
        {
            double result = plotCanvas.Height - (y - yMin) * plotCanvas.Height / (yMax - yMin);
            return result;
        }

        private double XNormalize(double x)
        {
            double result = (x - xMin) * plotCanvas.Width / (xMax - xMin);
            return result;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            xMin = Convert.ToDouble(tbXMin.Text);
            xMax = Convert.ToDouble(tbXMax.Text);
            yMin = Convert.ToDouble(tbXMin.Text);
            yMax = Convert.ToDouble(tbYMax.Text);
            plotCanvas.Children.Remove(line1);
            plotCanvas.Children.Remove(polyline1);
            AddGraphics();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private double xMin = 0.0;
        private double xMax = 10.0;
        private double yMin = 0.0;
        private double yMax = 10.0;
        private Line line1;
        private Polyline polyline1;

    }
}
