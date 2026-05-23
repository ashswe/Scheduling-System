namespace SchedulingSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            labelUsername = new Label();
            labelPassword = new Label();
            btnLogin = new Button();
            txtBoxUsername = new TextBox();
            txtBoxPassword = new TextBox();
            labelCurrentTimeZone = new Label();
            picBoxLogo = new PictureBox();
            labelErrorMsg = new Label();
            btnRegister = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // labelUsername
            // 
            resources.ApplyResources(labelUsername, "labelUsername");
            labelUsername.ForeColor = SystemColors.ControlLightLight;
            labelUsername.Name = "labelUsername";
            // 
            // labelPassword
            // 
            resources.ApplyResources(labelPassword, "labelPassword");
            labelPassword.ForeColor = SystemColors.ControlLightLight;
            labelPassword.Name = "labelPassword";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DodgerBlue;
            resources.ApplyResources(btnLogin, "btnLogin");
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Name = "btnLogin";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.BackColor = SystemColors.ButtonFace;
            resources.ApplyResources(txtBoxUsername, "txtBoxUsername");
            txtBoxUsername.Name = "txtBoxUsername";
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.BackColor = SystemColors.ButtonFace;
            resources.ApplyResources(txtBoxPassword, "txtBoxPassword");
            txtBoxPassword.Name = "txtBoxPassword";
            // 
            // labelCurrentTimeZone
            // 
            resources.ApplyResources(labelCurrentTimeZone, "labelCurrentTimeZone");
            labelCurrentTimeZone.ForeColor = SystemColors.ControlLight;
            labelCurrentTimeZone.Name = "labelCurrentTimeZone";
            // 
            // picBoxLogo
            // 
            picBoxLogo.Image = Properties.Resources.logo_EN;
            resources.ApplyResources(picBoxLogo, "picBoxLogo");
            picBoxLogo.Name = "picBoxLogo";
            picBoxLogo.TabStop = false;
            // 
            // labelErrorMsg
            // 
            resources.ApplyResources(labelErrorMsg, "labelErrorMsg");
            labelErrorMsg.ForeColor = Color.LightCoral;
            labelErrorMsg.Name = "labelErrorMsg";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.DodgerBlue;
            resources.ApplyResources(btnRegister, "btnRegister");
            btnRegister.ForeColor = SystemColors.ButtonFace;
            btnRegister.Name = "btnRegister";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(btnRegister);
            Controls.Add(labelErrorMsg);
            Controls.Add(picBoxLogo);
            Controls.Add(labelCurrentTimeZone);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxUsername);
            Controls.Add(btnLogin);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Name = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelUsername;
        private Label labelPassword;
        private Button btnLogin;
        private TextBox txtBoxUsername;
        private TextBox txtBoxPassword;
        private Label labelCurrentTimeZone;
        private PictureBox picBoxLogo;
        private Label labelErrorMsg;
        private Button btnRegister;
    }
}