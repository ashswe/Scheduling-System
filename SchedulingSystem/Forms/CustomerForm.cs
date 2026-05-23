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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SchedulingSystem
{
    public partial class CustomerForm : Form
    {
        // ===== Fields & Properties =====
        private int _selectedCustomerId;
        private int _selectedAddressId;

        int? CountryId => comboBoxCountry.SelectedValue as int?;
        int? CityId => comboBoxCity.SelectedValue as int?;

        // ===== Constructor =====
        public CustomerForm()
        {
            InitializeComponent();

            PopulateStrings();
            PopulateData();
        }

        // ===== Private Helpers =====
        private void PopulateStrings()
        {
            labelCustomerManagement.Text = Properties.Strings.LabelCustomerManagement;
            labelName.Text = Properties.Strings.LabelName;
            labelAddress.Text = Properties.Strings.LabelAddress;
            labelAddress2.Text = Properties.Strings.LabelAddress2;
            labelCity.Text = Properties.Strings.LabelCity;
            labelCountry.Text = Properties.Strings.LabelCountry;
            labelPostalCode.Text = Properties.Strings.LabelPostalCode;
            labelPhone.Text = Properties.Strings.LabelPhone;
            checkBoxActive.Text = Properties.Strings.LabelActive;

            btnAdd.Text = Properties.Strings.ButtonAdd;
            btnUpdate.Text = Properties.Strings.ButtonUpdate;
            btnDelete.Text = Properties.Strings.ButtonDelete;
        }

        private void PopulateData()
        {
            // Populate Customer Grid
            gridViewCustomers.DataSource = CustomerDataAccess.PopulateCustomerTable();

            // Populate comboBoxCountry
            comboBoxCountry.DisplayMember = "country";
            comboBoxCountry.ValueMember = "countryId";
            comboBoxCountry.DataSource = LocationDataAccess.GetCountries();
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCountry.SelectedValue is int countryId)
            {
                comboBoxCity.DisplayMember = "city";
                comboBoxCity.ValueMember = "cityId";
                comboBoxCity.DataSource = LocationDataAccess.GetCitiesByCountryId(countryId);
            }
        }

        private void gridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridViewCustomers.Rows[e.RowIndex];

                if (row.IsNewRow || row.Cells["customerId"].Value == DBNull.Value)
                    return;

                _selectedCustomerId = Convert.ToInt32(row.Cells["customerId"].Value);
                _selectedAddressId = Convert.ToInt32(row.Cells["addressId"].Value);

                txtBoxName.Text = row.Cells["customerName"].Value.ToString();
                txtBoxAddress.Text = row.Cells["address"].Value.ToString();
                txtBoxAddress2.Text = row.Cells["address2"].Value.ToString();
                comboBoxCity.Text = row.Cells["city"].Value.ToString();
                comboBoxCountry.Text = row.Cells["country"].Value.ToString();
                txtBoxPostalCode.Text = row.Cells["postalCode"].Value.ToString();
                txtBoxPhone.Text = row.Cells["phone"].Value.ToString();
                checkBoxActive.Checked = Convert.ToBoolean(row.Cells["active"].Value);
            }
        }

        private void RefreshCustomerGrid()
        {
            gridViewCustomers.DataSource = CustomerDataAccess.PopulateCustomerTable();
        }

        private void RefreshCities()
        {
            if (comboBoxCountry.SelectedValue is int countryId)
            {
                comboBoxCity.DataSource = LocationDataAccess.GetCitiesByCountryId(countryId);
            }
        }

        private void RefreshCountries()
        {
            comboBoxCountry.DataSource = LocationDataAccess.GetCountries();
        }

        private bool ValidateCustomerInput()
        {
            try
            {
                var name = ValidationResult.ValidateName(txtBoxName.Text.Trim());
                if (!name.IsValid)
                {
                    MessageBox.Show(name.ErrorMessage);
                    return false;
                } 

                var address = ValidationResult.ValidateAddress(txtBoxAddress.Text.Trim());
                if (!address.IsValid)
                {
                    MessageBox.Show(address.ErrorMessage);
                    return false;
                }

                var city = ValidationResult.ValidateCity(comboBoxCity.Text.Trim());
                if (!city.IsValid)
                {
                    MessageBox.Show(city.ErrorMessage);
                    return false;
                }

                var postalCode = ValidationResult.ValidatePostalCode(txtBoxPostalCode.Text.Trim());
                if (!postalCode.IsValid)
                {
                    MessageBox.Show(postalCode.ErrorMessage);
                    return false;
                }

                var country = ValidationResult.ValidateCountry(comboBoxCountry.Text.Trim());
                if (!country.IsValid)
                {
                    MessageBox.Show(country.ErrorMessage);
                    return false;
                }

                var phone = ValidationResult.ValidatePhone(txtBoxPhone.Text.Trim());
                if (!phone.IsValid)
                {
                    MessageBox.Show(phone.ErrorMessage);
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
        private CustomerModel BuildCustomerFromForm()
        {
            var customer = new CustomerModel
            {
                CustomerId = _selectedCustomerId, //CustomerDataAccess.GetCustomerId(txtBoxName.Text.Trim())
                CustomerName = txtBoxName.Text.Trim(),
                Active = checkBoxActive.Checked
            };

            return customer;
        }

        private AddressModel BuildAddressFromForm()
        {
            var address = new AddressModel
            {
                AddressId = _selectedAddressId,
                Address = txtBoxAddress.Text.Trim(),
                Address2 = txtBoxAddress2.Text.Trim(),
                PostalCode = txtBoxPostalCode.Text.Trim(),
                Phone = txtBoxPhone.Text.Trim(),
            };

            return address;
        }

        // ===== Add, Update & Delete Methods =====
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string city = comboBoxCity.Text.Trim();
            string country = comboBoxCountry.Text.Trim();
            string username = Session.CurrentUser;

            try
            {
                if (ValidateCustomerInput())
                {
                    var customer = BuildCustomerFromForm();
                    var address = BuildAddressFromForm();

                    if (!LocationDataAccess.CountryExists(country))
                    {
                        LocationDataAccess.AddCountry(country, username);
                        RefreshCountries();
                    }

                    if (!LocationDataAccess.CityExists(city, (int)CountryId))
                    {
                        LocationDataAccess.AddCity(city, (int)CountryId, username);
                        RefreshCities();
                    }

                    CustomerDataAccess.AddCustomerWithAddress(customer, address, (int)CityId, username);

                    RefreshCustomerGrid();
                    MessageBox.Show(Properties.Strings.CustomerAddSuccess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string city = comboBoxCity.Text.Trim();
            string country = comboBoxCountry.Text.Trim();
            string username = Session.CurrentUser;

            var customer = BuildCustomerFromForm();
            var address = BuildAddressFromForm();

            try
            {
                if (_selectedCustomerId == 0)
                {
                    MessageBox.Show(Properties.Strings.ErrorSelectCustomer);
                    return;
                }

                if (ValidateCustomerInput())
                {
                    if (!LocationDataAccess.CountryExists(country))
                    {
                        LocationDataAccess.AddCountry(country, username);
                        RefreshCountries();
                    }

                    if (!LocationDataAccess.CityExists(city, (int)CountryId))
                    {
                        int cityId = LocationDataAccess.AddCity(city, (int)CountryId, username);
                        RefreshCities();
                    }

                    CustomerDataAccess.UpdateCustomerWithAddress(customer, address, (int)CityId, username);

                    RefreshCustomerGrid();
                    MessageBox.Show(Properties.Strings.CustomerUpdateSuccess);
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
                if (_selectedCustomerId == 0 || !CustomerDataAccess.CustomerExists(_selectedCustomerId))
                {
                    MessageBox.Show(Properties.Strings.ErrorSelectCustomer);
                    return;
                }

                CustomerDataAccess.DeleteCustomerAddressAppointment(_selectedCustomerId, _selectedAddressId);

                RefreshCustomerGrid();
                MessageBox.Show(Properties.Strings.CustomerDeleteSuccess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Strings.ErrorMsgGeneral + ex);
            }
        }
    }
}
