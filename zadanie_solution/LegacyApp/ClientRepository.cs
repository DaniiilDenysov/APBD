using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class ClientRepository
    {
        /// <summary>
        /// This collection is used to simulate remote database
        /// </summary>
        public static readonly Dictionary<int, Client> Database = new Dictionary<int, Client>()
        {
            {1, new Client{ClientId = 1,ClientAddress = new Address{City="Warszawa",Street="Złota 12"}, Type = Client.Tag.NormalClient}},
            {2, new Client{ClientId = 2,ClientAddress = new Address{City="Warszawa",Street="Koszykowa 86"}, Type = Client.Tag.VeryImportantClient}},
            {3, new Client{ClientId = 3,ClientAddress = new Address{City="Warszawa",Street="Kolorowa 22"}, Type = Client.Tag.ImportantClient}},
            {4, new Client{ClientId = 4,ClientAddress = new Address{City="Warszawa",Street="Koszykowa 32"}, Type = Client.Tag.ImportantClient}},
            {5, new Client{ClientId = 5,ClientAddress = new Address{City="Warszawa",Street="Złota 52"}, Type = Client.Tag.NormalClient}},
            {6, new Client{ClientId = 6,ClientAddress = new Address{City="Warszawa",Street="Koszykowa 52"}, Type = Client.Tag.NormalClient}}
        };

        /// <summary>
        /// Simulating fetching a client from remote database
        /// </summary>
        /// <returns>Returning client object</returns>
        internal Client GetById(int clientId)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);

            if (Database.ContainsKey(clientId))
                return Database[clientId];

            throw new ArgumentException($"User with id {clientId} does not exist in database");
        }
    }
}