namespace SchedulingSystem
{
    partial class AppointmentForm
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
            labelAppointments = new Label();
            gridViewAppointments = new DataGridView();
            labelCustomer = new Label();
            labelDate = new Label();
            labelTime = new Label();
            labelDuration = new Label();
            labelType = new Label();
            labelTitle = new Label();
            labelUrl = new Label();
            labelDescription = new Label();
            btnUpdate = new Button();
            comboBoxCustomer = new ComboBox();
            datePickerAppt = new DateTimePicker();
            timePickerAppt = new DateTimePicker();
            comboBoxDuration = new ComboBox();
            txtBoxUrl = new TextBox();
            richTxtBoxDescription = new RichTextBox();
            btnDelete = new Button();
            btnAdd = new Button();
            pictureBox1 = new PictureBox();
            labelBusinessHours = new Label();
            labelReqFields = new Label();
            pictureBox2 = new PictureBox();
            txtBoxTitle = new TextBox();
            txtBoxType = new TextBox();
            comboBoxLocation = new ComboBox();
            labelLocation = new Label();
            txtBoxContact = new TextBox();
            labelContact = new Label();
            ((System.ComponentModel.ISupportInitialize)gridViewAppointments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // labelAppointments
            // 
            labelAppointments.AutoSize = true;
            labelAppointments.Font = new Font("Gill Sans MT", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAppointments.ForeColor = SystemColors.ControlLightLight;
            labelAppointments.Location = new Point(67, 28);
            labelAppointments.Name = "labelAppointments";
            labelAppointments.Size = new Size(200, 38);
            labelAppointments.TabIndex = 0;
            labelAppointments.Text = "Appointments";
            // 
            // gridViewAppointments
            // 
            gridViewAppointments.BackgroundColor = SystemColors.Desktop;
            gridViewAppointments.BorderStyle = BorderStyle.Fixed3D;
            gridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewAppointments.Location = new Point(12, 69);
            gridViewAppointments.Name = "gridViewAppointments";
            gridViewAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridViewAppointments.Size = new Size(619, 624);
            gridViewAppointments.TabIndex = 1;
            gridViewAppointments.CellClick += gridViewAppointments_CellClick;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCustomer.ForeColor = SystemColors.ControlLightLight;
            labelCustomer.Location = new Point(654, 70);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(86, 23);
            labelCustomer.TabIndex = 2;
            labelCustomer.Text = "* Customer";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDate.ForeColor = SystemColors.ControlLightLight;
            labelDate.Location = new Point(655, 134);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(53, 23);
            labelDate.TabIndex = 3;
            labelDate.Text = "* Date";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTime.ForeColor = SystemColors.ControlLightLight;
            labelTime.Location = new Point(840, 134);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(55, 23);
            labelTime.TabIndex = 4;
            labelTime.Text = "* Time";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDuration.ForeColor = SystemColors.ControlLightLight;
            labelDuration.Location = new Point(978, 134);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(145, 23);
            labelDuration.TabIndex = 5;
            labelDuration.Text = "* Duration (minutes)";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelType.ForeColor = SystemColors.ControlLightLight;
            labelType.Location = new Point(654, 204);
            labelType.Name = "labelType";
            labelType.Size = new Size(54, 23);
            labelType.TabIndex = 6;
            labelType.Text = "* Type";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = SystemColors.ControlLightLight;
            labelTitle.Location = new Point(654, 337);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(52, 23);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "* Title";
            // 
            // labelUrl
            // 
            labelUrl.AutoSize = true;
            labelUrl.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUrl.ForeColor = SystemColors.ControlLightLight;
            labelUrl.Location = new Point(841, 268);
            labelUrl.Name = "labelUrl";
            labelUrl.Size = new Size(50, 23);
            labelUrl.TabIndex = 8;
            labelUrl.Text = "* URL";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDescription.ForeColor = SystemColors.ControlLightLight;
            labelDescription.Location = new Point(655, 405);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(98, 23);
            labelDescription.TabIndex = 9;
            labelDescription.Text = "* Description";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = SystemColors.ControlLightLight;
            btnUpdate.Location = new Point(769, 623);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 37);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.BackColor = SystemColors.ButtonFace;
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(654, 96);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(168, 23);
            comboBoxCustomer.TabIndex = 13;
            // 
            // datePickerAppt
            // 
            datePickerAppt.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datePickerAppt.CalendarMonthBackground = SystemColors.ButtonFace;
            datePickerAppt.Format = DateTimePickerFormat.Custom;
            datePickerAppt.Location = new Point(654, 160);
            datePickerAppt.Name = "datePickerAppt";
            datePickerAppt.Size = new Size(168, 23);
            datePickerAppt.TabIndex = 14;
            datePickerAppt.Value = new DateTime(2025, 12, 8, 18, 11, 5, 0);
            // 
            // timePickerAppt
            // 
            timePickerAppt.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timePickerAppt.CalendarMonthBackground = SystemColors.ButtonFace;
            timePickerAppt.Format = DateTimePickerFormat.Time;
            timePickerAppt.Location = new Point(840, 160);
            timePickerAppt.Name = "timePickerAppt";
            timePickerAppt.ShowUpDown = true;
            timePickerAppt.Size = new Size(121, 23);
            timePickerAppt.TabIndex = 15;
            // 
            // comboBoxDuration
            // 
            comboBoxDuration.BackColor = SystemColors.ButtonFace;
            comboBoxDuration.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxDuration.FormattingEnabled = true;
            comboBoxDuration.Location = new Point(978, 160);
            comboBoxDuration.Name = "comboBoxDuration";
            comboBoxDuration.Size = new Size(121, 23);
            comboBoxDuration.TabIndex = 16;
            // 
            // txtBoxUrl
            // 
            txtBoxUrl.BackColor = SystemColors.ButtonFace;
            txtBoxUrl.Location = new Point(840, 294);
            txtBoxUrl.Name = "txtBoxUrl";
            txtBoxUrl.Size = new Size(168, 23);
            txtBoxUrl.TabIndex = 19;
            // 
            // richTxtBoxDescription
            // 
            richTxtBoxDescription.BackColor = SystemColors.ButtonFace;
            richTxtBoxDescription.Location = new Point(654, 431);
            richTxtBoxDescription.Name = "richTxtBoxDescription";
            richTxtBoxDescription.Size = new Size(444, 96);
            richTxtBoxDescription.TabIndex = 20;
            richTxtBoxDescription.Text = "";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DodgerBlue;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(884, 623);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 37);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(657, 623);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 37);
            btnAdd.TabIndex = 22;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Desktop;
            pictureBox1.Image = Properties.Resources.world_logo__1_;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 54);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // labelBusinessHours
            // 
            labelBusinessHours.AutoSize = true;
            labelBusinessHours.Font = new Font("Gill Sans MT", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelBusinessHours.ForeColor = SystemColors.ControlLightLight;
            labelBusinessHours.Location = new Point(655, 576);
            labelBusinessHours.Name = "labelBusinessHours";
            labelBusinessHours.Size = new Size(293, 21);
            labelBusinessHours.TabIndex = 24;
            labelBusinessHours.Text = "Business Hours: 9:00 AM - 5:00 PM EST, Mon-Fri";
            // 
            // labelReqFields
            // 
            labelReqFields.AutoSize = true;
            labelReqFields.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelReqFields.ForeColor = SystemColors.ControlLightLight;
            labelReqFields.Location = new Point(655, 677);
            labelReqFields.Name = "labelReqFields";
            labelReqFields.Size = new Size(91, 18);
            labelReqFields.TabIndex = 25;
            labelReqFields.Text = "* Required Fields";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.blue_accent;
            pictureBox2.Location = new Point(261, 41);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(87, 25);
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            // 
            // txtBoxTitle
            // 
            txtBoxTitle.BackColor = SystemColors.ButtonFace;
            txtBoxTitle.Location = new Point(655, 363);
            txtBoxTitle.Name = "txtBoxTitle";
            txtBoxTitle.Size = new Size(168, 23);
            txtBoxTitle.TabIndex = 27;
            // 
            // txtBoxType
            // 
            txtBoxType.BackColor = SystemColors.ButtonFace;
            txtBoxType.Location = new Point(654, 230);
            txtBoxType.Name = "txtBoxType";
            txtBoxType.Size = new Size(168, 23);
            txtBoxType.TabIndex = 28;
            // 
            // comboBoxLocation
            // 
            comboBoxLocation.BackColor = SystemColors.ButtonFace;
            comboBoxLocation.FormattingEnabled = true;
            comboBoxLocation.Location = new Point(840, 230);
            comboBoxLocation.Name = "comboBoxLocation";
            comboBoxLocation.Size = new Size(168, 23);
            comboBoxLocation.TabIndex = 29;
            // 
            // labelLocation
            // 
            labelLocation.AutoSize = true;
            labelLocation.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLocation.ForeColor = SystemColors.ControlLightLight;
            labelLocation.Location = new Point(840, 204);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(78, 23);
            labelLocation.TabIndex = 30;
            labelLocation.Text = "* Location";
            // 
            // txtBoxContact
            // 
            txtBoxContact.BackColor = SystemColors.ButtonFace;
            txtBoxContact.Location = new Point(654, 294);
            txtBoxContact.Name = "txtBoxContact";
            txtBoxContact.Size = new Size(168, 23);
            txtBoxContact.TabIndex = 32;
            // 
            // labelContact
            // 
            labelContact.AutoSize = true;
            labelContact.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelContact.ForeColor = SystemColors.ControlLightLight;
            labelContact.Location = new Point(655, 268);
            labelContact.Name = "labelContact";
            labelContact.Size = new Size(73, 23);
            labelContact.TabIndex = 31;
            labelContact.Text = "* Contact";
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1151, 716);
            Controls.Add(txtBoxContact);
            Controls.Add(labelContact);
            Controls.Add(labelLocation);
            Controls.Add(comboBoxLocation);
            Controls.Add(txtBoxType);
            Controls.Add(txtBoxTitle);
            Controls.Add(pictureBox2);
            Controls.Add(labelReqFields);
            Controls.Add(labelBusinessHours);
            Controls.Add(pictureBox1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(richTxtBoxDescription);
            Controls.Add(txtBoxUrl);
            Controls.Add(comboBoxDuration);
            Controls.Add(timePickerAppt);
            Controls.Add(datePickerAppt);
            Controls.Add(comboBoxCustomer);
            Controls.Add(btnUpdate);
            Controls.Add(labelDescription);
            Controls.Add(labelUrl);
            Controls.Add(labelTitle);
            Controls.Add(labelType);
            Controls.Add(labelDuration);
            Controls.Add(labelTime);
            Controls.Add(labelDate);
            Controls.Add(labelCustomer);
            Controls.Add(gridViewAppointments);
            Controls.Add(labelAppointments);
            Name = "AppointmentForm";
            Text = "Manage Appointments";
            ((System.ComponentModel.ISupportInitialize)gridViewAppointments).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAppointments;
        private DataGridView gridViewAppointments;
        private Label labelCustomer;
        private Label labelDate;
        private Label labelTime;
        private Label labelDuration;
        private Label labelType;
        private Label labelTitle;
        private Label labelUrl;
        private Label labelDescription;
        private Button btnUpdate;
        private ComboBox comboBoxCustomer;
        private DateTimePicker datePickerAppt;
        private DateTimePicker timePickerAppt;
        private ComboBox comboBoxDuration;
        private TextBox txtBoxUrl;
        private RichTextBox richTxtBoxDescription;
        private Button btnDelete;
        private Button btnAdd;
        private PictureBox pictureBox1;
        private Label labelBusinessHours;
        private Label labelReqFields;
        private PictureBox pictureBox2;
        private TextBox txtBoxTitle;
        private TextBox txtBoxType;
        private ComboBox comboBoxLocation;
        private Label labelLocation;
        private TextBox txtBoxContact;
        private Label labelContact;
    }
}