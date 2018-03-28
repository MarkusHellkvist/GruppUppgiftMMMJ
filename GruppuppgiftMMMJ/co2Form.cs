using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Brushes = System.Windows.Media.Brushes;

namespace GruppuppgiftMMMJ
{
    public partial class co2Form : Form
    {
        Form parentForm;
        public ColumnSeries electricSalesS { get; set; }
        public ColumnSeries totSalesS { get; set; }
        public ColumnSeries elecSalesN { get; set; }
        public ColumnSeries totSalesN { get; set; }
        public ArraySegment<string> Years;
        private void ToggleAllSales(object sender, System.EventArgs e)
        {
            totSalesS.Visibility = totSalesS.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            totSalesN.Visibility = totSalesN.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }
        public co2Form(Form pf)
        {
            InitializeComponent();
            parentForm = pf;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            System.Windows.MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void co2Form_Load(object sender, EventArgs e)
        {
            // plot(); // Just nu med en area plot.
            plot2();
        }

        private void co2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            parentForm.Show();
        }

        private void plot()
        {
            DateTime startDate = new DateTime(2011, 1, 1);
            DateTime endDate = new DateTime(2017, 1, 1);
            List<BigView> Context = new List<BigView>();
            System.Collections.Generic.List<double> swePro = new System.Collections.Generic.List<double>();
            System.Collections.Generic.List<double> norPro = new System.Collections.Generic.List<double>();

            using (CarsDWEntities dw = new CarsDWEntities())
            {
                Context = dw.BigViews.Where(filter => filter.date >= startDate && filter.date < endDate).ToList();
            }
            {

                var co2 = Context.Select(f => new { year = f.year_no, co = f.CO2, coun = f.country_id });
                System.Collections.Generic.List<double> procSalesSweden = Context.Where(c => c.country_id == 1).Select(f => new { year = f.year_no, total = f.total, electric = f.electric }).GroupBy(g => g.year, g => ((double)g.electric / (double)g.total * 100), (Key, g) => new { year = Key, proc = g.Average() }).Select(y => y.proc).ToList();

                System.Collections.Generic.List<double> procSalesNor = Context.Where(c => c.country_id == 2).Select(f => new { year = f.year_no, total = f.total, electric = f.electric }).GroupBy(g => g.year, g => ((double)g.electric / (double)g.total * 100), (Key, g) => new { year = Key, proc = g.Average() }).Select(y => y.proc).ToList();
                /*
                List<int> elecSalesNor = Context.Where(i => i.country_id == 2).GroupBy(g => g.year_no, g => g.electric, (key, g) => new { year = key, elec = g }).Select(filter => (int)filter.elec.Sum()).ToList();
                var groupedByYear = Context.GroupBy(g => 

                        )*/
                var salesSwe = Context.Where(f => f.country_id == 1).GroupBy(x => x.year_no, (year, y) => new
                {
                    Key = year,
                    Total = y.Sum(x => x.total),
                    Elec = y.Sum(x => (int)x.electric)
                });

                var salesNor = Context.Where(f => f.country_id == 2).GroupBy(x => x.year_no, (year, y) => new
                {
                    Key = year,
                    Total = y.Sum(x => x.total),
                    Elec = y.Sum(x => (int)x.electric)
                });



                ChartValues<int> electricSweden = new ChartValues<int>();
                electricSweden.AddRange(salesSwe.Select(x => x.Elec).ToList());
                ChartValues<int> totalSweden = new ChartValues<int>();
                totalSweden.AddRange(salesSwe.Select(x => x.Total - x.Elec).ToList());

                ChartValues<int> electricNorway = new ChartValues<int>();
                electricNorway.AddRange(salesNor.Select(x => x.Elec).ToList());
                ChartValues<int> totalNorway = new ChartValues<int>();
                totalNorway.AddRange(salesNor.Select(x => x.Total - x.Elec).ToList());


                //SeriesCollection sweden =  new SeriesCollection{
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year",
                    Labels = new[] { "2011", "2012", "2013", "2014", "2015", "2016" }
                });

                /*
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year Swe",
                    Labels = new[] { "2011", "2012", "2013", "2014", "2015", "2016" },
                    
                });

                
                cartesianChart1.AxisY.Add(new Axis { Title = "DUMP" });
                cartesianChart1.Series.Add(new StackedColumnSeries
                {
                    ScalesXAt = 0,
                    ScalesYAt = 0,
                    Values = electricSweden,
                    Title = "Electric Sales Sweden"
                });
                cartesianChart1.Series.Add(new StackedColumnSeries
                    {
                    ScalesXAt = 0,
                    ScalesYAt = 0,
                        Values = totalSweden,
                        Title = "Total Sales Sweden"
                    });
                cartesianChart1.Series.Add(new StackedColumnSeries
                    {
                        Values = electricNorway,
                        Title = "Electric Sales Norway",
                    ScalesXAt = 1,
                    ScalesYAt = 1,
                    MaxColumnWidth = 80,
                    

                });
                cartesianChart1.Series.Add(new StackedColumnSeries
                {
                    Values = totalNorway,
                    Title = "Total Sales Norway",
                    ScalesXAt = 1,
                    ScalesYAt = 1,
                    MaxColumnWidth = 80
                });
                */
                cartesianChart1.Series = new SeriesCollection
            {
                new StackedAreaSeries
                {
                    Title = "Total Sweden",
                    Values = totalSweden,
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Values = electricSweden,
                    Title = "Electric Sales Sweden",
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Values = electricNorway,
                        Title = "Electric Sales Norway",
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Total Sales Norway",
                    Values = totalNorway,
                    LineSmoothness = 0
                }
            };

