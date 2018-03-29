using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
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
            string wtf = textBox5.Text;
            label5.Text = country_id.ToString() + me.date.ToString() + textBox5.Text + button1.Text;
            if (country_id != 0 && me.date != null && textBox5.Text == "" && button1.Text == "Insert")
            {

                using (CarsDWEntities dw = new CarsDWEntities())
                {
                    dw.MarketEvents.Add(me);
                    int code = dw.SaveChanges();
                    if (code == 1)
                    {

                        label5.Text = "Inserted" + me.title + "code " + code.ToString();
                        PopulateGridview();
                        Clear();
                    }
                    else
                    {
                        label5.Text = "Something went wrong. code " + code.ToString();

                    }

                }


            }
            else if (button1.Text == "Update" && textBox5.Text != "")
            {
                if (Int32.TryParse(textBox5.Text, out int marketevent_id))
                {
                    //update
                    //country_id en siffra, gör resten
                    me.marketevent_id = marketevent_id;
                    using (CarsDWEntities dw = new CarsDWEntities())
                    {

                        dw.Entry(me).State = EntityState.Modified;

                        int code = dw.SaveChanges();
                        if (code == 1)
                        {

                            label5.Text = "Updated" + me.title + "code " + code.ToString();
                            PopulateGridview();
                            Clear();
                        }
                        else
                        {
                            label5.Text = "Something went wrong. Code:" + code.ToString();
                        }

                    }
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
        private void Clear()
        {

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            richTextBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            richTextBox1.Text = "";
            label5.Text = "Ready for new data";
        }

        private void InsertMarketEvent_Load(object sender, EventArgs e)
        {
            PopulateGridview();
        }

        private void PopulateGridview()
        {
            using (CarsDWEntities dw = new CarsDWEntities())
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dw.MarketEvents.ToList<MarketEvent>();
            }
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["marketevent_id"].Value);
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["country_id"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["date"].Value).Substring(0, 10);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["title"].Value);
                richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["description"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["source"].Value);

                button1.Text = "Update";
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
            if (Int32.TryParse(textBox5.Text, out int marketevent_id))
            {
                //update
                //country_id en siffra, gör resten
                me.marketevent_id = marketevent_id;
                using (CarsDWEntities dw = new CarsDWEntities())
                {
                    var entry = dw.Entry(me);
                    if (entry.State == EntityState.Detached)
                    {
                        dw.MarketEvents.Attach(me);
                    }
                    dw.MarketEvents.Remove(me);
                    int code = dw.SaveChanges();
                    if (code == 1)
                    {
                        label5.Text = "Deleted" + me.title + "code " + code.ToString();
                        PopulateGridview();
                        Clear();
                    }
                    else
                    {
                        label5.Text = "Something went wrong. Code:" + code.ToString();
                    }
                }
            }
            else
            {
                label5.Text = "marketevent_id";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            using (CarsDWEntities dw = new CarsDWEntities())
            {
             List<MarketEvent> me= dw.MarketEvents.ToList();

                List<string> meCSVFormattedList=new List<string>();
                string columnHeaders = "marketevent_id;date;country_id;title;description;source";
                meCSVFormattedList.Add(columnHeaders);
                foreach(MarketEvent me2 in me)
                {
                    string csv = me2.marketevent_id + ";" + me2.date + ";" + me2.country_id + ";" + me2.title + ";" + me2.description + ";" + me2.source;
                    meCSVFormattedList.Add(csv);
                }


                string dPath = @"C:\MarketEventsCSVFile";
                string filename = "MarketEvents.csv";
                string[] lines = meCSVFormattedList.ToArray();
                System.IO.Directory.CreateDirectory(dPath);
                System.IO.File.WriteAllLines(dPath + @"\"+filename, lines);
                MessageBox.Show("File created " + dPath + @"\" + filename,"Exported CSV");
                Process.Start(dPath);


            }
        }
    }
}
