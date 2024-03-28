using System;

namespace LegacyApp
{
    public interface IUserCredentialsValidator
    {
        bool IsEmailValid (string email);
        bool IsNameAndSurnameValid (string name, string surname);
        bool IsAgeValid(DateTime birthDate);
    }
}