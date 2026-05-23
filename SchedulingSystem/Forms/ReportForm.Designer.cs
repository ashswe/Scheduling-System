namespace SchedulingSystem
{
    partial class ReportForm
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
            gridViewReports = new DataGridView();
            labelReportType = new Label();
            comboBoxReports = new ComboBox();
            labelReports = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gridViewReports).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // gridViewReports
            // 
            gridViewReports.BackgroundColor = SystemColors.Desktop;
            gridViewReports.BorderStyle = BorderStyle.Fixed3D;
            gridViewReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewReports.Location = new Point(22, 132);
            gridViewReports.Name = "gridViewReports";
            gridViewReports.Size = new Size(906, 474);
            gridViewReports.TabIndex = 0;
            // 
            // labelReportType
            // 
            labelReportType.AutoSize = true;
            labelReportType.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReportType.ForeColor = SystemColors.ControlLightLight;
            labelReportType.Location = new Point(22, 89);
            labelReportType.Name = "labelReportType";
            labelReportType.Size = new Size(109, 23);
            labelReportType.TabIndex = 1;
            labelReportType.Text = "Report Type:";
            // 
            // comboBoxReports
            // 
            comboBoxReports.BackColor = SystemColors.ButtonFace;
            comboBoxReports.FormattingEnabled = true;
            comboBoxReports.Location = new Point(137, 89);
            comboBoxReports.Name = "comboBoxReports";
            comboBoxReports.Size = new Size(345, 23);
            comboBoxReports.TabIndex = 2;
            comboBoxReports.SelectedIndexChanged += comboBoxReports_SelectedIndexChanged;
            // 
            // labelReports
            // 
            labelReports.AutoSize = true;
            labelReports.Font = new Font("Gill Sans MT", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReports.ForeColor = SystemColors.ControlLightLight;
            labelReports.Location = new Point(70, 28);
            labelReports.Name = "labelReports";
            labelReports.Size = new Size(117, 38);
            labelReports.TabIndex = 3;
            labelReports.Text = "Reports";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.world_logo__1_;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 54);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.blue_accent;
            pictureBox2.Location = new Point(193, 37);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(86, 29);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(949, 614);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(labelReports);
            Controls.Add(comboBoxReports);
            Controls.Add(labelReportType);
            Controls.Add(gridViewReports);
            Name = "ReportForm";
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)gridViewReports).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridViewReports;
        private Label labelReportType;
        private ComboBox comboBoxReports;
        private Label labelReports;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}