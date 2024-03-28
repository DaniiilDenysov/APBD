using System;

namespace LegacyApp
{
    public class User
    {
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        public int CreditLimit { get; internal set; }
    }
}