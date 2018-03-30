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
    public partial class MiningTool : Form
    {
        private int xStartsAtDateYear;
        private int xStartsAtDateMonth;
        private int currentYscaleLs;
        private int currentYscaleCs;
        private Form pf;
        private SourceCodeGenerator sc;
        public MiningTool(Form parentForm)
        {
            sc = new SourceCodeGenerator();
            pf = parentForm as Form1;
            InitializeComponent();
            xStartsAtDateYear = 0;
            xStartsAtDateMonth = 0;
            currentYscaleLs = 0;
            currentYscaleCs = 0;

        }

        private void InputData_Load(object sender, EventArgs e)
        {

            PopulateComboBoxes();
            dataGridView1.AutoGenerateColumns = false;
            cartesianChart1.LegendLocation = LegendLocation.Right;


        }



        private void DrawGraph(int country_id, string xtitle, string ytitle, string pickedColumn, string typeofcalculation, string graphtype, string granularity, int start_year_no, int end_year_no, bool add, bool isFloat, bool addScaleY)
        {


            if (add == false)
            {
                xStartsAtDateYear = 0;
                xStartsAtDateMonth = 0;
                currentYscaleLs = 0;
                currentYscaleCs = 0;
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();

            }

            using (CarsDWEntities dw = new CarsDWEntities())
            {

                List<BigView> Context = dw.BigViews.Where(c => c.country_id == country_id).ToList();


                string country_name = dw.Countries.Where(c => c.country_id == country_id).Select(a => a.name).FirstOrDefault();
                //per år
                //hämtar min o max
                int max = Context.Max(a => a.year_no);
                int min = Context.Min(a => a.year_no);
                if (!(start_year_no < min))
                {
                    min = start_year_no;
                }
                if (!(end_year_no > max))
                {
                    max = end_year_no;

                }
                //MOUSE HOVER TA EJ BORT 
                if (xStartsAtDateYear == 0)
                {
                    xStartsAtDateYear = min;

                }

                GenerateSourceCodeGraph(country_id, xtitle, ytitle, pickedColumn, typeofcalculation, graphtype, granularity, min, max, add, isFloat, addScaleY);





                List<int> y = new List<int>();
                List<double> yAsDouble = new List<double>();

                List<string> x = new List<string>();
                for (int i = min; i <= max; i++) //för varje år
                {
                    switch (granularity.ToLower())
                    {
                        case "year":


                            x.Add(i.ToString());//year as x values
                            var hjalp = Context.Where(b => b.year_no == i).Select(pickedColumn);
                            if (!isFloat)
                            {
                                int sum = 0;
                                //summerar
                                foreach (int h in hjalp)
                                {
                                    sum += h;
                                }
                                //lägger till
                                y.Add(sum);
                            }
                            else //float
                            {
                                double sum = 0;
                                //summerar
                                foreach (double h in hjalp)
                                {
                                    sum += h;
                                }
                                //lägger till
                                yAsDouble.Add(sum);

                            }

                            break;
                        case "month":
                            //addarer y 12 gånger per år el hur många månader som det nu finns
                            int maxmonth = Context.Where(C => C.year_no == i).Max(m => m.month_no);
                            int minmonth = Context.Where(C => C.year_no == i).Min(m => m.month_no);
                            //hjälp till hoverfunktionen TA EJ BORT
                            if (xStartsAtDateMonth == 0)
                            {
                                xStartsAtDateMonth = minmonth;
                            }
                            for (int m = minmonth; m <= maxmonth; m++) //för månad
                            {
                                var hjalp1 = Context.Where(b => b.year_no == i && b.month_no == m).Select(pickedColumn);
                                if (!isFloat)
                                {
                                    int sumM = 0;
                                    //summerar
                                    foreach (int h in hjalp1)
                                    {
                                        sumM += h;
                                    }
                                    //lägger till
                                    y.Add(sumM);
                                }
                                else //floathjälp1
                                {

                                    double sumM = 0;
                                    //summerar
                                    foreach (double h in hjalp1)
                                    {
                                        sumM += h;
                                    }
                                    //lägger till
                                    yAsDouble.Add(sumM);
                                }




                                x.Add(i.ToString() + "-" + m.ToString());
                            }

                            break;

                        default:
                            break;
                    }

                }
                //Klar med listorna av x o y värden


                ChartValues<double> cvy = new ChartValues<double>();

                if (!isFloat) //integer
                {
                    cvy.AddRange(y.Select(a => (double)a).ToArray());

                }
                else //double
                {
                    cvy.AddRange(yAsDouble.ToArray());
                }
                //typ av graf y värden
                ColumnSeries cs = new ColumnSeries();
                LineSeries ls = new LineSeries();

                //Hanterar skalor och lägger in värden i series
                switch (graphtype.ToLower())
                {
                    case "column":
                        cs.Title = country_name + " " + pickedColumn;
                        cs.Values = cvy;
                        //man vill lägga till en skala, ökar skalindex på resp
                        if (addScaleY == true)
                        {
                            currentYscaleCs++;

                        }
                        cs.ScalesYAt = currentYscaleCs;
                        break;
                    case "line":
                        ls.Title = country_name + " " + pickedColumn;
                        ls.Values = cvy;
                        //ökar skalindex
                        if (addScaleY == true)
                        {
                            currentYscaleLs++;

                        }
                        ls.ScalesYAt = currentYscaleLs;
                        break;
                    default:
                        break;
                }


                int numberofXAxis = cartesianChart1.AxisX.Count();
                int numberofYAxis = cartesianChart1.AxisY.Count();
                //stoppar bara in x om det inte finns
                if (numberofXAxis == 0)
                {

                    cartesianChart1.AxisX.Add(new Axis
                    {
                        Title = xtitle,
                        Labels = x.ToArray()
                    });

                    cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = ytitle,
                        LabelFormatter = value => value.ToString()
                    });
                }
                else if (addScaleY == true && numberofXAxis != 0 && add == true) //det är inte den första graphen och man vill lägga till en ny skala
                {
                    cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = ytitle,
                        LabelFormatter = value => value.ToString()
                    });
                }

                if (add)
                {
                    switch (graphtype.ToLower())
                    {
                        case "column":
                            cartesianChart1.Series.Add(cs);
                            break;
                        case "line":
                            cartesianChart1.Series.Add(ls);
                            break;

                        default:
                            break;
                    }
                }
                else
                {

                    switch (graphtype.ToLower())
                    {
                        case "column":
                            cartesianChart1.Series.Clear();
                            cartesianChart1.Series.Add(cs);
                            break;
                        case "line":
                            cartesianChart1.Series.Clear();
                            cartesianChart1.Series.Add(ls);
                            break;
                        default:
                            break;
                    }

                }

            }

        }



        private void cartesianChart1_DataHover(object sender, ChartPoint p)
        {
            if (xStartsAtDateMonth == 0 && xStartsAtDateYear != 0)
            {
                //år verkar valt
                int yr = (int)p.X + xStartsAtDateYear;





                using (CarsDWEntities dw = new CarsDWEntities())
                {
                    if (p.SeriesView.Title.Contains("Norge")) //Norway
                    {
                        var me = dw.MarketEvents.Where(a => a.year_no == yr && a.country_id == 2).Select(a => new { a.title, a.date, a.country_name, a.description }).ToList();

                        dataGridView1.DataSource = me;
                    }
                    else if (p.SeriesView.Title.Contains("Sverige"))
                    {

                        var me = dw.MarketEvents.Where(a => a.year_no == yr && a.country_id == 1).Select(a => new { a.title, a.date, a.country_name, a.description }).ToList();

                        dataGridView1.DataSource = me;

                    }


                }
                // label1.Text = yr.ToString();
            }
            else if (xStartsAtDateYear != 0 && xStartsAtDateMonth != 0)
            {
                //räknar antalet månader fram
                DateTime d = new DateTime(xStartsAtDateYear, 1, 1);
                d = d.AddMonths((int)p.X);
                int yr = d.Year;
                int mnth = d.Month;
                using (CarsDWEntities dw = new CarsDWEntities())
                {
                    if (p.SeriesView.Title.Contains("Norge")) //norway
                    {

                        var me = dw.MarketEvents.Where(a => a.year_no == yr && a.month_no == mnth && a.country_id == 2).Select(a => new { a.date, a.country_name, a.description, a.title }).ToList();
                        dataGridView1.DataSource = me;

                    }
                    else if (p.SeriesView.Title.Contains("Sverige")) //sweden
                    {
                        var me = dw.MarketEvents.Where(a => a.year_no == yr && a.month_no == mnth && a.country_id == 2).Select(a => new { a.date, a.country_name, a.description, a.title }).ToList();
                        dataGridView1.DataSource = me;

                    }
                }
                // label1.Text = yr.ToString() + mnth.ToString();
            }

        }
        private void PopulateComboBoxes()
        {
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                comboBox1.DataSource = dw.Countries.ToList();
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "country_id";


                comboBox2.Items.Add(new CbItem("Electric Cars", "CarSales", "electric", "sum"));
                comboBox2.Items.Add(new CbItem("Hybrid Cars", "CarSales", "hybrids", "sum"));
                comboBox2.Items.Add(new CbItem("Petrol/Diesel Cars", "CarSales", "liquid_fuel", "sum"));
                comboBox2.Items.Add(new CbItem("All Cars", "CarSales", "total", "sum"));
                comboBox2.Items.Add(new CbItem("Co2", "CarSales", "CO2", "sum"));
                comboBox2.Items.Add(new CbItem("Market", "CarSales", "has_market_events", "sum"));



                comboBox2.Items.Add(new CbItem("Average Salary", "Avg_Salary", "avg_salary", "sum"));
                comboBox2.Items.Add(new CbItem("Gas Price", "GasPrice", "gas_price", "sum", true));
                comboBox2.Items.Add(new CbItem("Charging Points", "ChargingPoint", "charging_points", "sum"));
                comboBox2.SelectedIndex = 0;

                comboBox3.Items.Add(new CbItem("Year"));
                comboBox3.Items.Add(new CbItem("Month"));
                comboBox3.Items.Add(new CbItem("Day"));
                comboBox3.SelectedIndex = 0;

                comboBox4.Items.Add(new CbItem("Column"));
                comboBox4.Items.Add(new CbItem("Line"));
                comboBox4.SelectedIndex = 0;

            }
        }



        private void InputData_FormClosing(object sender, FormClosingEventArgs e)
        {

            pf.Show();
            this.Hide();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Country cbiCountry = (Country)comboBox1.SelectedItem;
            CbItem cbiSelectionData = (CbItem)comboBox2.SelectedItem;
            CbItem cbiGran = (CbItem)comboBox3.SelectedItem;
            CbItem cbiGraphType = (CbItem)comboBox4.SelectedItem;
            bool validIntStartYear = Int32.TryParse(txtBStartYearNo.Text, out int start_year_no);
            bool validIntEndYear = Int32.TryParse(txtBEndYearNo.Text, out int end_year_no);
            if (!validIntEndYear)
            {
                end_year_no = 999999;
            }
            if (!validIntStartYear)
            {
                start_year_no = 0;
            }

            //drawGraph(1, "År", "elbilar sålda", "electric", "sum", "column", "year", false);

            DrawGraph(cbiCountry.country_id, cbiGran.Text, cbiSelectionData.Column, cbiSelectionData.Column, cbiSelectionData.TypeOfCalculation, cbiGraphType.Text, cbiGran.Text, start_year_no, end_year_no, checkBox1.Checked, cbiSelectionData.IsFloat, checkBox2.Checked);
            //testSourceCode();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sc.CreateSourceCodeFile())
            {
                //source code created
                MessageBox.Show(sc.GetProcedure());
            }
        }
        private void GenerateSourceCodeGraph(int country_id, string xtitle, string ytitle, string pickedColumn, string typeofcalculation, string graphtype, string granularity, int start_year_no, int end_year_no, bool add, bool isFloat, bool addScaleY)
        {
            if (!add)
            {
                //rensar data o börjar på bygget
                sc.Clear();

            }

            string country_name = "";
            using (CarsDWEntities dw = new CarsDWEntities())
            {

                List<BigView> Context = dw.BigViews.Where(c => c.country_id == country_id).ToList();
                country_name = dw.Countries.Where(c => c.country_id == country_id).Select(a => a.name).FirstOrDefault();
            }

            sc.generateStaticContext(country_id.ToString(),add);

            sc.GenerateXYValuesYear(pickedColumn, start_year_no.ToString(), end_year_no.ToString(), isFloat);

            sc.addSeries(country_name, pickedColumn, graphtype.ToLower(), xtitle, ytitle, addScaleY, add);

            sc.FinishUsing();
        }


        public void testSourceCode()
        {
            //AUTO GENERATED SOURCE CODE FOR LIVE CHART USING CARSDWENTITIES
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<BigView> Context = dw.BigViews.Where(c => c.country_id == 2).ToList();


                string country_name = dw.Countries.Where(c => c.country_id == 2).Select(a => a.name).FirstOrDefault();
                List<double> yAsDouble = new List<double>();

                List<string> x = new List<string>();
                for (int i = 2009; i <= 2016; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("total");
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
                LineSeries ls = new LineSeries();


                ls.Title = "Norge" + " total";
                ls.Values = cvy;
                ls.ScalesYAt = 0;
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year",
                    Labels = x.ToArray()
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "total",
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
                for (int i = 2009; i <= 2016; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("total");
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

                LineSeries ls = new LineSeries();
                ls.Title = "Sverige" + " total";
                ls.Values = cvy;
                ls.ScalesYAt = 0; cartesianChart1.Series.Add(ls);


            }
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<BigView> Context = dw.BigViews.Where(c => c.country_id == 2).ToList();


                string country_name = dw.Countries.Where(c => c.country_id == 2).Select(a => a.name).FirstOrDefault();
                List<double> yAsDouble = new List<double>();

                List<string> x = new List<string>();
                for (int i = 2009; i <= 2016; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("electric");
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
                cs.Title = "Norge" + " electric";
                cs.Values = cvy;
                cs.ScalesYAt = 0; cartesianChart1.Series.Add(cs);


            }
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                List<BigView> Context = dw.BigViews.Where(c => c.country_id == 1).ToList();


                string country_name = dw.Countries.Where(c => c.country_id == 1).Select(a => a.name).FirstOrDefault();
                List<double> yAsDouble = new List<double>();

                List<string> x = new List<string>();
                for (int i = 2009; i <= 2016; i++) //för varje år
                {
                    x.Add(i.ToString());//year as x values
                    var hjalp = Context.Where(b => b.year_no == i).Select("electric");
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
                cs.Title = "Sverige" + " electric";
                cs.Values = cvy;
                cs.ScalesYAt = 0; cartesianChart1.Series.Add(cs);


            }
        }








        private void button3_Click(object sender, EventArgs e)
        {
            testSourceCode();
        }
    }







    public class CbItem
    {
        public string Text { get; set; }
        public string Table { get; set; }
        public string Column { get; set; }
        public string TypeOfCalculation { get; set; }
        public int Value { get; set; }
        public bool IsFloat { get; set; }
        public override string ToString()
        {
            return this.Text;
        }

        public CbItem()
        {

        }

        public CbItem(string t, int v)
        {
            Text = t;
            Value = v;

        }

        public CbItem(string t)
        {
            Text = t;

        }
        public CbItem(string t, string ta)
        {
            Text = t;
            Table = ta;

        }
        public CbItem(string t, string ta, string c)
        {
            Text = t;
            Table = ta;
            Column = c;


        }
        public CbItem(string t, string ta, string c, string toc)
        {
            Text = t;
            Table = ta;
            Column = c;
            TypeOfCalculation = toc;


        }
        public CbItem(string t, string ta, string c, string toc, bool isfl)
        {
            Text = t;
            Table = ta;
            Column = c;
            TypeOfCalculation = toc;
            IsFloat = isfl;


        }
    }
}