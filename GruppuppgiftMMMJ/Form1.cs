using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace GruppuppgiftMMMJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void miningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertMarketEvent f = new InsertMarketEvent(this);
            f.Show();
            this.Hide();
        }

        private void miningToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            MiningTool f = new MiningTool(this);
            f.Show();
            this.Hide();


        }

        private void livechartsDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LivechartsDemo l = new LivechartsDemo(this);
            l.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Marcus testchart
        private void mWtestToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   MWtest f = new MWtest(this);//Konstruktor. this = den form vi är i this hänvisar till sig själv
          //  f.Show();//visa vid click
            this.Hide(); //Göm fönstret
        }
        
        private void co2FormToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          //  co2Form f = new co2Form(this);//Konstruktor. this = den form vi är i this hänvisar till sig själv
          //  f.Show();//visa vid click
            this.Hide(); //Göm fönstret

   }

        private void bubbleChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BubbleChartCarSales f2 = new BubbleChartCarSales(this);
            f2.Show();

        }

        
    }
}
