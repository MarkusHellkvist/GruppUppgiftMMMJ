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
        private int xStartsAtDateYear;
        private int xStartsAtDateMonth;
        public InputData()
        {
            InitializeComponent();
            xStartsAtDateYear = 0;
            xStartsAtDateMonth = 0;


        }

        private void InputData_Load(object sender, EventArgs e)
        {
            mytestfunction(1, "CarSales", "År", "elbilar sålda", "electric", "sum", "column", "month", false);
            mytestfunction(2, "CarSales", "År", "elbilar sålda", "electric", "sum", "column", "month", true);

        }


        private void mytestfunction(int country_id, string pickedTable, string xtitle, string ytitle, string pickedColumn, string typeofcalculation, string graphtype, string granularity, bool add)
        {
            if (add==false)
            {
                xStartsAtDateYear = 0;
                xStartsAtDateMonth = 0;
            }
           
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<CarSale> Context = dw.CarSales.Where(c => c.country_id == country_id).ToList();
                string country_name = dw.Countries.Where(c => c.country_id == country_id).Select(a => a.name).FirstOrDefault();
                //per år
                //hämtar min o max
                int max = Context.Max(a => a.year_no);
                int min = Context.Min(a => a.year_no);

                //Hjälpa hoverfunktionen
                if (xStartsAtDateYear==0)
                {
                    xStartsAtDateYear = min;
                    
                }

                List<int> y = new List<int>();
                List<string> x = new List<string>();
                for (int i = min; i <= max; i++) //för varje år
                {
                    switch (granularity.ToLower())
                    {
                        case "year":
                            x.Add(i.ToString());//year as x values
                            var hjalp = Context.Where(b => b.year_no == i).Select(pickedColumn);
                            int sum = 0;
                            //summerar
                            foreach (int h in hjalp)
                            {
                                sum += h;
                            }
                            //lägger till
                            y.Add(sum);

                            break;
                        case "month":
                            //addarer y 12 gånger per år el hur många månader som det nu finns
                            int maxmonth = Context.Where(C => C.year_no == i).Max(m => m.month_no);
                            int minmonth = Context.Where(C => C.year_no == i).Min(m => m.month_no);
                            //hjälp till hoverfunktionen
                            if (xStartsAtDateMonth == 0)
                            {
                                xStartsAtDateMonth = minmonth;
                            }
                            for (int m = minmonth; m <= maxmonth; m++) //för månad
                            {
                                var hjalp1 = Context.Where(b => b.year_no == i && b.month_no == m).Select(pickedColumn);
                                int sumM = 0;
                                //summerar
                                foreach (int h in hjalp1)
                                {
                                    sumM += h;
                                }
                                //lägger till
                                y.Add(sumM);
                                x.Add(i.ToString() + "-" + m.ToString());
                            }
                            break;

                        default:
                            break;
                    }

                }
                ChartValues<int> cvy = new ChartValues<int>();
                cvy.AddRange(y.ToArray());

                ColumnSeries cs = new ColumnSeries
                {
                    Title = country_name,
                    Values = cvy
                };
                if (cartesianChart1.AxisX.Count() == 0) //Sätter bara om det inte är satt
                {
                    cartesianChart1.AxisX.Add(new Axis
                    {
                        Title = xtitle,
                        Labels = x.ToArray()
                    });

                    cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = ytitle,
                        LabelFormatter = value => value.ToString("N")
                    });
                }
                if (add)
                {
                    cartesianChart1.Series.Add(cs);
                }
                else
                {
                    cartesianChart1.Series.Clear();
                    cartesianChart1.Series.Add(cs);

                }

            }

        }



        private void cartesianChart1_DataHover(object sender, ChartPoint p)
        {
           
            if (xStartsAtDateMonth==0 && xStartsAtDateYear!=0)
            {
                //år verkar valt
                int yr = (int)p.X + xStartsAtDateYear;
                using (CarsDWEntities dw = new CarsDWEntities())
                {

                    var me = dw.MarketEvents.Where(a => a.year_no == yr).Select(a => new { a.date, a.country_name, a.description, a.title }).ToList();
                    dataGridView1.DataSource = me;

                }
                label1.Text = yr.ToString();
            }
            else if (xStartsAtDateYear!=0 && xStartsAtDateMonth!=0)
            {
                //räknar antalet månader fram
                DateTime d = new DateTime(xStartsAtDateYear, 1, 1);
                d = d.AddMonths((int)p.X);
                int yr = d.Year;
                int mnth = d.Month;
                using (CarsDWEntities dw = new CarsDWEntities())
                {
                    var me = dw.MarketEvents.Where(a => a.year_no == yr && a.month_no==mnth).Select( a=>new { a.date, a.country_name, a.description,a.title}).ToList();
                    dataGridView1.DataSource = me;

                }
                label1.Text = yr.ToString() + mnth.ToString();
            }
         
        }


    }
}