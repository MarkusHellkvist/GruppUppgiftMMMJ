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
    public partial class BubblePlot : Form
    {
        Form parentForm;
        public BubblePlot(Form pf)
        {
            InitializeComponent();
            parentForm = pf;
        }

        private void BubblePlot_Load(object sender, EventArgs e)
        {

        }

        private void BubblePlot_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            parentForm.Show();
        }
    }
}