                /*
                
                SeriesCollection norway = new SeriesCollection{
                      new StackedColumnSeries
                    {
                        Values = electricNorway,
                        StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                        Title = "Electric Sales Norway",
                        ScalesYAt = 1

                    },
                new StackedColumnSeries
                    {
                        Values = totalNorway,
                        StackMode = StackMode.Values,
                        Title = "Total Sales Norway",
                        ScalesYAt = 1
                    }
                };

                */
                cartesianChart1.LegendLocation = LegendLocation.Right;
                // cartesianChart1.Series = norway;

                /*
                var dataNoway = dw.BigViews.Where(e => e.date > new DateTime(2011, 1, 1) && e.country_id == 2).Select(Q => new { ev = (double)Q.electric, tot = (double)Q.total }).Select(QW => new { result = (QW.ev / QW.tot) * 100 });
                */

                System.Collections.Generic.List<double> co2sweden = co2.Where(i => i.coun == 1).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();
                System.Collections.Generic.List<double> co2norway = co2.Where(i => i.coun == 2).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();

                ChartValues<double> NCV = new ChartValues<double>();
                NCV.AddRange(co2sweden);
                ChartValues<double> SCV = new ChartValues<double>();
                SCV.AddRange(co2norway);
                int maxCWidth = 80;

                /*
                ChartValues<double> cSales = new ChartValues<double>();
                cSales.AddRange(procSalesSweden);
                
                ChartValues<double> nSales = new ChartValues<double>();
                nSales.AddRange(procSalesNor);
                
                ColumnSeries NCS = new ColumnSeries();
                NCS.Title = "Norge";
                NCS.Values = NCV;
                NCS.PointGeometry = null;
                NCS.StrokeThickness = 4;
                NCS.MaxColumnWidth = maxCWidth;

                ColumnSeries SCS = new ColumnSeries();
                SCS.Title = "Svedala";
                SCS.Values = SCV;
                SCS.PointGeometry = null;
                SCS.StrokeThickness = 4;
                SCS.MaxColumnWidth = maxCWidth;


                */


                /*
                NLS.Title = "Norge";
                NLS.Values = cSales;
                NLS.PointGeometry = null;
                NLS.StrokeThickness = 4;
                */
                cartesianChart1.AxisY.Add(new Axis { Title = "CarSales", MinValue = 0 });
                cartesianChart1.AxisY.Add(new Axis { Title = "Co2", MinValue = 0, Position = AxisPosition.RightTop });
                LineSeries NLS = new LineSeries
                {
                    Title = "Norge",
                    Values = NCV,
                    PointGeometry = null,
                    StrokeThickness = 4,
                    ScalesYAt = 1
                };

                LineSeries SLS = new LineSeries
                {
                    Title = "Svedala",
                    Values = SCV,
                    PointGeometry = null,
                    StrokeThickness = 4,
                    ScalesYAt = 1
                };

                /*
              SLS.Title = "Svedala";
              SLS.Values = nSales;
              SLS.PointGeometry = null;
              SLS.StrokeThickness = 4;*/

                /*
                cartesianChart1.Series = new SeriesCollection
            {
                NCS,SCS,NLS,SLS,
            };*/


