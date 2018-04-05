namespace GruppuppgiftMMMJ
{
    partial class co2Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNor = new System.Windows.Forms.DataGridView();
            this.dgvSwe = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tbSweden = new System.Windows.Forms.TextBox();
            this.tbNorway = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Norge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sweden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSwe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cartesianChart1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1712, 863);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(203, 2);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cartesianChart1.Name = "cartesianChart1";
            this.tableLayoutPanel1.SetRowSpan(this.cartesianChart1, 2);
            this.cartesianChart1.Size = new System.Drawing.Size(1506, 758);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.DataClick += new LiveCharts.Events.DataClickHandler(this.CartesianChart1OnDataClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvNor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvSwe, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(203, 764);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1506, 97);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // dgvNor
            // 
            this.dgvNor.AllowUserToAddRows = false;
            this.dgvNor.AllowUserToDeleteRows = false;
            this.dgvNor.AllowUserToResizeColumns = false;
            this.dgvNor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvNor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvNor.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvNor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNor.ColumnHeadersVisible = false;
            this.dgvNor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Norge,
            this.nTitle,
            this.Column2,
            this.Column3});
            this.dgvNor.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvNor.Location = new System.Drawing.Point(757, 4);
            this.dgvNor.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNor.Name = "dgvNor";
            this.dgvNor.RowHeadersVisible = false;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNor.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNor.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNor.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNor.Size = new System.Drawing.Size(745, 89);
            this.dgvNor.TabIndex = 0;
            // 
            // dgvSwe
            // 
            this.dgvSwe.AllowUserToAddRows = false;
            this.dgvSwe.AllowUserToDeleteRows = false;
            this.dgvSwe.AllowUserToResizeColumns = false;
            this.dgvSwe.AllowUserToResizeRows = false;
            this.dgvSwe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSwe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSwe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSwe.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSwe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSwe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSwe.ColumnHeadersVisible = false;
            this.dgvSwe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sweden,
            this.Title,
            this.date,
            this.description});
            this.dgvSwe.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSwe.Location = new System.Drawing.Point(4, 4);
            this.dgvSwe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSwe.Name = "dgvSwe";
            this.dgvSwe.RowHeadersVisible = false;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSwe.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSwe.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSwe.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSwe.Size = new System.Drawing.Size(745, 89);
            this.dgvSwe.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbYear);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.tbSweden);
            this.groupBox1.Controls.Add(this.tbNorway);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(194, 233);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // tbYear
            // 
            this.tbYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYear.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbYear.Location = new System.Drawing.Point(9, 73);
            this.tbYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbYear.Name = "tbYear";
            this.tbYear.ReadOnly = true;
            this.tbYear.Size = new System.Drawing.Size(86, 25);
            this.tbYear.TabIndex = 5;
            this.tbYear.Text = "2020";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox3.Location = new System.Drawing.Point(5, 18);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(180, 55);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "% of electronic cars year:";
            // 
            // tbSweden
            // 
            this.tbSweden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSweden.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSweden.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSweden.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbSweden.Location = new System.Drawing.Point(113, 143);
            this.tbSweden.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSweden.Name = "tbSweden";
            this.tbSweden.ReadOnly = true;
            this.tbSweden.Size = new System.Drawing.Size(74, 29);
            this.tbSweden.TabIndex = 3;
            this.tbSweden.Text = "1%";
            // 
            // tbNorway
            // 
            this.tbNorway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNorway.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNorway.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNorway.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbNorway.Location = new System.Drawing.Point(113, 108);
            this.tbNorway.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNorway.Name = "tbNorway";
            this.tbNorway.ReadOnly = true;
            this.tbNorway.Size = new System.Drawing.Size(86, 29);
            this.tbNorway.TabIndex = 2;
            this.tbNorway.Text = "20%";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.Location = new System.Drawing.Point(9, 143);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(124, 29);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Sweden:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(9, 108);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(124, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Norway:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(4, 766);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 93);
            this.button1.TabIndex = 0;
            this.button1.Text = "Toggle total Sales";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ToggleAllSales);
            // 
            // Norge
            // 
            this.Norge.DataPropertyName = "country_name";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Norge.DefaultCellStyle = dataGridViewCellStyle2;
            this.Norge.HeaderText = "Norge";
            this.Norge.Name = "Norge";
            this.Norge.Width = 5;
            // 
            // nTitle
            // 
            this.nTitle.DataPropertyName = "title";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nTitle.DefaultCellStyle = dataGridViewCellStyle3;
            this.nTitle.HeaderText = "Title";
            this.nTitle.Name = "nTitle";
            this.nTitle.Width = 5;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "date";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            this.Column2.Width = 5;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "description";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.Width = 5;
            // 
            // Sweden
            // 
            this.Sweden.DataPropertyName = "country_name";
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.Sweden.DefaultCellStyle = dataGridViewCellStyle7;
            this.Sweden.HeaderText = "Sweden";
            this.Sweden.Name = "Sweden";
            this.Sweden.Width = 5;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "title";
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.Title.DefaultCellStyle = dataGridViewCellStyle8;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 5;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.date.DefaultCellStyle = dataGridViewCellStyle9;
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.Width = 5;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.description.DefaultCellStyle = dataGridViewCellStyle10;
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.Width = 5;
            // 
            // co2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 863);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "co2Form";
            this.Text = "co2Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.co2Form_FormClosing);
            this.Load += new System.EventHandler(this.co2Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSwe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvNor;
        private System.Windows.Forms.DataGridView dgvSwe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSweden;
        private System.Windows.Forms.TextBox tbNorway;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Norge;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sweden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}