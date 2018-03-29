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
using Brushes = System.Windows.Media.Brushes;

namespace GruppuppgiftMMMJ
{
    public partial class MWtest : Form
    {
        public Form mainform;

        public MWtest(Form toMenu)
        {
            InitializeComponent();
            mainform = toMenu;
         
        }

        private void MWtest_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }

        private void marcusPlot()

        {
            List<int> ylista = new List<int>();
            using (CarsDWEntities mw = new CarsDWEntities()) //using för att den är väldigt tung. Vill stänga när vi använt databasen
            {
                ylista = mw.BigViews.Select(q => (int)q.electric).ToList();

            }
            ChartValues<int> cw = new ChartValues<int>();
            cw.AddRange(ylista);
            LineSeries ls = new LineSeries();
            ls.Title = "electric";
            ls.Values = cw;

            cartesianChart1.Series.Add(ls);

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void MWtest_Load(object sender, EventArgs e)
        {
            marcusPlot();
        }
    }
}