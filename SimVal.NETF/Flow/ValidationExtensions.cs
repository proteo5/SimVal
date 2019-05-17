using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimVal.NETF.Flow
{
    public static class ValidationExtensions
    {
        public static Validation IsNotNull<T>(this Validation validation, T theObject, string paramName)
            where T : class
        {
            if (theObject == null)
                return (validation ?? new Validation()).AddException(new ArgumentException(paramName, "The object is null."));
            else
                return validation;
        }

        public static Validation IsNotEmpty(this Validation validation, string theObject, string paramName)
        {
            if (string.IsNullOrEmpty(theObject) || string.IsNullOrWhiteSpace(theObject))
                return (validation ?? new Validation()).AddException(new ArgumentException(paramName, "The string is empty."));
            else
                return validation;
        }

        public static Validation IsEmail(this Validation validation, string theObject, string paramName)
        {
            try
            {
                MailAddress m = new MailAddress(theObject);

                return validation;
            }
            catch (FormatException)
            {
                return (validation ?? new Validation()).AddException(new ArgumentException(paramName, "The string is not a valid email."));
            }
        }

        public static Validation RegexTest(this Validation validation, string theObject, string paramName, string regexValue, string message)
        {
            Regex regex = new Regex(regexValue);
            Match match = regex.Match(theObject);
            if (match.Success)
                return validation;
            else
                return (validation ?? new Validation()).AddException(new ArgumentException(paramName, message));
        }

        public static Validation IsEqual(this Validation validation, string theObject, string theObject2, string paramName)
        {
            if (theObject.Equals(theObject2))
                return validation;
            else
                return (validation ?? new Validation()).AddException(new ArgumentException(paramName, "The string are not equal."));
        }

        public static Validation Check(this Validation validation)
        {
            if (validation == null)
                return validation;
            else
            {
                throw new MultiException("Validation Fail.", new MultiException(validation.Exceptions)); // implementation shown below
            }
        }

    }

}
