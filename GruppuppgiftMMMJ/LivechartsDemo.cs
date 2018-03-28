using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;

namespace GruppuppgiftMMMJ
{
    public partial class LivechartsDemo : Form
    {
        Form parentForm;
        public LivechartsDemo(Form pf)
        {
            InitializeComponent();
            parentForm = pf;
        }

        private void LivechartsDemo_Load(object sender, EventArgs e)
        {
            
            //angularGaugeNorway();
            //gaugePlot();
            //piePlot();
            cartesianPlot();
        }

        private void InputData_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            parentForm.Show(); 
        }

        // test function for angularGauge1
        private void angularGaugeNorway()
        {
            angularGauge1.Value = 50;
            angularGauge1.FromValue = 0;
            angularGauge1.ToValue = 100;
            angularGauge1.TicksForeground = Brushes.White;
            angularGauge1.Base.Foreground = Brushes.White;
            angularGauge1.Base.FontWeight = System.Windows.FontWeights.Bold;
            angularGauge1.Base.FontSize = 16;
            angularGauge1.SectionsInnerRadius = 0.5;
            {
                angularGauge1.Sections.Add(new AngularSection
                {
                    FromValue = 0,
                    ToValue = 30,
                    Fill = new SolidColorBrush(Color.FromRgb(247, 166, 37))
                });
                angularGauge1.Sections.Add(new AngularSection
                {
                    FromValue = 50,
                    ToValue = 100,
                    Fill = new SolidColorBrush(Color.FromRgb(254, 57, 57))
                });

            };
        }


        // test function for angularGauge1
        private void gaugePlot()
        {
            angularGauge1.Value = 160;
            angularGauge1.FromValue = 50;
            angularGauge1.ToValue = 1000;
            angularGauge1.TicksForeground = Brushes.White;
            angularGauge1.Base.Foreground = Brushes.White;
            angularGauge1.Base.FontWeight = System.Windows.FontWeights.Bold;
            angularGauge1.Base.FontSize = 16;
            angularGauge1.SectionsInnerRadius = 0.5;

            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 50,
                ToValue = 200,
                Fill = new SolidColorBrush(Color.FromRgb(247, 166, 37))
            });
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 200,
                ToValue = 250,
                Fill = new SolidColorBrush(Color.FromRgb(254, 57, 57))
            });
        }

        // Test function for the cartesianchart.
        private void cartesianPlot()
        {
            List<BigView> Context = new List<BigView>();
            System.Collections.Generic.List<double> swePro = new System.Collections.Generic.List<double>();
            System.Collections.Generic.List<double> norPro = new System.Collections.Generic.List<double>();
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                Context = dw.BigViews.Where(filter => filter.date >= new DateTime(2011, 1, 1) && filter.date < new DateTime(2017, 1, 1)).ToList();
                var dataSweden = dw.BigViews.Where(e => e.date > new DateTime(2011, 1, 1) && e.country_id == 1).Select(Q => new { ev = (double)Q.electric, tot = (double)Q.total }).Select(QW => new { result = (QW.ev / QW.tot) * 100 });
                var dataNoway = dw.BigViews.Where(e => e.date > new DateTime(2011, 1, 1) && e.country_id == 2).Select(Q => new { ev = (double)Q.electric, tot = (double)Q.total }).Select(QW => new { result = (QW.ev / QW.tot) * 100 });

                //swePro = Context.Where(c => c.country_id == 1).Select(s => new { tot = (double)s.electric / s.total }).Select(t => t.tot).ToList();//dataSweden.Select(x => x.result).ToList();
                swePro = dataSweden.Select(x => x.result).ToList();
                norPro = dataNoway.Select(x => x.result).ToList();
            }

            /*var No = dw.BigViews.Where(e => e.date > new DateTime(2011, 1, 1) && e.carsales_id == 2).Select(x => new { total = (double)x.total, elec = (double)x.electric,date = x.date });
                System.Collections.Generic.List<int> norge = new System.Collections.Generic.List<int>();
                norge = dw.BigViews.Where(e => e.date > new DateTime(2011, 1, 1) && e.country_id == 2).Select(Q => (int)Q.electric).ToList();
                System.Collections.Generic.List<int> svergie = new System.Collections.Generic.List<int>();
                svergie = 
                dw.BigViews.Where(e => e.date > new DateTime(2011, 1, 1) && e.carsales_id == 1).Select(x => new { proc = (double)x.electric / (double)x.total });
                var proc = No.Select(y => new { proc = (y.total / y.elec) });
                */
            ChartValues<double> NCV = new ChartValues<double>();
            NCV.AddRange(norPro);
            ChartValues<double> SCV = new ChartValues<double>();
            SCV.AddRange(swePro);

            LineSeries NLS = new LineSeries();
            NLS.Title = "Norge";
            NLS.Values = NCV;
            NLS.PointGeometry = null;
            NLS.StrokeThickness = 4;

            LineSeries SLS = new LineSeries();
            SLS.Title = "Svedala";
            SLS.Values = SCV;
            SLS.PointGeometry = null;
            SLS.StrokeThickness = 4;

            cartesianChart1.Series = new SeriesCollection
            {
                NLS,SLS
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                MinValue = 0,
                MaxValue = 11
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Procent",
                
                MinValue = 0,
                MaxValue = 50,
                LabelFormatter = val => val + "%",
                Separator = new Separator
                {
                    Step = 5,
                    IsEnabled = false
                }
            });
            cartesianChart1.LegendLocation = LegendLocation.Right;

            cartesianChart1.DataClick += CartesianChart1OnDataClick;
            /*
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });
            
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Procent"
                //LabelFormatter = value => value.ToString("C")
            });
            
            
            //modifying the series collection will animate and update the chart
            
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                LineSmoothness = 0, //straight lines, 1 really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });
            
            //modifying any series values will also animate and update the chart
            //cartesianChart1.Series[2].Values.Add(5d);
            */

        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }
        /*
        private void piePlot()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Maria",
                    Values = new ChartValues<double> {3},
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Charles",
                    Values = new ChartValues<double> {4},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Frida",
                    Values = new ChartValues<double> {6},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Frederic",
                    Values = new ChartValues<double> {2},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }
        */
        
    /*
        private void button1_Click(object sender, EventArgs e)
        {
            angularGauge1.Value += 3;
            //solidGauge1.Value += 10;
        }
        */
        /*
        private void PreviousOnClick(object sender, EventArgs e)
        {
            cartesianChart1.AxisX[0].MinValue -= 12;
            cartesianChart1.AxisX[0].MaxValue -= 12;
            angularGauge1.Value -= 1;
        }
        private void forwardOnClick(object sender, EventArgs e)
        {
            cartesianChart1.AxisX[0].MinValue += 12;
            cartesianChart1.AxisX[0].MaxValue += 12;
            //solidGauge1.Value += 1;
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void angularGauge2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }

}
