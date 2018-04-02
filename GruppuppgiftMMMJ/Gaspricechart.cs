using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;

namespace GruppuppgiftMMMJ
{
    public partial class Gaspricechart : Form
    {
        public Gaspricechart()
        {
            InitializeComponent();
        }

        private void Gaspricechart_Load(object sender, EventArgs e)
        {
            Plot();
            cartesianChart1.AxisY[0].MinValue = 0;
            cartesianChart1.AxisY[0].MaxValue = 25;
            cartesianChart1.AxisX[0].FontSize = 22;
            cartesianChart1.AxisY[0].FontSize = 22;
            cartesianChart1.AxisX[0].FontWeight = System.Windows.FontWeights.Black;
            cartesianChart1.AxisY[0].FontWeight = System.Windows.FontWeights.Black;
            cartesianChart1.AxisY[0].Foreground = System.Windows.Media.Brushes.Black;
            cartesianChart1.AxisX[0].Foreground = System.Windows.Media.Brushes.Black;
            cartesianChart1.LegendLocation = LegendLocation.Right;
            
        }
        public void Plot()
        {
            //AUTO GENERATED SOURCE CODE FOR LIVE CHART USING CARSDWENTITIES

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<BigView> Context = dw.BigViews.Where(c => c.country_id == 2).ToList();


                string country_name = dw.Countries.Where(c => c.country_id == 2).Select(a => a.name).FirstOrDefault();
                List<double> yAsDouble = new List<double>();

                List<string> x = new List<string>();
                for (int i = 2014; i <= 2017; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("gas_price");
                    double sum = 0;
                    //summerar
                    foreach (double h in hjalp)
                    {
                        sum += h;
                    }
                    //lägger till
                    yAsDouble.Add(sum);

                }
                ChartValues<double> cvy = new ChartValues<double>();
                cvy.AddRange(yAsDouble.ToArray());
                LineSeries ls = new LineSeries();


                ls.Title = "Norge";
                ls.Values = cvy;
                ls.ScalesYAt = 0;
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year",
                    Labels = x.ToArray()
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Pris/l SEK",
                    LabelFormatter = value => value.ToString()
                });
                cartesianChart1.Series.Add(ls);

            }
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<BigView> Context = dw.BigViews.Where(c => c.country_id == 1).ToList();


                string country_name = dw.Countries.Where(c => c.country_id == 1).Select(a => a.name).FirstOrDefault();
                List<double> yAsDouble = new List<double>();

                List<string> x = new List<string>();
                for (int i = 2014; i <= 2017; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("gas_price");
                    double sum = 0;
                    //summerar
                    foreach (double h in hjalp)
                    {
                        sum += h;
                    }
                    //lägger till
                    yAsDouble.Add(sum);

                }
                ChartValues<double> cvy = new ChartValues<double>();
                cvy.AddRange(yAsDouble.ToArray());

                LineSeries ls = new LineSeries();
                ls.Title = "Sverige";
                ls.Values = cvy;
                ls.ScalesYAt = 0; cartesianChart1.Series.Add(ls);


            }
        }
    }
}
