using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    
    public static class Query
    {
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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var client = (from user in db.Clients where user.userName == username && user.pass == password select user).ToList();
            return client[0];
        }

        internal static object GetUserAdoptionStatus(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //get client return adoption
            var approvalStatus = (
                from foo in db.ClientAnimalJunctions
                from c in db.Clients
                where client.ID == c.ID
                select foo.approvalStatus
                ).ToString();
            return approvalStatus;
        }

        internal static object GetAnimalByID(int iD)
        {
            //need method to loop through Animal objects??
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //search query for ID return animal object
            var animalObject = (
                from animal in db.Animals
                where iD == animal.ID
                select animal
                );
                return animalObject;
        }

        internal static void Adopt(object animal, Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //search for animal, search for client, assign animal to client, change adopted status on animal to adopted
            var newlyAdopted = (
                from newFamily in db.ClientAnimalJunctions
                where client.ID == newFamily.Client1.ID
                    && animal.ID == newFamily.Animal1.ID
                select newFamily
                ).ToList();
            //^^^this is terribly wrong ***************************
        }

        internal static object RetrieveClients()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //return //list of clients
            var clientList = (
                from allClients in db.Clients
                select allClients
                ).ToList();
            return clientList;
        }

        internal static object GetStates()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //return list of all states
            var allStates = (
                from states in db.USStates
                select states
                ).ToList();
            return allStates;
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
