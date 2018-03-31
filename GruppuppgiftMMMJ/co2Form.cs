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

        List<double> procentSwe;
        List<double> procentNor;
        List<string> years;

        // Set up datasource for both countries.
        BindingSource bindingNor = new BindingSource();
        BindingSource bindingSwe = new BindingSource();

        public co2Form(Form pf)
        {
            InitializeComponent();
            parentForm = pf;
        }

        private void co2Form_Load(object sender, EventArgs e)
        {
            dgvSwe.AutoGenerateColumns = false;
            dgvNor.AutoGenerateColumns = false;
            plot2();
        }

        private void co2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            parentForm.Show();
        }

        /*
         * Function for hiding and unhiding total sales for Sweden and Norway
         */
        private void ToggleAllSales(object sender, System.EventArgs e)
        {
            totSalesS.Visibility = totSalesS.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            totSalesN.Visibility = totSalesN.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        /*
         * Function for handling clicks on data points on the chart.
         */
        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            // System.Windows.MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
            setTxtButtons((int)chartPoint.X);
            setGridView((int)chartPoint.X);
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


                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year",
                    Labels = new[] { "2011", "2012", "2013", "2014", "2015", "2016" }
                });

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


                cartesianChart1.LegendLocation = LegendLocation.Right;


                System.Collections.Generic.List<double> co2sweden = co2.Where(i => i.coun == 1).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();
                System.Collections.Generic.List<double> co2norway = co2.Where(i => i.coun == 2).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();

                ChartValues<double> NCV = new ChartValues<double>();
                NCV.AddRange(co2sweden);
                ChartValues<double> SCV = new ChartValues<double>();
                SCV.AddRange(co2norway);

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

                cartesianChart1.Series.Add(SLS);
                cartesianChart1.Series.Add(NLS);
                cartesianChart1.LegendLocation = LegendLocation.Top;
                System.Windows.Controls.Panel.SetZIndex(SLS, 10);
                System.Windows.Controls.Panel.SetZIndex(NLS, 10);
            }
        }

        private void plot2()
        {
            DateTime startDate = new DateTime(2010, 1, 1);
            DateTime endDate = new DateTime(2017, 1, 1);
            List<BigView> Context = new List<BigView>();

            using (CarsDWEntities dw = new CarsDWEntities())
            {
                Context = dw.BigViews.Where(filter => filter.date >= startDate && filter.date < endDate).ToList();
            }

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

            //räknar ut procent
            procentSwe = salesSwe.Select(i => ((double)i.Elec / (double)i.Total * 100)).ToList();
            procentNor = salesNor.Select(i => ((double)i.Elec / (double)i.Total * 100)).ToList();

            years = salesNor.Select(x => "" + x.Key).ToList();

            setTxtButtons(years.IndexOf(years.Last()));

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Year",
                FontSize = 20,
                Labels = years.ToArray()
            });

            electricSalesS = new ColumnSeries
            {
                Values = electricSweden,
                Title = "Electric Sales Sweden",
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 107, 179))
            };
            totSalesS = new ColumnSeries
            {
                Values = totalSweden,
                Title = "Total Sales Sweden",
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(153, 214, 255))
            };

            elecSalesN = new ColumnSeries
            {
                Values = electricNorway,
                Title = "Electric Sales Norway",
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(179, 0, 0))

            };
            totSalesN = new ColumnSeries
            {
                Values = totalNorway,
                Title = "Total Sales Norway",
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 102, 102))
            };
            cartesianChart1.Series = new SeriesCollection
            {
                totSalesS,electricSalesS, elecSalesN, totSalesN
            };


            var co2 = Context.Select(f => new { year = f.year_no, co = f.CO2, coun = f.country_id });

            List<double> co2sweden = co2.Where(i => i.coun == 1).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();

            List<double> co2norway = co2.Where(i => i.coun == 2).GroupBy(g => g.year, g => g.co, (key, g) => new { year = key, co2 = (double)g.Sum() / 12 }).Select(filter => filter.co2).ToList();

            ChartValues<double> NCV = new ChartValues<double>();
            NCV.AddRange(co2norway);
            ChartValues<double> SCV = new ChartValues<double>();
            SCV.AddRange(co2sweden);

            cartesianChart1.AxisY.Add(new Axis { Title = "CarSales", MinValue = 0, LabelFormatter = val => (val / 1000 + "k"), FontSize = 16 });
            cartesianChart1.AxisY.Add(new Axis { Title = "Co2", MinValue = 0, Position = AxisPosition.RightTop, FontSize = 0.1 });
            LineSeries NLS = new LineSeries
            {
                Title = "Co2 Norway",
                Values = NCV,
                PointGeometry = null,
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(179, 0, 0)),
                Fill = System.Windows.Media.Brushes.Transparent,
                StrokeThickness = 4,
                ScalesYAt = 1,
            };

            LineSeries SLS = new LineSeries
            {
                Title = "Co2 Sweden",
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


            cartesianChart1.AxisX[0].MinValue = 1;
            cartesianChart1.AxisX[0].MaxValue = 7;

        }

        private void setTxtButtons(int index)
        {
            tbYear.Text = years[index];
            tbNorway.Text = Math.Round(procentNor[index], 2) + "%";
            tbSweden.Text = Math.Round(procentSwe[index], 2) + "%";
        }


        public void setGridView(int index)
        {
            int year = int.TryParse(years[index], out int value) ? value : 2016;
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                bindingNor.DataSource = dw.MarketEvents.Where(a => a.year_no == year && a.country_id == 2).Select(a => new { a.title, a.date, a.description }).ToList();
                
                dgvNor.DataSource = bindingNor;
                

                var sme = dw.MarketEvents.Where(a => a.year_no == year && a.country_id == 1).Select(a => new { a.title, a.date, a.description }).ToList();
                dgvSwe.DataSource = null;
                dgvSwe.Rows.Clear();
                dgvSwe.Refresh();
                dgvSwe.DataSource = sme;
               
            }
        }
    }
}
