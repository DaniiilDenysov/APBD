using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var validator = new DefaultCredentialsValidator();
            if (!validator.IsNameAndSurnameValid(firstName,lastName)) return false;
            if (!validator.IsEmailValid(email)) return false;
            if (!validator.IsAgeValid(dateOfBirth)) return false;

            
            Client client = new ClientRepository().GetById(clientId);

            int creditLimit = 0;
            
            using (var userCreditService = new UserCreditService())
            {
                creditLimit = new DefaultCreditLimitController().AdjustCreditLimit(client.Type,userCreditService.GetCreditLimit(lastName));
            }

            if (creditLimit < 500)  return false;

            
            var user = new User
            {
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName,
                CreditLimit = creditLimit
            };
            
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
