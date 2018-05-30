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
            Action<string> stringToVoidDelegate;
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
           
            var employeeSearch = (
                from employeeObject in db.Employees
                where employee.ID == employeeObject.ID
                select employeeObject).ToList();

            //stringToVoidDelegate = DoCrud;
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

        private static void DoCrud(string obj)
        {
           //blaaaaaaaaaaaaaaaaaaaaaaaahhhhh
        }

        public static Client GetClient(string username, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var client = (
                from user in db.Clients
                where user.userName == username && user.pass == password
                select user
                ).ToList();
            return client[0];
        }

        public static IQueryable<ClientAnimalJunction> GetUserAdoptionStatus(Client client) // this is the format we need to be using
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var approvalStatus = (
                from junction in db.ClientAnimalJunctions
                where junction.client == client.ID
                select junction);
            return approvalStatus;
        }

        public static Animal GetAnimalByID(int iD)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalObject = (
                from animal in db.Animals
                where iD == animal.ID
                select animal).ToList();
            return animalObject[0];
        }

        public static void Adopt(Animal animal, Client client) 
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            animal.adoptionStatus = "pending";
            ClientAnimalJunction clientAnimal = new ClientAnimalJunction();
            clientAnimal.animal = animal.ID; 
            clientAnimal.client = client.ID;
            db.ClientAnimalJunctions.InsertOnSubmit(clientAnimal);
            db.SubmitChanges();
            Console.WriteLine("Your application has been received.");
        }

        public static IQueryable<Client> RetrieveClients()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientQuery = (
                from allClients in db.Clients
                select allClients);
                return clientQuery;
        }

        public static IQueryable<USState> GetStates()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var allStates = (
                from name in db.USStates
                select name);
            return allStates;
        }

        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateID)
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
                select address
                ).ToList();
            client.userAddress = userAddress[0].ID;
            db.Clients.InsertOnSubmit(client);
            db.SubmitChanges();            
        }

        public static void UpdateClient(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var searchClients = (
                from searchClient in db.Clients
                where searchClient.ID == client.ID
                select searchClient);
            foreach (Client searchClient in searchClients)
            {
                searchClient.email = client.email;
                searchClient.firstName = client.firstName;
                searchClient.homeSize = client.homeSize;
                searchClient.income = client.income;
                searchClient.kids = client.kids;
                searchClient.lastName = client.lastName;
                searchClient.pass = client.pass;
                searchClient.userAddress = client.userAddress;
                searchClient.userName = client.userName;
            }            
            db.SubmitChanges();
            Console.WriteLine("Changes Submitted");
        }
               
        public static IQueryable<ClientAnimalJunction> GetPendingAdoptions() 
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var pendingApplicant = (
                from newlyApplied in db.ClientAnimalJunctions
                where newlyApplied.approvalStatus == "pending"
                select newlyApplied);
            return pendingApplicant;
        }

        internal static void UpdateAdoption(bool v, ClientAnimalJunction clientAnimalJunction)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            throw new NotImplementedException();
        }

        public static IQueryable<AnimalShotJunction> GetShots(Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalID =(
                from animalSearch in db.AnimalShotJunctions
                where animal.ID == animalSearch.Animal_ID
                select animalSearch
                );
            return animalID;
        }

        public static IQueryable<int> FindShotId(string v)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var shotId = (
                from shots in db.Shots
                where v.ToLower() == shots.name.ToLower()
                select shots.ID
                );
            return shotId;
        }

        internal static void UpdateShot(string v, Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var shotUpdate = (
                from update in db.AnimalShotJunctions
                where animal.ID == update.Animal_ID //&& update.Shot_ID == shotId
                select update
                );
            foreach(AnimalShotJunction updates in shotUpdate)
            {
                updates.dateRecieved = DateTime.Now;
            }
        }

        internal static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            throw new NotImplementedException();
        }

        internal static void RemoveAnimal(Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            throw new NotImplementedException();
        }

        public static int GetBreed(string breedString, string patternString)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var breedQueries = (
                from breedQuery in db.Breeds
                where breedString == breedQuery.breed1 && patternString == breedQuery.pattern
                select breedQuery).ToList();
            if (breedQueries.Count.Equals(0))
            {
                Breed breed = new Breed();
                breed.breed1 = breedString;
                breed.pattern = patternString;
                db.Breeds.InsertOnSubmit(breed);
                db.SubmitChanges();
                GetBreed(breedString, patternString);
            }
            return breedQueries[0].ID;
        }

        public static int GetDiet(string foodString, int dietAmount)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var dietQueries = (
                from dietQuery in db.DietPlans
                where foodString == dietQuery.food && dietAmount == dietQuery.amount
                select dietQuery).ToList();
            if (dietQueries.Count.Equals(0))
            {
                DietPlan dietplan = new DietPlan();
                dietplan.food = foodString;
                dietplan.amount = dietAmount;
                db.DietPlans.InsertOnSubmit(dietplan);
                db.SubmitChanges();
                GetDiet(foodString, dietAmount);
            }
            return dietQueries[0].ID;
        }

        public static int GetLocation()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            throw new NotImplementedException();
        }

        public static void AddAnimal(Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var employee = (
                from validEmployee in db.Employees
                where validEmployee.userName == userName && validEmployee.pass == password
                select validEmployee
            ).ToList();
            return employee[0];
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var employee = (
                from emp in db.Employees
                where emp.email == email && emp.employeeNumber == employeeNumber
                select emp
            ).ToList();
            return employee[0];
        }

        internal static void AddUsernameAndPassword(Employee employee)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            
        }

        internal static bool CheckEmployeeUserNameExist(string username)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            throw new NotImplementedException();
        }
    }
}
