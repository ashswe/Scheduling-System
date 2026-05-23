namespace SchedulingSystem
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            MenuItemCustomers = new ToolStripMenuItem();
            MenuItemAppt = new ToolStripMenuItem();
            MenuItemReports = new ToolStripMenuItem();
            labelCalendar = new Label();
            labelDailyAppt = new Label();
            monthCalendar = new MonthCalendar();
            gridViewAppointments = new DataGridView();
            txtBoxTimeUser = new TextBox();
            radioBtnDailyView = new RadioButton();
            radioBtnMonthlyView = new RadioButton();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewAppointments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.DodgerBlue;
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuItemCustomers, MenuItemAppt, MenuItemReports });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(862, 31);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemCustomers
            // 
            MenuItemCustomers.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MenuItemCustomers.ForeColor = SystemColors.ControlLightLight;
            MenuItemCustomers.Name = "MenuItemCustomers";
            MenuItemCustomers.Size = new Size(93, 27);
            MenuItemCustomers.Text = "Customers";
            MenuItemCustomers.Click += MenuItemCustomers_Click;
            // 
            // MenuItemAppt
            // 
            MenuItemAppt.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MenuItemAppt.ForeColor = SystemColors.ControlLightLight;
            MenuItemAppt.Name = "MenuItemAppt";
            MenuItemAppt.Size = new Size(114, 27);
            MenuItemAppt.Text = "Appointments";
            MenuItemAppt.Click += MenuItemAppt_Click;
            // 
            // MenuItemReports
            // 
            MenuItemReports.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MenuItemReports.ForeColor = SystemColors.ControlLightLight;
            MenuItemReports.Name = "MenuItemReports";
            MenuItemReports.Size = new Size(74, 27);
            MenuItemReports.Text = "Reports";
            MenuItemReports.Click += MenuItemReports_Click;
            // 
            // labelCalendar
            // 
            labelCalendar.AutoSize = true;
            labelCalendar.Font = new Font("Gill Sans MT", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCalendar.ForeColor = SystemColors.ControlLightLight;
            labelCalendar.Location = new Point(29, 49);
            labelCalendar.Name = "labelCalendar";
            labelCalendar.Size = new Size(119, 34);
            labelCalendar.TabIndex = 1;
            labelCalendar.Text = "Calendar";
            // 
            // labelDailyAppt
            // 
            labelDailyAppt.AutoSize = true;
            labelDailyAppt.Font = new Font("Gill Sans MT", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDailyAppt.ForeColor = SystemColors.ControlLightLight;
            labelDailyAppt.Location = new Point(353, 49);
            labelDailyAppt.Name = "labelDailyAppt";
            labelDailyAppt.Size = new Size(177, 34);
            labelDailyAppt.TabIndex = 2;
            labelDailyAppt.Text = "Appointments";
            // 
            // monthCalendar
            // 
            monthCalendar.BackColor = SystemColors.ButtonFace;
            monthCalendar.Font = new Font("Gill Sans MT", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            monthCalendar.Location = new Point(29, 85);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 3;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            // 
            // gridViewAppointments
            // 
            gridViewAppointments.BackgroundColor = SystemColors.Desktop;
            gridViewAppointments.BorderStyle = BorderStyle.Fixed3D;
            gridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewAppointments.Location = new Point(353, 85);
            gridViewAppointments.Name = "gridViewAppointments";
            gridViewAppointments.Size = new Size(477, 318);
            gridViewAppointments.TabIndex = 4;
            // 
            // txtBoxTimeUser
            // 
            txtBoxTimeUser.BackColor = Color.Black;
            txtBoxTimeUser.ForeColor = SystemColors.ControlLightLight;
            txtBoxTimeUser.Location = new Point(0, 433);
            txtBoxTimeUser.Name = "txtBoxTimeUser";
            txtBoxTimeUser.ReadOnly = true;
            txtBoxTimeUser.Size = new Size(862, 23);
            txtBoxTimeUser.TabIndex = 5;
            // 
            // radioBtnDailyView
            // 
            radioBtnDailyView.AutoSize = true;
            radioBtnDailyView.Font = new Font("Gill Sans MT", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioBtnDailyView.ForeColor = SystemColors.ControlLightLight;
            radioBtnDailyView.Location = new Point(32, 259);
            radioBtnDailyView.Name = "radioBtnDailyView";
            radioBtnDailyView.Size = new Size(92, 25);
            radioBtnDailyView.TabIndex = 6;
            radioBtnDailyView.TabStop = true;
            radioBtnDailyView.Text = "Daily View";
            radioBtnDailyView.UseVisualStyleBackColor = true;
            radioBtnDailyView.CheckedChanged += radioBtnDailyView_CheckedChanged;
            // 
            // radioBtnMonthlyView
            // 
            radioBtnMonthlyView.AutoSize = true;
            radioBtnMonthlyView.Font = new Font("Gill Sans MT", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioBtnMonthlyView.ForeColor = SystemColors.ControlLightLight;
            radioBtnMonthlyView.Location = new Point(143, 259);
            radioBtnMonthlyView.Name = "radioBtnMonthlyView";
            radioBtnMonthlyView.Size = new Size(113, 25);
            radioBtnMonthlyView.TabIndex = 7;
            radioBtnMonthlyView.TabStop = true;
            radioBtnMonthlyView.Text = "Monthly View";
            radioBtnMonthlyView.UseVisualStyleBackColor = true;
            radioBtnMonthlyView.CheckedChanged += radioBtnMonthlyView_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.blue_accent;
            pictureBox1.Location = new Point(143, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(83, 24);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.blue_accent;
            pictureBox2.Location = new Point(526, 59);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(83, 24);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(862, 457);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(radioBtnMonthlyView);
            Controls.Add(radioBtnDailyView);
            Controls.Add(txtBoxTimeUser);
            Controls.Add(gridViewAppointments);
            Controls.Add(monthCalendar);
            Controls.Add(labelDailyAppt);
            Controls.Add(labelCalendar);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Scheduling System";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewAppointments).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuItemCustomers;
        private ToolStripMenuItem MenuItemAppt;
        private ToolStripMenuItem MenuItemReports;
        private Label labelCalendar;
        private Label labelDailyAppt;
        private MonthCalendar monthCalendar;
        private DataGridView gridViewAppointments;
        private TextBox txtBoxTimeUser;
        private RadioButton radioBtnDailyView;
        private RadioButton radioBtnMonthlyView;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}