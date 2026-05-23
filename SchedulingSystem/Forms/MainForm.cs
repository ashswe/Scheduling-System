using SchedulingSystem.Data;
using SchedulingSystem.Services;
using SchedulingSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingSystem
{
    public partial class MainForm : Form
    {
        // ===== Properties =====
        private DateTime SelectedDate => monthCalendar.SelectionStart.Date;

        // ===== Constructor =====
        public MainForm()
        {
            InitializeComponent();

            PopulateStrings();

            radioBtnDailyView.Checked = true;
            PopulateData(SelectedDate);

            AppointmentReminder();
        }

        // ===== Helpers Methods =====
        private void PopulateStrings()
        {
            labelCalendar.Text = Properties.Strings.LabelCalendar;
            labelDailyAppt.Text = Properties.Strings.LabelAppointments;

            MenuItemAppt.Text = Properties.Strings.LabelAppointments;
            MenuItemCustomers.Text = Properties.Strings.LabelCustomer;
            MenuItemReports.Text = Properties.Strings.LabelReports;

            radioBtnDailyView.Text = Properties.Strings.RadioBtnDailyView;
            radioBtnMonthlyView.Text = Properties.Strings.RadioBtnMonthlyView;
        }

        private void PopulateData(DateTime selectedDate)
        {
            gridViewAppointments.DataSource = AppointmentDataAccess.PopulateDailyView(selectedDate);
        }

        private void RefreshCalendarView()
        {
            var date = SelectedDate;

            if (radioBtnDailyView.Checked)
                gridViewAppointments.DataSource = AppointmentDataAccess.PopulateDailyView(date);
            else
                gridViewAppointments.DataSource = AppointmentDataAccess.PopulateMonthlyView(date);
        }

        // ===== Appointment Alert =====
        private void AppointmentReminder()
        {
            try
            {
                DateTime? appointmentTime =
                AppointmentDataAccess.GetUpcomingAppointmentTime(Session.CurrentUserId);

                var localTime = TimeHelper.UtcToLocal(appointmentTime.Value);

                if (appointmentTime.HasValue)
                {
                    string reminder = string.Format(
                        Properties.Strings.AppointmentAlert,
                        localTime.ToString("h:mm tt"));

                    MessageBox.Show(reminder);
                }
            }
            catch
            {
                return;
            }
        }

        // ===== Navigation Menu =====
        private void MenuItemCustomers_Click(object sender, EventArgs e)
        {
            new CustomerForm().ShowDialog();
        }

        private void MenuItemAppt_Click(object sender, EventArgs e)
        {
            new AppointmentForm().ShowDialog();
        }

        private void MenuItemReports_Click(object sender, EventArgs e)
        {
            new ReportForm().ShowDialog();
        }

        // ===== Radio Button & Calendar Event Methods =====
        private void radioBtnDailyView_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCalendarView();
        }

        private void radioBtnMonthlyView_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCalendarView();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshCalendarView();
        }
    }
}
