using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchedulingSystem.Utilities
{
    public class ValidationResult
    {
        // ===== Properties =====

        public bool IsValid { get; }
        public string ErrorMessage { get; }

        // ===== Constructor =====
        private ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
        
        // ===== Success & Fail =====
        public static ValidationResult Success()
            => new(true, "");

        public static ValidationResult Fail(string message)
            => new(false, message);

        // ===== Input Validators =====
        // Login & Registration Input
        public static ValidationResult ValidateUsernamePasswordInput(string usernameInput, string passwordInput)
        {
            if (string.IsNullOrWhiteSpace(usernameInput) && string.IsNullOrWhiteSpace(passwordInput))
                return Fail(Properties.Strings.ErrorNoUsernamePassword);

            return Success();
        }

        public static ValidationResult ValidateUsernameInput(string usernameInput)
        {
            if (string.IsNullOrWhiteSpace(usernameInput))
                return Fail(Properties.Strings.ErrorNoUsername);

            return Success();
        }

        public static ValidationResult ValidatePasswordInput(string passwordInput)
        {
            if (string.IsNullOrWhiteSpace(passwordInput))
                return Fail(Properties.Strings.ErrorNoPassword);

            return Success();
        }

        // User & Customer Data
        public static ValidationResult ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Fail(Properties.Strings.ErrorNameRequired);

            if (!Regex.IsMatch(name, @"^[A-Za-z]+$"))
                return Fail(Properties.Strings.ErrorName);

            return Success();
        }
        public static ValidationResult ValidateCustomer(string customer)
        {
            if (string.IsNullOrWhiteSpace(customer))
                return Fail(Properties.Strings.ErrorCustomerRequired);

            return Success();
        }

        // Location Data
        public static ValidationResult ValidateAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return Fail(Properties.Strings.ErrorAddressRequired);

            if (!Regex.IsMatch(address, @"^[a-zA-Z0-9-]*$"))
                return Fail(Properties.Strings.ErrorAddress);

            return Success();
        }

        public static ValidationResult ValidateCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return Fail(Properties.Strings.ErrorCityRequired);

            if (!Regex.IsMatch(city, @"^[a-zA-Z]*$"))
                return Fail(Properties.Strings.ErrorCity);

            return Success();
        }

        public static ValidationResult ValidateCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                return Fail(Properties.Strings.ErrorCountryRequired);

            if (!Regex.IsMatch(country, @"^[a-zA-Z]*$"))
                return Fail(Properties.Strings.ErrorCountry);

            return Success();
        }

        public static ValidationResult ValidatePostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
                return Fail(Properties.Strings.ErrorPostalCodeRequired);

            if (!Regex.IsMatch(postalCode, @"^[0-9-]*$"))
                return Fail(Properties.Strings.ErrorPostalCode);

            if (postalCode.Length < 3 || postalCode.Length > 10)
                return Fail(Properties.Strings.ErrorPostalLength);

            return Success();
        }

        public static ValidationResult ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return Fail(Properties.Strings.ErrorPhoneRequired);

            if (!Regex.IsMatch(phone, @"^[0-9-]*$"))
                return Fail(Properties.Strings.ErrorPhone);

            if (phone.Trim('-').Length < 10 || phone.Trim('-').Length > 15)
                return Fail(Properties.Strings.ErrorPhoneLength);

            return Success();
        }

        // Appointment Data
        public static ValidationResult ValidateType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Fail(Properties.Strings.ErrorTypeRequired);

            if (!Regex.IsMatch(type, @"^[a-zA-Z]*$"))
                return Fail(Properties.Strings.ErrorType);

            return Success();
        }

        public static ValidationResult ValidateLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return Fail(Properties.Strings.ErrorLocationRequired);

            if (!AppointmentForm.Locations.Contains(location))
                return Fail(Properties.Strings.ErrorLocation);

            return Success();
        }

        public static ValidationResult ValidateContact(string contact)
        {
            if (string.IsNullOrWhiteSpace(contact))
                return Fail(Properties.Strings.ErrorContactRequired);

            return Success();
        }

        public static ValidationResult ValidateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return Fail(Properties.Strings.ErrorUrlRequired);

            return Success();
        }

        public static ValidationResult ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Fail(Properties.Strings.ErrorTitleRequired);

            if (!Regex.IsMatch(title, @"^[a-zA-Z]*$"))
                return Fail(Properties.Strings.ErrorTitle);

            return Success();
        }

        public static ValidationResult ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Fail(Properties.Strings.ErrorDescRequired);

            return Success();
        }

        public static ValidationResult ValidateDuration(string duration)
        {
            if (!AppointmentForm.DurationMinutes.Contains(duration))
                return Fail(Properties.Strings.ErrorDuration);

            return Success();
        }

        // DateTime Validation (Business Days & Hours)
        public static ValidationResult ValidateAppointmentDateTime(DateTime startLocal, DateTime endLocal)
        {
            var startLocalOffset = new DateTimeOffset(startLocal, TimeZoneInfo.Local.GetUtcOffset(startLocal));
            var endLocalOffset = new DateTimeOffset(endLocal, TimeZoneInfo.Local.GetUtcOffset(endLocal));

            DateTime startUtc = startLocalOffset.UtcDateTime;
            DateTime endUtc = endLocalOffset.UtcDateTime;

            TimeZoneInfo eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            DateTime startEastern = TimeZoneInfo.ConvertTimeFromUtc(startUtc, eastern);
            DateTime endEastern = TimeZoneInfo.ConvertTimeFromUtc(endUtc, eastern);

            bool weekday =
                startEastern.DayOfWeek is not DayOfWeek.Saturday
                && startEastern.DayOfWeek is not DayOfWeek.Sunday
                && endEastern.DayOfWeek is not DayOfWeek.Saturday
                && endEastern.DayOfWeek is not DayOfWeek.Sunday;

            TimeSpan open = new(9, 0, 0);
            TimeSpan close = new(17, 0, 0);

            bool withinHours =
                startEastern.TimeOfDay >= open &&
                endEastern.TimeOfDay <= close;

            if (startLocal >= endLocal)
                return Fail(Properties.Strings.ErrorDateTime);

            if (!weekday || !withinHours)
            {
                return Fail(Properties.Strings.ErrorDateTime);
            }
            return Success(); 
        }

    }
}
