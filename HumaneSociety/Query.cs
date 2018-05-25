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
            //create
            //read
            //update
            //delete
        }
        static public Client GetClient(string username, string password)
        {
            //input username and password
            //return client
        }

        internal static object GetUserAdoptionStatus(Client client)
        {
            //get client return adoption
        }

        internal static object GetAnimalByID(int iD)
        {
            //search query for ID return animal object
        }

        internal static void Adopt(object animal, Client client)
        {
            //search for animal, search for client, assign animal to client, change adopted status on animal to adopted
        }

        internal static object RetrieveClients()
        {
           return //list of clients
        }

        internal static object GetStates()
        {
          //return list of all states
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            //add element to database using firstname, lastname, username, password, email, street adress, zipcode, state
        }

        internal static void updateClient(Client client)
        {
            //replace current client with client passed through
        }

        internal static void UpdateUsername(Client client) //figure out how to use delegates for employee and customer : INotifyPropertyChange
        {
           
        }

        internal static void UpdateEmail(Client client)//figure out how to use delegates for employee and customer : INotifyPropertyChange
        {
            
        }

        internal static void UpdateAddress(Client client) //try to make one update method
        {
            
        }

        internal static void UpdateFirstName(Client client) //try to make one update method
        {
           
        }

        internal static void UpdateLastName(Client client) //try to make one update method
        {
           
        }
        internal static object GetPendingAdoptions() 
        {
            //return all animals with a pending adoption
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
