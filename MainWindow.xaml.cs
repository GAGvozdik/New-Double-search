using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlotModel model = new PlotModel();
            model.Title = "График";

            LinearAxis xAxe = new LinearAxis();
            xAxe.Position = AxisPosition.Bottom;
            xAxe.Title = "ось x";

            LinearAxis yAxe = new LinearAxis();
            yAxe.Position = AxisPosition.Left;
            yAxe.Title = "ось y";

            

            model.Axes.Add(xAxe);
            model.Axes.Add(yAxe);

            

            

            FunctionSeries functionseries = new FunctionSeries(MyFunction, 0, 50, 0.01, "кв. у-ря");
            model.Series.Add(functionseries);



            int left = 35;
            int right = 50;

            while ((right - left) > 1) 
            {
                int len = right - left;
                int half = len / 2;
                int middle = left + half;

                TextBox1.Text = middle.ToString();

                if (Math.Sign(MyFunction(left)) != Math.Sign(MyFunction(right)))
                {
                    right = middle;
                }
                else
                {
                    left = middle;
                }
            }

            //TextBox1.Text
            LineSeries lineSeries = new LineSeries() { Title = "Series 2", MarkerType = MarkerType.Square };
            //lineSeries.MarkerType = 
            //lineSeries.Points.Add(new DataPoint(33, 55));
            model.Series.Add(lineSeries);
            lineSeries.Points.Add(new DataPoint(float.Parse(TextBox1.Text), Math.Pow(2, float.Parse(TextBox1.Text))));

            //lineSeries.Points.Add(new DataPoint(0, 0));


            


            Plotplot.Model = model;
        }
        private double MyFunction(double x)
        {
            return Math.Pow(2, x);
        }
    }
        
}
