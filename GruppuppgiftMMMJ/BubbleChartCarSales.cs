using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GruppuppgiftMMMJ
{
    public partial class BubbleChartCarSales : Form
    {
        public Form parentForm;
        private struct Bubbla
        {
            double co2;
            double andel_elbilar_av_total_forsaljning;
            double antal_elbilar;
            
            public double Co2 { get => co2; set => co2 = value; }
            public double Andel_elbilar_av_total_forsaljning { get => andel_elbilar_av_total_forsaljning; set => andel_elbilar_av_total_forsaljning = value; }
            public double Antal_elbilar { get => antal_elbilar; set => antal_elbilar = value; }
        }
        private int ms=7000;
        private int start_year;
        private int end_year;
        private int current_year;
        private Bubbla norgebubbla;
        private Bubbla sverigebubbla;
        private ScatterSeries SSNorge = new ScatterSeries();
        private ScatterSeries SSSverige = new ScatterSeries();
        private ChartValues<ScatterPoint> CVNorge = new ChartValues<ScatterPoint>();
        private ChartValues<ScatterPoint> CVSverige = new ChartValues<ScatterPoint>();
        private ScatterPoint SPNorge = new ScatterPoint();
        private ScatterPoint SPSverige = new ScatterPoint();

        private ScatterSeries SSreference = new ScatterSeries();
        private ChartValues<ScatterPoint> CVReference = new ChartValues<ScatterPoint>();
        private ScatterPoint SPReference = new ScatterPoint();
        private ScatterSeries SSreferenceMin = new ScatterSeries();
        private ChartValues<ScatterPoint> CVReferenceMin = new ChartValues<ScatterPoint>();
        private ScatterPoint SPReferenceMin = new ScatterPoint();

        public BubbleChartCarSales(Form pf)
        {
            parentForm = pf;
            InitializeComponent();
          
        }

        private void BubbleChartCarSales_Load(object sender, EventArgs e)
        {
            start_year = 2007;
            end_year = 2017;
            textBox1.Text = "7000";


            norgebubbla.Antal_elbilar = 0;
            norgebubbla.Andel_elbilar_av_total_forsaljning = 0;
            norgebubbla.Co2 = 0;
            SPNorge.Y = norgebubbla.Andel_elbilar_av_total_forsaljning;
            SPNorge.X = norgebubbla.Co2;
            SPNorge.Weight = norgebubbla.Antal_elbilar;
            CVNorge.Add(SPNorge);
            SSNorge.Values = CVNorge;
            SSNorge.Title = "Norge";
            SSNorge.DataLabels = true;
            SSNorge.LabelPoint = p => "Norge";//nElbilar " + p.Weight + " st";
            cartesianChart1.Series.Add(SSNorge);


            sverigebubbla.Antal_elbilar = 0;
            sverigebubbla.Andel_elbilar_av_total_forsaljning = 0;
            sverigebubbla.Co2 = 0;
            SPSverige.Y = sverigebubbla.Andel_elbilar_av_total_forsaljning;
            SPSverige.X = sverigebubbla.Co2;
            SPSverige.Weight = sverigebubbla.Antal_elbilar;
            CVSverige.Add(SPSverige);
            SSSverige.Values = CVSverige;
            SSSverige.Title = "Sverige";
            SSSverige.DataLabels = true;
            SSSverige.LabelPoint = p => "Sverige";//\nElbilar " + p.Weight + " st";
            cartesianChart1.Series.Add(SSSverige);

            //Referenschartseries MAX
            SPReference.Weight = 30000;
            SPReference.X = -100;
            SPReference.Y = 20;
            CVReference.Add(SPReference);
            SSreference.Title = "Ref Max";
            SSreference.DataLabels = false;
         //   SSreference.LabelPoint = p => "Vikt: " + p.Weight;
            SSreference.Values = CVReference;
            cartesianChart1.Series.Add(SSreference);

            //Referenschartseries Min
            SPReferenceMin.Weight = -1000;
            SPReferenceMin.X = -100;
            SPReferenceMin.Y = 20;
            CVReferenceMin.Add(SPReferenceMin);
            SSreferenceMin.Title = "Ref Min";
            SSreference.DataLabels = false;
            //   SSreference.LabelPoint = p => "Vikt: " + p.Weight;
            SSreferenceMin.Values = CVReferenceMin;
            cartesianChart1.Series.Add(SSreferenceMin);



            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Add(new Axis { MaxValue = 180, MinValue = 60, Title = "gram CO2/Km" });
            cartesianChart1.AxisY.Add(new Axis { MaxValue = 50, MinValue = 0, Title = "Andel Elbilar av Total Försäljning %" });

            SSNorge.MinPointShapeDiameter = 10;
            SSNorge.MaxPointShapeDiameter = 400;
            SSSverige.MinPointShapeDiameter = 10;
            SSSverige.MaxPointShapeDiameter = 400;
            SSreference.MinPointShapeDiameter = 10;
            SSreference.MaxPointShapeDiameter = 400;
            SSreferenceMin.MinPointShapeDiameter = 10;
            SSreferenceMin.MaxPointShapeDiameter = 400;

            cartesianChart1.AnimationsSpeed = TimeSpan.FromMilliseconds(1500);
            cartesianChart1.AxisX[0].FontSize = 22;
            cartesianChart1.AxisY[0].FontSize = 22;
            cartesianChart1.AxisX[0].FontWeight = System.Windows.FontWeights.Black;
            cartesianChart1.AxisY[0].FontWeight = System.Windows.FontWeights.Black;
            cartesianChart1.AxisY[0].Foreground = System.Windows.Media.Brushes.Black;
            cartesianChart1.AxisX[0].Foreground = System.Windows.Media.Brushes.Black;
            SSNorge.FontSize = 22;
            SSSverige.FontSize = 22;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            //hämtar norgedata
            int i = start_year;
            current_year = start_year;
            while (i < end_year)
            {
                backgroundWorker1.ReportProgress(i);
                Thread.Sleep(ms);




                i++;
                current_year = i;
            }


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            current_year = e.ProgressPercentage; //pprcntg skickar månaden
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                int country_id = 2;
                norgebubbla.Co2 = (double)dw.BigViews.Where(a => a.country_id == country_id && a.year_no == current_year).Sum(a => a.CO2) / 12;
                //beräknar procent antal elbilar av tot förs
                //hämtar tot

                double total = (double)dw.BigViews.Where(a => a.country_id == country_id && a.year_no == current_year).Sum(a => a.total);
                norgebubbla.Antal_elbilar = (double)dw.BigViews.Where(a => a.country_id == country_id && a.year_no == current_year).Sum(a => a.electric);
                norgebubbla.Andel_elbilar_av_total_forsaljning = norgebubbla.Antal_elbilar / (total) * 100;
                //ritar
                SPNorge.Y = norgebubbla.Andel_elbilar_av_total_forsaljning;
                SPNorge.X = norgebubbla.Co2;
                SPNorge.Weight = norgebubbla.Antal_elbilar;
                CVNorge.Clear();
                CVNorge.Add(SPNorge);
                SSNorge.Values = CVNorge;

            }
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                int country_id = 1;
                sverigebubbla.Co2 = (double)dw.BigViews.Where(a => a.country_id == country_id && a.year_no == current_year).Sum(a => a.CO2) / 12;
                //beräknar procent antal elbilar av tot förs
                //hämtar tot

                double total = (double)dw.BigViews.Where(a => a.country_id == country_id && a.year_no == current_year).Sum(a => a.total);
                sverigebubbla.Antal_elbilar = (double)dw.BigViews.Where(a => a.country_id == country_id && a.year_no == current_year).Sum(a => a.electric);
                sverigebubbla.Andel_elbilar_av_total_forsaljning = sverigebubbla.Antal_elbilar / (total) * 100;
                //ritar
                SPSverige.Y = sverigebubbla.Andel_elbilar_av_total_forsaljning;
                SPSverige.X = sverigebubbla.Co2;
                SPSverige.Weight = sverigebubbla.Antal_elbilar;
                CVSverige.Clear();
                CVSverige.Add(SPSverige);
                SSSverige.Values = CVSverige;

            }
            

            label1.Text = "Year " + current_year.ToString();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(textBox1.Text,out ms);
            if (!(backgroundWorker1.IsBusy))
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }
    }
}
