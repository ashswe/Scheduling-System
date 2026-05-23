namespace SchedulingSystem
{
    partial class CustomerForm
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
            gridViewCustomers = new DataGridView();
            labelName = new Label();
            labelAddress = new Label();
            labelAddress2 = new Label();
            labelCity = new Label();
            labelCountry = new Label();
            labelPostalCode = new Label();
            labelPhone = new Label();
            txtBoxName = new TextBox();
            txtBoxAddress = new TextBox();
            txtBoxAddress2 = new TextBox();
            txtBoxPostalCode = new TextBox();
            txtBoxPhone = new TextBox();
            btnAdd = new Button();
            checkBoxActive = new CheckBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            labelCustomerManagement = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            comboBoxCity = new ComboBox();
            comboBoxCountry = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)gridViewCustomers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // gridViewCustomers
            // 
            gridViewCustomers.BackgroundColor = SystemColors.Desktop;
            gridViewCustomers.BorderStyle = BorderStyle.Fixed3D;
            gridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewCustomers.Location = new Point(353, 118);
            gridViewCustomers.MultiSelect = false;
            gridViewCustomers.Name = "gridViewCustomers";
            gridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridViewCustomers.Size = new Size(928, 511);
            gridViewCustomers.TabIndex = 0;
            gridViewCustomers.CellClick += gridViewCustomers_CellClick;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelName.ForeColor = SystemColors.ControlLightLight;
            labelName.Location = new Point(23, 92);
            labelName.Name = "labelName";
            labelName.Size = new Size(61, 23);
            labelName.TabIndex = 1;
            labelName.Text = "Name *";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAddress.ForeColor = SystemColors.ControlLightLight;
            labelAddress.Location = new Point(24, 146);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(74, 23);
            labelAddress.TabIndex = 2;
            labelAddress.Text = "Address *";
            // 
            // labelAddress2
            // 
            labelAddress2.AutoSize = true;
            labelAddress2.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAddress2.ForeColor = SystemColors.ControlLightLight;
            labelAddress2.Location = new Point(23, 202);
            labelAddress2.Name = "labelAddress2";
            labelAddress2.Size = new Size(75, 23);
            labelAddress2.TabIndex = 3;
            labelAddress2.Text = "Address 2";
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCity.ForeColor = SystemColors.ControlLightLight;
            labelCity.Location = new Point(23, 262);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(48, 23);
            labelCity.TabIndex = 4;
            labelCity.Text = "City *";
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCountry.ForeColor = SystemColors.ControlLightLight;
            labelCountry.Location = new Point(24, 327);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(75, 23);
            labelCountry.TabIndex = 5;
            labelCountry.Text = "Country *";
            // 
            // labelPostalCode
            // 
            labelPostalCode.AutoSize = true;
            labelPostalCode.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPostalCode.ForeColor = SystemColors.ControlLightLight;
            labelPostalCode.Location = new Point(23, 392);
            labelPostalCode.Name = "labelPostalCode";
            labelPostalCode.Size = new Size(100, 23);
            labelPostalCode.TabIndex = 6;
            labelPostalCode.Text = "Postal Code *";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPhone.ForeColor = SystemColors.ControlLightLight;
            labelPhone.Location = new Point(24, 450);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(62, 23);
            labelPhone.TabIndex = 7;
            labelPhone.Text = "Phone *";
            // 
            // txtBoxName
            // 
            txtBoxName.BackColor = SystemColors.ButtonFace;
            txtBoxName.Location = new Point(24, 118);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(291, 23);
            txtBoxName.TabIndex = 8;
            // 
            // txtBoxAddress
            // 
            txtBoxAddress.BackColor = SystemColors.ButtonFace;
            txtBoxAddress.Location = new Point(24, 172);
            txtBoxAddress.Name = "txtBoxAddress";
            txtBoxAddress.Size = new Size(292, 23);
            txtBoxAddress.TabIndex = 9;
            // 
            // txtBoxAddress2
            // 
            txtBoxAddress2.BackColor = SystemColors.ButtonFace;
            txtBoxAddress2.Location = new Point(23, 228);
            txtBoxAddress2.Name = "txtBoxAddress2";
            txtBoxAddress2.Size = new Size(292, 23);
            txtBoxAddress2.TabIndex = 10;
            // 
            // txtBoxPostalCode
            // 
            txtBoxPostalCode.BackColor = SystemColors.ButtonFace;
            txtBoxPostalCode.Location = new Point(24, 418);
            txtBoxPostalCode.Name = "txtBoxPostalCode";
            txtBoxPostalCode.Size = new Size(292, 23);
            txtBoxPostalCode.TabIndex = 13;
            // 
            // txtBoxPhone
            // 
            txtBoxPhone.BackColor = SystemColors.ButtonFace;
            txtBoxPhone.Location = new Point(23, 476);
            txtBoxPhone.Name = "txtBoxPhone";
            txtBoxPhone.Size = new Size(292, 23);
            txtBoxPhone.TabIndex = 14;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(24, 584);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(83, 42);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // checkBoxActive
            // 
            checkBoxActive.AutoSize = true;
            checkBoxActive.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxActive.ForeColor = SystemColors.ControlLightLight;
            checkBoxActive.Location = new Point(23, 530);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(71, 27);
            checkBoxActive.TabIndex = 18;
            checkBoxActive.Text = "Active";
            checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = SystemColors.ControlLightLight;
            btnUpdate.Location = new Point(123, 584);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(91, 42);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DodgerBlue;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(230, 584);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 43);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // labelCustomerManagement
            // 
            labelCustomerManagement.AutoSize = true;
            labelCustomerManagement.Font = new Font("Gill Sans MT", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCustomerManagement.ForeColor = SystemColors.ControlLightLight;
            labelCustomerManagement.Location = new Point(69, 32);
            labelCustomerManagement.Name = "labelCustomerManagement";
            labelCustomerManagement.Size = new Size(320, 38);
            labelCustomerManagement.TabIndex = 21;
            labelCustomerManagement.Text = "Customer Management";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.world_logo__1_;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 58);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.blue_accent;
            pictureBox2.Location = new Point(382, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(87, 28);
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // comboBoxCity
            // 
            comboBoxCity.FormattingEnabled = true;
            comboBoxCity.Location = new Point(23, 288);
            comboBoxCity.Name = "comboBoxCity";
            comboBoxCity.Size = new Size(293, 23);
            comboBoxCity.TabIndex = 24;
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Location = new Point(23, 353);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(293, 23);
            comboBoxCountry.TabIndex = 25;
            comboBoxCountry.SelectedIndexChanged += comboBoxCountry_SelectedIndexChanged;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1313, 656);
            Controls.Add(comboBoxCountry);
            Controls.Add(comboBoxCity);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(labelCustomerManagement);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(checkBoxActive);
            Controls.Add(btnAdd);
            Controls.Add(txtBoxPhone);
            Controls.Add(txtBoxPostalCode);
            Controls.Add(txtBoxAddress2);
            Controls.Add(txtBoxAddress);
            Controls.Add(txtBoxName);
            Controls.Add(labelPhone);
            Controls.Add(labelPostalCode);
            Controls.Add(labelCountry);
            Controls.Add(labelCity);
            Controls.Add(labelAddress2);
            Controls.Add(labelAddress);
            Controls.Add(labelName);
            Controls.Add(gridViewCustomers);
            Name = "CustomerForm";
            Text = "Customer Management";
            ((System.ComponentModel.ISupportInitialize)gridViewCustomers).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridViewCustomers;
        private Label labelName;
        private Label labelAddress;
        private Label labelAddress2;
        private Label labelCity;
        private Label labelCountry;
        private Label labelPostalCode;
        private Label labelPhone;
        private TextBox txtBoxName;
        private TextBox txtBoxAddress;
        private TextBox txtBoxAddress2;
        private TextBox txtBoxPostalCode;
        private TextBox txtBoxPhone;
        private Button btnAdd;
        private CheckBox checkBoxActive;
        private Button btnUpdate;
        private Button btnDelete;
        private Label labelCustomerManagement;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ComboBox comboBoxCity;
        private ComboBox comboBoxCountry;
    }
}