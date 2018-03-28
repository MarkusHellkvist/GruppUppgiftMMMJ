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

namespace GruppuppgiftMMMJ
{
    public partial class MHTEST : Form
    {

        public Form MainForm;

        public MHTEST(Form HEJ)
        {


            InitializeComponent();
            MainForm = HEJ;


        }

       
        private void MHTEST_FormClosing(object sender, FormClosingEventArgs e)

        {
            MainForm.Show();


        }

        private void cartesianPlot()
        {
            List<int> ylista = new List<int>();
            using (CarsDWEntities MHDW = new CarsDWEntities())
            {


                ylista = MHDW.BigViews.Where(q => q.country_id == 1).Select(q => (int)q.electric).ToList();



            }

            LineSeries ls = new LineSeries();
            {
                ls.Title = "Electric cars";
            }
            ChartValues<int> cv = new ChartValues<int>();
            cv.AddRange(ylista);
            ls.Values = cv;

            cartesianChart1.Series.Add(ls);

        }

        private void MHTEST_Load(object sender, EventArgs e)
        {
            cartesianPlot();
        }
    }
}
