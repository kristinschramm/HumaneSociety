using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {

        //member variables

        //constructor

        //member method

        static public void RunEmployeeQueries(Employee employee, string crud)
        {

        }
        static public Client GetClient(string username, string password)
        {
            Client client = new Client(); // write query to return an instance of client
            return client;
        }

        internal static object GetUserAdoptionStatus(Client client)
        {
            throw new NotImplementedException();
        }

        internal static object GetAnimalByID(int iD)
        {
            throw new NotImplementedException();
        }

        internal static void Adopt(object animal, Client client)
        {
            throw new NotImplementedException();
        }

        internal static object RetrieveClients()
        {
            throw new NotImplementedException();
        }

        internal static object GetStates()
        {
            throw new NotImplementedException();
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            throw new NotImplementedException();
        }

        internal static void updateClient(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateUsername(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateEmail(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateAddress(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateFirstName(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateLastName(Client client)
        {
            throw new NotImplementedException();
        }
        internal static object GetPendingAdoptions()
        {
            throw new NotImplementedException();
        }

        internal static void UpdateAdoption(bool v, ClientAnimalJunction clientAnimalJunction)
        {
            throw new NotImplementedException();
        }

        internal static object GetShots(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateShot(string v, Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            throw new NotImplementedException();
        }

        internal static void RemoveAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static int? GetBreed()
        {
            throw new NotImplementedException();
        }

        internal static int? GetDiet()
        {
            throw new NotImplementedException();
        }

        internal static int? GetLocation()
        {
            throw new NotImplementedException();
        }

        internal static void AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            throw new NotImplementedException();
        }

        internal static void AddUsernameAndPassword(Employee employee)
        {
            throw new NotImplementedException();
        }

        internal static bool CheckEmployeeUserNameExist(string username)
        {
            throw new NotImplementedException();
        }
    }
}
