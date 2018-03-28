namespace GruppuppgiftMMMJ
{
    partial class MHTEST
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.solidGauge1 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge2 = new LiveCharts.WinForms.SolidGauge();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(385, 22);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(838, 503);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // solidGauge1
            // 
            this.solidGauge1.Location = new System.Drawing.Point(12, 22);
            this.solidGauge1.Name = "solidGauge1";
            this.solidGauge1.Size = new System.Drawing.Size(342, 221);
            this.solidGauge1.TabIndex = 1;
            this.solidGauge1.Text = "solidGauge1";
            // 
            // solidGauge2
            // 
            this.solidGauge2.Location = new System.Drawing.Point(13, 288);
            this.solidGauge2.Name = "solidGauge2";
            this.solidGauge2.Size = new System.Drawing.Size(352, 237);
            this.solidGauge2.TabIndex = 2;
            this.solidGauge2.Text = "solidGauge2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(239, 532);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(984, 222);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 61);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 666);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 56);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MHTEST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 766);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.solidGauge2);
            this.Controls.Add(this.solidGauge1);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "MHTEST";
            this.Text = "MHTEST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MHTEST_FormClosing);
            this.Load += new System.EventHandler(this.MHTEST_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.SolidGauge solidGauge1;
        private LiveCharts.WinForms.SolidGauge solidGauge2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}