using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppuppgiftMMMJ
{


    class SourceCodeGenerator
    {

        private List<OutputObject> outputObjects;
        private int numberOfXAxis;
        private int seriesNo;
        private int currentYscale;
        public int NumberOfXAxis { get => numberOfXAxis; set => numberOfXAxis = value; }

        public SourceCodeGenerator()
        {
            //Constructor
            outputObjects = new List<OutputObject>();
            NumberOfXAxis = 0;
            seriesNo = 0;
            currentYscale = 0;
        }
        public void FinishUsing()
        {
            OutputObject opo = new OutputObject();
            opo.Code = "\n\n" + @"}";
            opo.Function = "FinishUsing";
            opo.Id = seriesNo.ToString();
            outputObjects.Add(opo);
            seriesNo++;
        }

        public void Clear()
        {
            outputObjects.Clear();
            numberOfXAxis = 0;
            seriesNo = 0;
            currentYscale = 0;
        }

        public bool CreateSourceCodeFile()
        {
            string dPath = @"C:\Sourcode\";
            int fileCount = Directory.GetFiles(dPath, "*.*", SearchOption.AllDirectories).Length;
            string filename = "sourcode" + fileCount.ToString() + ".txt";
            System.IO.Directory.CreateDirectory(dPath);
            System.IO.File.WriteAllText(dPath + filename, GetSourceCode());
            Process.Start(dPath);

            return true;
        }
        public string GetProcedure()
        {
            string s = @"//Function order
                            ";

            foreach (OutputObject o in outputObjects)
            {
                s += "//" + o.Id + " " + o.Function + "\n";
            }

            return s;

        }
        public string GetSourceCode()
        {

            if (outputObjects.Count() > 0)
            {
                string s = @"//AUTO GENERATED SOURCE CODE FOR LIVE CHART USING CARSDWENTITIES
                            ";

                foreach (OutputObject o in outputObjects)
                {
                    s += o.Code;
                }


                return s;
            }

            return "//Object was null";
        }

        public void generateStaticContext(string country_id_string, bool add)
        {

            OutputObject opo = new OutputObject();
            opo.Id = seriesNo.ToString();
            opo.Function = "generateStaticContext";
            string clearOrNot = "";
            if (!add)
            {
                clearOrNot = @" 
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();";

            }

            opo.Code = clearOrNot + @"
  using (CarsDWEntities dw = new CarsDWEntities())
            {
List<BigView> Context = dw.BigViews.Where(c => c.country_id == " + country_id_string + @").ToList();


                string country_name = dw.Countries.Where(c => c.country_id == " + country_id_string + @").Select(a => a.name).FirstOrDefault();
                ";
            outputObjects.Add(opo);
        }

        public void GenerateXYValuesYear(string pickedColumn, string start_year_no, string end_year_no, bool isfloat)
        {
            OutputObject opo = new OutputObject();
            opo.Function = "generateXYValuesInteger";
            opo.Id = seriesNo.ToString();
            if (!isfloat)
            {
                //alltid double
                opo.Code = @" List<double> yAsDouble = new List<double>();

            List<string> x = new List<string>();
            for (int i = " + start_year_no + "; i <=" + end_year_no + @"; i++) //för varje år
            {
                x.Add(i.ToString());//year as x values
                var hjalp = Context.Where(b => b.year_no == i).Select(" + "\"" + pickedColumn + "\"" + @");
                int sum = 0;
                //summerar
                 foreach (int h in hjalp)
                 {
                       sum += h;
                 }
                 //lägger till
                  yAsDouble.Add(sum);                        

            }";
            }
            else //tabellen har double som column
            {
                opo.Code = @" List<double> yAsDouble = new List<double>();

            List<string> x = new List<string>();
            for (int i =  " + start_year_no + "; i <=" + end_year_no + @"; i++) //för varje år
            {
                x.Add(i.ToString());//year as x values
                var hjalp = Context.Where(b => b.year_no == i).Select(" + "\"" + pickedColumn + "\"" + @");
                double sum = 0;
                //summerar
                 foreach (double h in hjalp)
                 {
                       sum += h;
                 }
                 //lägger till
                  yAsDouble.Add(sum);                       

            }";

            }
            outputObjects.Add(opo);
        }
        public void GenerateXYValuesYearDouble(string pickedColumn)
        {

            //alltid double
            OutputObject opo = new OutputObject();
            opo.Function = "generateXYValuesYearDouble";
            opo.Code = @" List<double> yAsDouble = new List<double>();

            List<string> x = new List<string>();
            for (int i = min; i <= max; i++) //för varje år
            {
                x.Add(i.ToString());//year as x values
                var hjalp = Context.Where(b => b.year_no == i).Select(" + "\"" + pickedColumn + "\"" + @");
                double sum = 0;
                //summerar
                 foreach (double h in hjalp)
                 {
                       sum += h;
                 }
                 //lägger till
                  yAsDouble.Add(sum);                       

            }";
            outputObjects.Add(opo);



        }

        public void addSeries(string country_name, string pickedColumn, string graphType, string xtitle, string ytitle, bool addScaleY, bool add)
        {
            OutputObject opo = new OutputObject();

            opo.Function = "addSeries";
            opo.Id = seriesNo.ToString();
            switch (graphType.ToLower())
            {
                case "column":
                    if (!addScaleY && numberOfXAxis == 0)
                    {
                        opo.Code = @"ChartValues<double> cvy = new ChartValues<double>();
                        cvy.AddRange(yAsDouble.ToArray());
                        ColumnSeries cs = new ColumnSeries();
                

                        cs.Title =" + "\"" + country_name + "\"" + @"+" + "\" " + pickedColumn + "\"" + @";
                        cs.Values = cvy;
cs.ScalesYAt = " + currentYscale.ToString() + @";
                        cartesianChart1.AxisX.Add(new Axis
                        {
                         Title =" + "\"" + xtitle + "\"" + @",
                         Labels = x.ToArray()
                        });

                    cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = " + "\"" + ytitle + "\"" + @",
                        LabelFormatter = value => value.ToString()
                    });
                            cartesianChart1.Series.Add(cs);";
                        this.NumberOfXAxis++; //kommer bara räkna till 1
                    }
                    else //ny y-scala eller bara add
                    {
                        // ökar currenty
                        if (add == true && addScaleY == true)
                        {
                            currentYscale++;

                        }
                        opo.Code = @"ChartValues<double> cvy = new ChartValues<double>();
                        cvy.AddRange(yAsDouble.ToArray());

                        ColumnSeries cs = new ColumnSeries();
                        cs.Title = " + "\"" + country_name + "\"" + @"+" + "\" " + pickedColumn + "\"" + @";
                        cs.Values = cvy;
                        cs.ScalesYAt = " + currentYscale.ToString() + @";";
                        if (add == true && addScaleY == true)
                        {
                            opo.Code += @"   cartesianChart1.AxisY.Add(new Axis
                        {
                            Title = " + "\"" + ytitle + "\"" + @",
                            LabelFormatter = value => value.ToString()
                        });";
                        }

                        opo.Code+=@"cartesianChart1.Series.Add(cs);
                        ";


                    }
                    break;
                case "line":
                    if (!addScaleY && numberOfXAxis == 0)
                    {
                        opo.Code = @"ChartValues<double> cvy = new ChartValues<double>();
                        cvy.AddRange(yAsDouble.ToArray());
                        LineSeries ls = new LineSeries();
                

                        ls.Title =" + "\"" + country_name + "\"" + @"+" + "\" " + pickedColumn + "\"" + @";
                        ls.Values = cvy;
ls.ScalesYAt = " + currentYscale.ToString() + @";
                        cartesianChart1.AxisX.Add(new Axis
                        {
                         Title =" + "\"" + xtitle + "\"" + @",
                         Labels = x.ToArray()
                        });

                    cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = " + "\"" + ytitle + "\"" + @",
                        LabelFormatter = value => value.ToString()
                    });
                            cartesianChart1.Series.Add(ls);";
                        this.NumberOfXAxis++; //kommer bara räkna till 1
                    }
                    else //ny y-scala eller adderar bara
                    {
                        
                        if (add == true && addScaleY == true)
                        {
                            // ökar currenty
                            currentYscale++;

                        }
                        opo.Code = @"ChartValues<double> cvy = new ChartValues<double>();
                        cvy.AddRange(yAsDouble.ToArray());

                        LineSeries ls = new LineSeries();
                        ls.Title = " + "\"" + country_name + "\"" + @"+" + "\" " + pickedColumn + "\"" + @";
                        ls.Values = cvy;
                        ls.ScalesYAt = " + currentYscale.ToString() + @";";
                        if (add == true && addScaleY == true)
                        {
                            opo.Code += @"   cartesianChart1.AxisY.Add(new Axis
                        {
                            Title = " + "\"" + ytitle + "\"" + @",
                            LabelFormatter = value => value.ToString()
                        });";
                        }

                        opo.Code += @"cartesianChart1.Series.Add(ls);
                        ";



                    }
                    break;
                default:
                    break;
            }

            outputObjects.Add(opo);

        }
        private class OutputObject
        {
            public OutputObject()
            {

            }

            private string function;
            private string code;
            private string id;


            public string Code { get => code; set => code = value; }
            public string Function { get => function; set => function = value; }
            public string Id { get => id; set => id = value; }
        }
    }

}
