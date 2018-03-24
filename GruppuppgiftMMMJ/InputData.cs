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
using LiveCharts;
namespace GruppuppgiftMMMJ
{
    public partial class InputData : Form
    {
        public InputData()
        {
            InitializeComponent();


        }

        private void InputData_Load(object sender, EventArgs e)
        {
            mytestfunction(1,"xtitlen","electric","sum");
        }
     

        private void mytestfunction(int country_id,string xtitle,string pickedColumn,string typeofcalculation)
        {

            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<CarSale> Context = dw.CarSales.Where(c => c.country_id == country_id).ToList();

                DateTime d = DateTime.Today;
                //sales per år för sverige
                //hämtar min o max
                int max = Context.Max(a => a.year_no);
                int min = Context.Min(a => a.year_no);
                List<double> y = new List<double>();
                List<string> x = new List<string>();
                for (int i = min; i < max; i++)
                {

                    x.Add(i.ToString());//year
                    var hjalp = Context.Where(b => b.year_no == i).Select(pickedColumn);
                    int sum = 0;

                    foreach (int h in hjalp)
                    {
                        sum += h;
                    }

                     y.Add(sum);

                }
                ChartValues<double> cvy = new ChartValues<double>();
                cvy.AddRange(y.ToArray());

                ColumnSeries cs = new ColumnSeries
                {
                     Values = cvy
                };
                if (cartesianChart1.AxisX.Count()==0) //Sätter bara om det inte är satt
                {
                    cartesianChart1.AxisX.Add(new Axis
                    {
                        Title = xtitle,
                        Labels = x.ToArray()
                    });

                }
                cartesianChart1.Series.Add(cs);
                /*
                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Totalt Antal Bilar sålda",
                    LabelFormatter = value => value.ToString("N")
                });*/

            }

        }


        private class ColItem
        {
            public double[] value;
            public string label;

        }

    }
}
