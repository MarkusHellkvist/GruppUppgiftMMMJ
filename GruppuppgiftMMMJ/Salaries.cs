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
    public partial class Salaries : Form
    {
        public Salaries()
        {
            InitializeComponent();
        }

        private void Salaries_Load(object sender, EventArgs e)
        {
            Plot();
            cartesianChart1.AxisY[0].MinValue = 0;
            cartesianChart1.AxisY[0].MaxValue = 700000;
            cartesianChart1.AxisX[0].FontSize = 22;
            cartesianChart1.AxisY[0].FontSize = 22;
            cartesianChart1.AxisX[0].FontWeight = System.Windows.FontWeights.Black;
            cartesianChart1.AxisY[0].FontWeight = System.Windows.FontWeights.Black;
            cartesianChart1.AxisY[0].Foreground = System.Windows.Media.Brushes.Black;
            cartesianChart1.AxisX[0].Foreground = System.Windows.Media.Brushes.Black;
            cartesianChart1.LegendLocation = LegendLocation.Right;
            cartesianChart1.AxisY[0].Separator = new Separator { Step = 200000 };            
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
                for (int i = 2008; i <= 2016; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("avg_salary");
                    int sum = 0;
                    //summerar
                    foreach (int h in hjalp)
                    {
                        sum += h;
                    }
                    //lägger till
                    yAsDouble.Add(sum);

                }
                ChartValues<double> cvy = new ChartValues<double>();
                cvy.AddRange(yAsDouble.ToArray());
                ColumnSeries cs = new ColumnSeries();


                cs.Title = "Norge";
                cs.Values = cvy;
                cs.ScalesYAt = 0;
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "",
                    Labels = x.ToArray()
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Medellön SEK/År",
                    LabelFormatter = value => value.ToString()
                });
                cartesianChart1.Series.Add(cs);

            }
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<BigView> Context = dw.BigViews.Where(c => c.country_id == 1).ToList();


                string country_name = dw.Countries.Where(c => c.country_id == 1).Select(a => a.name).FirstOrDefault();
                List<double> yAsDouble = new List<double>();

                List<string> x = new List<string>();
                for (int i = 2008; i <= 2016; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("avg_salary");
                    int sum = 0;
                    //summerar
                    foreach (int h in hjalp)
                    {
                        sum += h;
                    }
                    //lägger till
                    yAsDouble.Add(sum);

                }
                ChartValues<double> cvy = new ChartValues<double>();
                cvy.AddRange(yAsDouble.ToArray());

                ColumnSeries cs = new ColumnSeries();
                cs.Title = "Sverige";
                cs.Values = cvy;
                cs.ScalesYAt = 0; cartesianChart1.Series.Add(cs);


            }
        }
    }
}
