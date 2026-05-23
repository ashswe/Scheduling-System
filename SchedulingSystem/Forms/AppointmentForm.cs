using SchedulingSystem.Data;
using SchedulingSystem.Models;
using SchedulingSystem.Services;
using SchedulingSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchedulingSystem
{
    public partial class AppointmentForm : Form
    {
        // ===== Form Data & Fields =====
        public static readonly List<string> DurationMinutes = new() { "15", "30", "60" };
        public static readonly List<string> Locations = new() { "Phoenix, AZ", "New York, NY", "London, GB" };

        private int _selectedAppointmentId;
        private int _selectedDuration;

        // ===== Constructor =====
        public AppointmentForm()
        {
            InitializeComponent();

            PopulateData();
            datePickerAppt.Value = DateTime.Now;

            PopulateStrings();
        }

        // ===== Private Helpers =====
        private void PopulateStrings()
        {
            labelAppointments.Text = Properties.Strings.LabelAppointments;
            labelCustomer.Text = Properties.Strings.LabelCustomer;

            labelDate.Text = Properties.Strings.LabelDate;
            labelTime.Text = Properties.Strings.LabelTime;
            labelDuration.Text = Properties.Strings.LabelDuration;

            labelType.Text = Properties.Strings.LabelType;
            labelLocation.Text = Properties.Strings.LabelLocation;

            labelContact.Text = Properties.Strings.LabelContact;
            labelUrl.Text = Properties.Strings.LabelUrl;

            labelTitle.Text = Properties.Strings.LabelTitle;
            labelDescription.Text = Properties.Strings.LabelDescription;

            labelBusinessHours.Text = Properties.Strings.LabelBusinessHours;
            labelReqFields.Text = Properties.Strings.LabelReqFields;

            btnAdd.Text = Properties.Strings.ButtonAdd;
            btnUpdate.Text = Properties.Strings.ButtonUpdate;
            btnDelete.Text = Properties.Strings.ButtonDelete;
        }

        private void PopulateData()
        {
            // Populate Appointment GridView
            gridViewAppointments.DataSource = AppointmentDataAccess.PopulateAppointmentTable();

            // Populate Customer ComboBox
            comboBoxCustomer.DisplayMember = "customerName";
            comboBoxCustomer.ValueMember = "customerId";
            comboBoxCustomer.DataSource = CustomerDataAccess.CustomerList();

            // Populate Duration ComboBox
            comboBoxDuration.DataSource = DurationMinutes;

            // Populate Location ComboBox
            comboBoxLocation.DataSource = Locations;
        }

        private void RefreshAppointmentGrid()
        {
            gridViewAppointments.DataSource = AppointmentDataAccess.PopulateAppointmentTable();
        }

        private void gridViewAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridViewAppointments.Rows[e.RowIndex];

                if (row.IsNewRow || row.Cells["appointmentId"].Value == DBNull.Value)
                    return;

                var start = (DateTime)row.Cells["Start"].Value;
                var end = (DateTime)row.Cells["End"].Value;
                TimeSpan duration = end - start;

                _selectedDuration = (int)duration.TotalMinutes;
                _selectedAppointmentId = Convert.ToInt32(row.Cells["appointmentId"].Value);

                datePickerAppt.Value = (DateTime)row.Cells["Start"].Value;
                timePickerAppt.Value = (DateTime)row.Cells["Start"].Value;
                comboBoxDuration.Text = _selectedDuration.ToString();
                txtBoxType.Text = row.Cells["Type"].Value.ToString();
                comboBoxLocation.Text = row.Cells["Location"].Value.ToString();
                txtBoxContact.Text = row.Cells["Contact"].Value.ToString();
                txtBoxUrl.Text = row.Cells["Url"].Value.ToString();
                txtBoxTitle.Text = row.Cells["Title"].Value.ToString();
                richTxtBoxDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private bool ValidateAppointmentInput()
        {
            try
            {
                var customer = ValidationResult.ValidateCustomer(comboBoxCustomer.Text.Trim());
                if (!customer.IsValid)
                {
                    MessageBox.Show(customer.ErrorMessage);
                    return false;
                }

                var duration = ValidationResult.ValidateDuration(comboBoxDuration.Text.Trim());
                if (!duration.IsValid)
                {
                    MessageBox.Show(duration.ErrorMessage);
                    return false;
                }

                var type = ValidationResult.ValidateType(txtBoxType.Text.Trim());
                if (!type.IsValid)
                {
                    MessageBox.Show(type.ErrorMessage);
                    return false;
                }

                var location = ValidationResult.ValidateLocation(comboBoxLocation.Text.Trim());
                if (!location.IsValid)
                {
                    MessageBox.Show(location.ErrorMessage);
                    return false;
                }

                var contact = ValidationResult.ValidateContact(txtBoxContact.Text.Trim());
                if (!contact.IsValid)
                {
                    MessageBox.Show(contact.ErrorMessage);
                    return false;
                }

                var url = ValidationResult.ValidateUrl(txtBoxUrl.Text.Trim());
                if (!url.IsValid)
                {
                    MessageBox.Show(url.ErrorMessage);
                    return false;
                }

                var title = ValidationResult.ValidateTitle(txtBoxTitle.Text.Trim());
                if (!title.IsValid)
                {
                    MessageBox.Show(title.ErrorMessage);
                    return false;
                }

                var description = ValidationResult.ValidateDescription(richTxtBoxDescription.Text.Trim());
                if (!description.IsValid)
                {
                    MessageBox.Show(description.ErrorMessage);
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

        // ===== Model Objects =====
        private AppointmentModel BuildAppointmentFromForm()
        {
            var appt = new AppointmentModel
            {
                AppointmentId = _selectedAppointmentId,
                CustomerId = CustomerDataAccess.GetCustomerId(comboBoxCustomer.Text),
                UserId = UserDataAccess.GetUserId(Session.CurrentUser),
                Title = txtBoxTitle.Text.Trim(),
                Description = richTxtBoxDescription.Text.Trim(),
                Location = comboBoxLocation.SelectedItem.ToString(),
                Type = txtBoxType.Text.Trim(),
                Url = txtBoxUrl.Text.Trim(),
                Contact = txtBoxContact.Text.Trim(),
                Start = datePickerAppt.Value.Date + timePickerAppt.Value.TimeOfDay,
            };

            int duration = Convert.ToInt32(comboBoxDuration.SelectedItem);
            
            appt.End = appt.Start.AddMinutes(duration);

            return appt;
        }

        // ===== Add, Update, & Delete Methods =====
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAppointmentInput())
                {
                    var appt = BuildAppointmentFromForm();

                    DateTime startLocal = appt.Start;
                    DateTime endLocal = appt.End;

                    // Check if appointment is during EST business days/hours
                    var dateTime = ValidationResult.ValidateAppointmentDateTime(startLocal, endLocal);
                    if (!dateTime.IsValid)
                    {
                        MessageBox.Show(dateTime.ErrorMessage);
                        return;
                    }

                    // Check if appointment overlaps with existing appointments
                    DateTime startUtc = TimeHelper.LocalToUtc(startLocal);
                    DateTime endUtc = TimeHelper.LocalToUtc(endLocal);

                    string errorAppointmentExists = string.Format(
                        Properties.Strings.ErrorAppointmentExists,
                        appt.Start.DayOfWeek,
                        startLocal.ToShortTimeString(),
                        endLocal.ToShortTimeString()
                    );

                    if (AppointmentDataAccess.AppointmentOverlaps(startUtc, endUtc))
                    {
                        MessageBox.Show(errorAppointmentExists);
                        return;
                    }

                    // Add appointment
                    appt.Start = startUtc;
                    appt.End = endUtc;

                    AppointmentDataAccess.AddAppointment(appt, Session.CurrentUser);

                    RefreshAppointmentGrid();
                    MessageBox.Show(Properties.Strings.AppointmentAddSuccess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if appointment is selected
                if (_selectedAppointmentId == 0 || !AppointmentDataAccess.AppointmentExists(_selectedAppointmentId))
                {
                    MessageBox.Show(Properties.Strings.ErrorSelectAppointment);
                    return;
                }

                if (ValidateAppointmentInput())
                { 
                    var appt = BuildAppointmentFromForm();

                    DateTime startLocal = appt.Start;
                    DateTime endLocal = appt.End;

                    // Check if appointment is within EST business days/hours
                    var dateTime = ValidationResult.ValidateAppointmentDateTime(startLocal, endLocal);

                    if (!dateTime.IsValid)
                    {
                        MessageBox.Show(dateTime.ErrorMessage);
                        return;
                    }

                    // Check if appointment overlaps with existing appointments
                    DateTime startUtc = TimeHelper.LocalToUtc(appt.Start);
                    DateTime endUtc = TimeHelper.LocalToUtc(appt.End);

                    string errorAppointmentExists = string.Format(
                        Properties.Strings.ErrorAppointmentExists,
                        startLocal.DayOfWeek,
                        startLocal.ToShortTimeString(),
                        endLocal.ToShortTimeString()
                    );

                    if (AppointmentDataAccess.AppointmentOverlaps(startUtc, endUtc, _selectedAppointmentId))
                    {
                        MessageBox.Show(errorAppointmentExists);
                        return;
                    }

                    // Update appointment
                    appt.Start = startUtc;
                    appt.End = endUtc;

                    AppointmentDataAccess.UpdateAppointment(appt, Session.CurrentUser);

                    RefreshAppointmentGrid();
                    MessageBox.Show(Properties.Strings.AppointmentUpdateSuccess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedAppointmentId == 0 || !AppointmentDataAccess.AppointmentExists(_selectedAppointmentId))
                {
                    MessageBox.Show(Properties.Strings.ErrorSelectAppointment);
                    return;
                }

                AppointmentDataAccess.DeleteAppointment(_selectedAppointmentId);
                RefreshAppointmentGrid();
                MessageBox.Show(Properties.Strings.AppointmentDeleteSuccess);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }
    }
}
