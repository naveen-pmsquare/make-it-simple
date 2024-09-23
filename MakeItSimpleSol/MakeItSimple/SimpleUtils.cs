using System.Net.Mail;
using System.Text;

namespace MakeItSimple
{
    /// <summary>
    /// Simple utility methods
    /// </summary>
    public static class SimpleUtils
    {
        private static readonly Random random = new();
        private const string chars = "@#$%*AaBbCcDdEeFfGgHhIjJiKkLlMmNnOoPpQqRrSsTtUuVvWwXzYyZz0123456789";

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="pEmail">The email address to validate.</param>
        /// <returns>A tuple containing a boolean indicating whether the email is valid and a message describing the result.</returns>
        public static (bool result, string message) IsValidEmail(string? pEmail)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pEmail))
                {
                    return (false, "Invalid email address");
                }

                var mail = new MailAddress(pEmail);
                bool isValidEmail = mail.Host.Contains('.');
                return (isValidEmail == true, isValidEmail == true ? "Valid email address" : "Invalid email address");
            }
            catch (Exception exception)
            {
                return (false, exception.Message);
            }
        }

        /// <summary>
        /// Generate unique id
        /// </summary>
        public static string UniqueId
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// Validates a mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number to be validated. It should not be null or empty, and should have a length equal to the default length (default: 10).</param>
        /// <param name="defaultLength">The default length of the mobile number. If not provided, it defaults to 10.</param>
        /// <returns>A tuple containing a boolean indicating whether the mobile number is valid or not, and a message indicating the validation result. If the mobile number is valid, the message will be "Valid mobile number". Otherwise, it will indicate the reason for invalidity.</returns>
        public static (bool result, string message) IsValidMobileNumber(string mobileNumber, int defaultLength = 10)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber?.Trim())) { return (false, "Invalid mobile number"); }

            if (mobileNumber.Length != defaultLength) { return (false, "Invalid mobile number length"); }

            if (!mobileNumber.All(char.IsNumber)) { return (false, "Invalid mobile number"); }

            return (false, "Valid mobile number");
        }

        /// <summary>
        /// Checks if any of the given string values is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="values">The string values to check.</param>
        /// <returns>True if any of the values is null, empty, or consists only of white-space characters; otherwise, false.</returns>
        public static bool IsNullOrWhitespace(params string?[] values)
        {
            if (values?.Any() != true)
            {
                return true;
            }

            if (values.Any(string.IsNullOrWhiteSpace))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Generates a random string of the specified length.
        /// </summary>
        /// <param name="defaultLength">The length of the string to generate. Default is 8.</param>
        /// <returns>A random string of the specified length.</returns>
        public static string GenerateRandomString(int defaultLength = 8)
        {
            int length = defaultLength;

            if (length <= 0)
            {
                length = 8;
            }

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Formats the given file name by replacing certain characters with underscores and converting it to lowercase.
        /// </summary>
        /// <param name="fileName">The file name to be formatted.</param>
        /// <returns>A tuple containing a boolean indicating the status of the formatting (true if successful, false otherwise)
        /// and the formatted file name.</returns>
        public static (bool status, string result) FormatFileName(string? fileName)
        {

            if (string.IsNullOrWhiteSpace(fileName?.Trim()))
            {
                return (false, "Invalid file name");
            }

            var result = fileName.Trim();

            result = result.Replace("(", "_")
                .Replace(")", "_")
                .Replace("[", "_")
                .Replace("]", "_")
                .Replace("{", "_")
                .Replace("}", "_")
                .Replace("-", "_")
                .Replace("+", "_")
                .Replace(" ", "_")
                .Replace("!", "_");

            return (true, result.ToLower());
        }
    }
}
