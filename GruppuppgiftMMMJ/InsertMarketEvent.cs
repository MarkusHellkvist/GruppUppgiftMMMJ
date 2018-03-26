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
    public partial class InsertMarketEvent : Form
    {
        public Form form;
        public InsertMarketEvent(Form f)
        {
            form = f;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MarketEvent me = new MarketEvent();
            int country_id = 0;
            if (Int32.TryParse(textBox1.Text, out country_id))
            {
                //country_id en siffra, gör resten
                me.country_id = country_id;
            }

            //var date = DateTime.Parse(textBox2).text;

            if (DateTime.TryParse(textBox2.Text, out DateTime date))
            {
                me.date = date.Date;
            }
            me.title = textBox3.Text;
            me.description = richTextBox1.Text;
            me.source = textBox4.Text;

            if (country_id != 0 && me.date != null)
            {

                using (CarsDWEntities dw = new CarsDWEntities())
                {
                    dw.MarketEvents.Add(me);
                    int code=dw.SaveChanges();
                    
                    label5.Text = "inserted"+me.title+"code"+code.ToString();
                    
                }


            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void InsertMarketEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            form.Show();

        }
    }
}
