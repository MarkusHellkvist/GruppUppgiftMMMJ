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
using System.Threading;
using LiveCharts.Defaults;

namespace GruppuppgiftMMMJ
{
    public partial class Form2 : Form
    {
        private Form pf;
        private int year_start = 2011;
        private int year_end = 2017;
        private int current_year;

        //satt statisk pga visualisering
        private PieSeries otherCarsSveSeries = new PieSeries();
        private PieSeries otherCarsNoSeries = new PieSeries();

        private PieSeries elbilSveSeries = new PieSeries();
        private PieSeries elbilNoSeries = new PieSeries();



        public Form2(Form parentform)
        {
            InitializeComponent();
            pf = parentform;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DrawSveNoSkillnadAntal();
            DrawPieChart1();
            DrawPieChart2();
            pieChart2.DisableAnimations = true;
            pieChart1.DisableAnimations = true;
            pieChart1.InnerRadius = 30;
            pieChart2.InnerRadius = 30;
        }
        private void DrawPieChart1()
        {

            Func<ChartPoint, string> labelPoint = chartPoint =>
                    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            double totalcarsminuselectric = 0;
            double electric = 0;


            otherCarsSveSeries = new PieSeries
            {
                Title = "Övriga bilar",
                DataLabels = false,
                LabelPoint = labelPoint
            };


            elbilSveSeries = new PieSeries
            {
                Title = "Elbilar",
                DataLabels = false,
                PushOut = 2,
                LabelPoint = labelPoint
            };




            pieChart1.LegendLocation = LegendLocation.Bottom;
            pieChart1.StartingRotationAngle = -40;

            using (CarsDWEntities dw = new CarsDWEntities())
            {
                int i = year_start;

                double total = (double)dw.BigViews.Where(a => a.country_id == 1 && a.year_no == i).Sum(b => b.total);
                electric = (double)dw.BigViews.Where(a => a.country_id == 1 && a.year_no == i).Sum(b => b.electric);
                totalcarsminuselectric = total - electric;

                ChartValues<ObservableValue> cvOther = new ChartValues<ObservableValue>();
                ChartValues<ObservableValue> cvElectric = new ChartValues<ObservableValue>();
                //SVERIGE
                //Sätter den statisk ist för visualiseringspurposes
                cvOther.Add(new ObservableValue(1000)); //snabbt uppskattad avg per mån
                cvElectric.Add(new ObservableValue(electric));
                otherCarsSveSeries.Values = cvOther;
                elbilSveSeries.Values = cvElectric;

                pieChart1.Series.Add(otherCarsSveSeries);
                pieChart1.Series.Add(elbilSveSeries);


            }





        }
        private void DrawPieChart2()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            double totalcarsminuselectric = 0;
            double electric = 0;
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                double total = (double)dw.BigViews.Where(a => a.country_id == 2 && a.year_no == 2016).Sum(b => b.total);
                electric = (double)dw.BigViews.Where(a => a.country_id == 2 && a.year_no == 2016).Sum(b => b.electric);
                totalcarsminuselectric = total - electric;
            }

            otherCarsNoSeries = new PieSeries
            {
                Title = "Övriga bilar Norge",
                DataLabels = false,
                LabelPoint = labelPoint
            };


            elbilNoSeries = new PieSeries
            {
                Title = "Elbilar Norge",
                DataLabels = false,
                PushOut = 2,
                LabelPoint = labelPoint
            };

            ChartValues<double> cvOther = new ChartValues<double>();
            ChartValues<double> cvElectric = new ChartValues<double>();
            cvOther.Add(12000);
            cvElectric.Add(electric);
            otherCarsNoSeries.Values = cvOther;
            elbilNoSeries.Values = cvElectric;
            pieChart2.Series.Add(otherCarsNoSeries);
            pieChart2.Series.Add(elbilNoSeries);
          

            pieChart2.LegendLocation = LegendLocation.Bottom;
            



        }

        private void DrawSveNoSkillnadAntal()
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
                for (int i = 2011; i <= 2016; i++) //för varje år
                {
                    //addarer y 12 gånger per år el hur många månader som det nu finns
                    int maxmonth = Context.Where(C => C.year_no == i).Max(m => m.month_no);
                    int minmonth = Context.Where(C => C.year_no == i).Min(m => m.month_no);

                    for (int m = minmonth; m <= maxmonth; m++) //för månad
                    {
                        var hjalp1 = Context.Where(b => b.year_no == i && b.month_no == m).Select("electric");
                        int sumM = 0;
                        //summerar
                        foreach (int h in hjalp1)
                        {
                            sumM += h;
                        }
                        //lägger till
                        yAsDouble.Add(sumM);


                        x.Add(i.ToString() + "-" + m.ToString());
                    }

                }
                ChartValues<double> cvy = new ChartValues<double>();
                cvy.AddRange(yAsDouble.ToArray());
                ColumnSeries cs = new ColumnSeries();


                cs.Title = "Norge" + " electric";
                cs.Values = cvy;
                cs.ScalesYAt = 0;
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Month",
                    Labels = x.ToArray()
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "electric",
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
                for (int i = 2011; i <= 2016; i++) //för varje år
                {
                    //addarer y 12 gånger per år el hur många månader som det nu finns
                    int maxmonth = Context.Where(C => C.year_no == i).Max(m => m.month_no);
                    int minmonth = Context.Where(C => C.year_no == i).Min(m => m.month_no);

                    for (int m = minmonth; m <= maxmonth; m++) //för månad
                    {
                        var hjalp1 = Context.Where(b => b.year_no == i && b.month_no == m).Select("electric");
                        int sumM = 0;
                        //summerar
                        foreach (int h in hjalp1)
                        {
                            sumM += h;
                        }
                        //lägger till
                        yAsDouble.Add(sumM);


                        x.Add(i.ToString() + "-" + m.ToString());
                    }

                }
                ChartValues<double> cvy = new ChartValues<double>();
                cvy.AddRange(yAsDouble.ToArray());

                ColumnSeries cs = new ColumnSeries();
                cs.Title = "Sverige" + " electric";
                cs.Values = cvy;
                cs.ScalesYAt = 0; cartesianChart1.Series.Add(cs);


            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(backgroundWorker1.IsBusy))
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            current_year = year_start;
            int i = year_start;
            while (i < year_end)
            {
                int m = 1;
                while (m < 13)
                {
                    backgroundWorker1.ReportProgress(m);
                    Thread.Sleep(2000);
                    m++;
                }
                i++;

                current_year = i;

            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = e.ProgressPercentage;
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                double total = (double)dw.BigViews.Where(a => a.country_id == 1 && a.year_no == current_year && a.month_no == i).Sum(b => b.total);
                double electric = (double)dw.BigViews.Where(a => a.country_id == 1 && a.year_no == current_year && a.month_no == i).Sum(b => b.electric);
                double totalcarsminuselectric = total - electric;

                //cvTemp2.Add(totalcarsminuselectric);
                elbilSveSeries.Values = new ChartValues<ObservableValue> { new ObservableValue(electric) };
                //  otherCarsSveSeries.Values = cvTemp2;

                //tar hand om norge
                //double total = (double)dw.BigViews.Where(a => a.country_id == 1 && a.year_no == current_year && a.month_no == i).Sum(b => b.total);
               double electricNo = (double)dw.BigViews.Where(a => a.country_id == 2 && a.year_no == current_year && a.month_no == i).Sum(b => b.electric);
                //double totalcarsminuselectric = total - electric;


                
               // cvtemp3.Add(electricNo);
               // elbilNoSeries.Values = cvtemp3;



            }
        }
    }
}
