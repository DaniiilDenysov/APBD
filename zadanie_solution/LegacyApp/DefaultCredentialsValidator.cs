using System;

namespace LegacyApp
{
    public class DefaultCredentialsValidator : IUserCredentialsValidator
    {
        public bool IsEmailValid(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public bool IsNameAndSurnameValid(string firstName, string lastName)
        {
            return  !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
        }

        public bool IsAgeValid(DateTime birthDate)
        {
            var minimalDate = DateTime.Today.AddYears(-21);
            return birthDate <= minimalDate;
        }
    }
}