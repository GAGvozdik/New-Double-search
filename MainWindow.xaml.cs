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

            

            

            FunctionSeries functionseries = new FunctionSeries(MyFunction, 0, 10, 0.01, "кв. у-ря");
            model.Series.Add(functionseries);



            float left = 1;
            float right = 40;
            
            
            float epsilon_1 = 0.001f;
            float middle_1 = (left + right) / 2;
            float n = middle_1;

            while ((right - left) > epsilon_1) 
            {
                TextBox1.Text = middle_1.ToString();
                middle_1 = (left + right) / 2;
                if (MyFunction(left) * MyFunction(middle_1) < 0)
                {
                    right = middle_1;
                }
                else
                {
                    left = middle_1;
                }
                
            }

            

            //TextBox1.Text = epsilon_1.ToString();
            //TextBox1.Text
            LineSeries lineSeries = new LineSeries() { Title = "Series 2", MarkerType = MarkerType.Square };
            //lineSeries.MarkerType = 
            //lineSeries.Points.Add(new DataPoint(33, 55));


            model.Series.Add(lineSeries);
            lineSeries.Points.Add(new DataPoint(float.Parse(TextBox1.Text), MyFunction(float.Parse(TextBox1.Text))));
            
            //TextBox1.Text = TextBox1.Text + "___" + n.ToString();
            //lineSeries.Points.Add(new DataPoint(0, 0));





            Plotplot.Model = model;
        }
        private double MyFunction(double x)
        {
            return x*x - 16;
        }
    }
        
}
