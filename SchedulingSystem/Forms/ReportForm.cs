using SchedulingSystem.Data;
using SchedulingSystem.Models;
using SchedulingSystem.Services;
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
    public partial class ReportForm : Form
    {
        private readonly List<string> reports = new() { "Appointment Types by Month", "Schedule for Each User", "Appointments by Location" };
        
        List<AppointmentModel> appointments = AppointmentDataAccess.GetAllAppointments();
        List<UserModel> users = UserDataAccess.GetAllUsers();
        
        private ReportService _reportService;
        private string? SelectedReport => Convert.ToString(comboBoxReports.SelectedValue);

        public ReportForm()
        {
            InitializeComponent();
            PopulateStrings();

            comboBoxReports.DataSource = reports;
        }

        private void PopulateStrings()
        {
            labelReports.Text = Properties.Strings.LabelReports;
            labelReportType.Text = Properties.Strings.LabelReportType;
        }
        private void comboBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _reportService = new ReportService(appointments, users);
                gridViewReports.DataSource = _reportService.GetReport(SelectedReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }
    }
}
