using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    
    public static class Query
    {
        static public IEnumerable<Employee> RunEmployeeQueries(Employee employee, string crud)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
           
            var employeeSearch = (
                from employeeObject in db.Employees
                where employee.ID == employeeObject.ID
                select employeeObject).ToList();          
                      
            switch (crud)
            {
                case "create":
                    db.Employees.InsertOnSubmit(employee);
                    break;
                case "read":
                    break;
                case "update":
                    employeeSearch[0] = employee;
                    break;
                case "delete":
                    db.Employees.DeleteOnSubmit(employee);                
                    break;
                                           
            }
            db.SubmitChanges();
            return employeeSearch;

        }

        
        public static Client GetClient(string username, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var client = (from user in db.Clients where user.userName == username && user.pass == password select user).ToList();
            return client[0];
        }

        public static IEnumerable<ClientAnimalJunction> GetUserAdoptionStatus(Client client) // this is the format we need to be using
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //get client return adoption
            var approvalStatus = (
                from junction in db.ClientAnimalJunctions
                where junction.client == client.ID
                select junction
                );
                return approvalStatus;
        }

        public static Animal GetAnimalByID(int iD)

        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //search query for ID return animal object
             var animalObject = (
                from animal in db.Animals
                where iD == animal.ID
                select animal
                ).ToList();
            return animalObject[0];
        }

        public static void Adopt(Animal animal, Client client) 
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //search for animal, search for client, assign animal to client, change adopted status on animal to pending approval
            var newApplicant = (
                from newlyApplied in db.ClientAnimalJunctions
                where client.ID == newlyApplied.Client1.ID
                    && animal.ID == newlyApplied.Animal1.ID
                select newlyApplied
                ).ToList();
            foreach(ClientAnimalJunction newlyAdopted in newApplicant)
            {
                newlyAdopted.approvalStatus = "pending";
            }  
        }

        public static IEnumerable<Client> RetrieveClients()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //return //list of clients
            var clientList = (
                from allClients in db.Clients
                select allClients
                ).ToList();
            return clientList;
        }

        public static IEnumerable<USState> GetStates()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //return list of all states
            var allStates = (
                from name in db.USStates
                select name
                ).ToList();
            return allStates;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateID)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Client client = new Client();
            client.firstName = firstName;
            client.lastName = lastName;
            client.userName = username;
            client.pass = password;
            client.email = email;
            UserAddress address = new UserAddress();
            address.addessLine1 = streetAddress;
            address.zipcode = zipCode;
            var userState = (
                from state in db.USStates
                where state.ID == stateID
                select state
                ).ToList();                
            address.USState = userState[0];
            db.UserAddresses.InsertOnSubmit(address);
            db.SubmitChanges();
            var userAddress = (
                from addresses in db.UserAddresses
                where streetAddress == address.addessLine1
                select address).ToList();
            client.userAddress = userAddress[0].ID;
            db.Clients.InsertOnSubmit(client);
            db.SubmitChanges();

        }

        internal static void UpdateClient(Client client)
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
        internal static IEnumerable<ClientAnimalJunction> GetPendingAdoptions() 
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //search for animal, search for client, assign animal to client, change adopted status on animal to pending approval

            var pendingApplicant = (
                from newlyApplied in db.ClientAnimalJunctions
                where newlyApplied.approvalStatus == "pending" 
                select newlyApplied
                );
            return pendingApplicant;
        }

        internal static void UpdateAdoption(bool v, ClientAnimalJunction clientAnimalJunction)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<AnimalShotJunction> GetShots(Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalID =(
                from animalSearch in db.AnimalShotJunctions
                where animal.ID == animalSearch.Animal_ID
                select animalSearch
                );
            return animalID;
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