                cartesianChart1.Series.Add(SLS);
                cartesianChart1.Series.Add(NLS);
                cartesianChart1.LegendLocation = LegendLocation.Top;
                System.Windows.Controls.Panel.SetZIndex(SLS, 10);
                System.Windows.Controls.Panel.SetZIndex(NLS, 10);
                /*
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year",
                    Labels = new[] { "2011", "2012", "2013", "2014", "2015", "2016" }
                });
                */
                /*
                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Gram co2 / km",

                    MinValue = 0,
                    // MaxValue = 200,
                    // LabelFormatter = val => val + "gco2 / km",
                    Separator = new Separator
                    {
                        Step = 10,
                        IsEnabled = false
                    }
                });
                
                cartesianChart1.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.IndianRed,
                    Title = "Red Axis",
                    Position = AxisPosition.RightTop
                });
                */
            }

        }

        private void plot2()
        {
            DateTime startDate = new DateTime(2011, 1, 1);
            DateTime endDate = new DateTime(2017, 1, 1);
            List<BigView> Context = new List<BigView>();
            System.Collections.Generic.List<double> swePro = new System.Collections.Generic.List<double>();
            System.Collections.Generic.List<double> norPro = new System.Collections.Generic.List<double>();

            using (CarsDWEntities dw = new CarsDWEntities())
            {
                Context = dw.BigViews.Where(filter => filter.date >= startDate && filter.date < endDate).ToList();
            }
            {

                var co2 = Context.Select(f => new { year = f.year_no, co = f.CO2, coun = f.country_id });
                System.Collections.Generic.List<double> procSalesSweden = Context.Where(c => c.country_id == 1).Select(f => new { year = f.year_no, total = f.total, electric = f.electric }).GroupBy(g => g.year, g => ((double)g.electric / (double)g.total * 100), (Key, g) => new { year = Key, proc = g.Average() }).Select(y => y.proc).ToList();

                System.Collections.Generic.List<double> procSalesNor = Context.Where(c => c.country_id == 2).Select(f => new { year = f.year_no, total = f.total, electric = f.electric }).GroupBy(g => g.year, g => ((double)g.electric / (double)g.total * 100), (Key, g) => new { year = Key, proc = g.Average() }).Select(y => y.proc).ToList();
                /*
                List<int> elecSalesNor = Context.Where(i => i.country_id == 2).GroupBy(g => g.year_no, g => g.electric, (key, g) => new { year = key, elec = g }).Select(filter => (int)filter.elec.Sum()).ToList();
                var groupedByYear = Context.GroupBy(g => 

                        )*/
                var salesSwe = Context.Where(f => f.country_id == 1).GroupBy(x => x.year_no, (year, y) => new
                {
                    Key = year,
                    Total = y.Sum(x => x.total),
                    Elec = y.Sum(x => (int)x.electric)
                });

                var salesNor = Context.Where(f => f.country_id == 2).GroupBy(x => x.year_no, (year, y) => new
                {
                    Key = year,
                    Total = y.Sum(x => x.total),
                    Elec = y.Sum(x => (int)x.electric)
                });


                ChartValues<int> electricSweden = new ChartValues<int>();
                electricSweden.AddRange(salesSwe.Select(x => x.Elec).ToList());
                ChartValues<int> totalSweden = new ChartValues<int>();
                totalSweden.AddRange(salesSwe.Select(x => x.Total).ToList());

                ChartValues<int> electricNorway = new ChartValues<int>();
                electricNorway.AddRange(salesNor.Select(x => x.Elec).ToList());
                ChartValues<int> totalNorway = new ChartValues<int>();
                totalNorway.AddRange(salesNor.Select(x => x.Total).ToList());

                //räknar uut procent
                List<double> procentSwe = salesSwe.Select(i => ((double)i.Elec / (double)i.Total * 100)).ToList();
                List<double> procentNor = salesNor.Select(i => ((double)i.Elec / (double)i.Total * 100)).ToList();

                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year",
                    FontSize = 20,
                    Labels = new[] { "2011", "2012", "2013", "2014", "2015", "2016" }
                });

                ColumnSeries electricSalesS = new ColumnSeries
                {
                    Values = electricSweden,
                    Title = "Electric Sales Sweden",
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 107, 179))
                };
                ColumnSeries totSalesS = new ColumnSeries
                {
                    Values = totalSweden,
                    Title = "Total Sales Sweden",
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(153, 214, 255))
                };

                ColumnSeries elecSalesN = new ColumnSeries
                {
                    Values = electricNorway,
                    Title = "Electric Sales Norway",
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(179, 0, 0))

                };
                ColumnSeries totSalesN = new ColumnSeries
                {
                    Values = totalNorway,
                    Title = "Total Sales Norway",
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 102, 102))
                };
                cartesianChart1.Series = new SeriesCollection
            {
                electricSalesS,totSalesS,elecSalesN,totSalesN
            };



                System.Collections.Generic.List<double> co2sweden = co2.Where(i => i.coun == 1).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();
                System.Collections.Generic.List<double> co2norway = co2.Where(i => i.coun == 2).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();

                ChartValues<double> NCV = new ChartValues<double>();
                NCV.AddRange(co2norway);
                ChartValues<double> SCV = new ChartValues<double>();
                SCV.AddRange(co2sweden);


                

                cartesianChart1.AxisY.Add(new Axis { Title = "CarSales", MinValue = 0, LabelFormatter = val => (val/1000 + "k"), FontSize = 16});
                cartesianChart1.AxisY.Add(new Axis { Title = "Co2", MinValue = 0, Position = AxisPosition.RightTop, FontSize = 0.1 });
                LineSeries NLS = new LineSeries
                {
                    Title = "Norge",
                    Values = NCV,
                    PointGeometry = null,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(179, 0, 0)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    StrokeThickness = 4,
                    ScalesYAt = 1,
                };

                LineSeries SLS = new LineSeries
                {
                    Title = "Svedala",
                    Values = SCV,
                    PointGeometry = null,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 107, 179)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    StrokeThickness = 4,
                    ScalesYAt = 1
                    
                };
                
                cartesianChart1.Series.Add(SLS);
                cartesianChart1.Series.Add(NLS);
                cartesianChart1.LegendLocation = LegendLocation.Top;
                System.Windows.Controls.Panel.SetZIndex(SLS, 10);
                System.Windows.Controls.Panel.SetZIndex(NLS, 10);
            }
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
