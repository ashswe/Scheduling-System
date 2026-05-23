using MySqlConnector;
using SchedulingSystem.Data;
using SchedulingSystem.Services;
using SchedulingSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
//using System.ComponentModel.DataAnnotations;


namespace SchedulingSystem
{
    partial class LoginForm : Form
    {
        // ===== Properties =====
        private string UsernameInput => txtBoxUsername.Text;
        private string PasswordInput => txtBoxPassword.Text;

        // ===== Constructor =====
        public LoginForm()
        {
            InitializeComponent();

            GetUserUILanguage();
            ShowCorrectLanguage();
        }

        // ===== Private Helpers =====
        private void GetUserUILanguage()
        {
            var userCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = userCulture;
            Thread.CurrentThread.CurrentUICulture = userCulture;
        }

        private void PopulateStrings()
        {
            labelUsername.Text = Properties.Strings.LabelUsername;
            labelPassword.Text = Properties.Strings.LabelPassword;
            btnRegister.Text = Properties.Strings.ButtonRegister;
            btnLogin.Text = Properties.Strings.ButtonLogin;

            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            labelCurrentTimeZone.Text = $"{Properties.Strings.CurrentTimeZoneLabel} {localTimeZone.DisplayName}";
        }

        private void ShowCorrectLanguage()
        {
            picBoxLogo.Image =
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "es"
                ? Properties.Resources.logo_ES
                : Properties.Resources.logo_EN;

            PopulateStrings();
        }

        private void LogLogin()
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | username: {Session.CurrentUser}{Environment.NewLine}";

            File.AppendAllText("Login_History.txt", logEntry);
        }

        private bool ValidateUserInput()
        {
            try
            {
                var usernamePassword = ValidationResult.ValidateUsernamePasswordInput(UsernameInput, PasswordInput);
                var username = ValidationResult.ValidateUsernameInput(UsernameInput);
                var password = ValidationResult.ValidatePasswordInput(UsernameInput);

                labelErrorMsg.Text = string.Empty;

                if (!usernamePassword.IsValid)
                {
                    labelErrorMsg.Text = usernamePassword.ErrorMessage;
                    return false;
                }
                else if (!username.IsValid)
                {
                    labelErrorMsg.Text = username.ErrorMessage;
                    return false;
                }
                else if (!password.IsValid)
                {
                    labelErrorMsg.Text = password.ErrorMessage;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
                return false;
            }
        }

        // ===== Register & Login Events =====
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUserInput())
                {
                    return;
                }

                if (UserDataAccess.UsernameExists(UsernameInput))
                {
                    labelErrorMsg.Text = Properties.Strings.ErrorUsernameExists;
                    return;
                }

                UserDataAccess.RegisterUser(UsernameInput, PasswordInput);
                MessageBox.Show(Properties.Strings.UserRegisteredSuccess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUserInput())
                {
                    return;
                }

                if (UserDataAccess.AuthenticateUser(UsernameInput, PasswordInput))
                {
                    LogLogin();
                    new MainForm().ShowDialog();
                    Close();
                }
                else
                {
                    labelErrorMsg.Text = Properties.Strings.ErrorUsernameOrPasswordIncorrect;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }
    }
}
