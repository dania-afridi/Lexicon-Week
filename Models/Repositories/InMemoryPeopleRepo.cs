using Assignment_01.Models.Entities;
using Assignment_01.Models.ViewModels;

namespace Assignment_01.Models.Repositories
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> people = new List<Person>();
        private static int idCounter = 0;

        //----- Methods------

        //------------ Creating Person ---------------//
        public Person Create(Person person) 
        {
            person.Id = idCounter++;
            people.Add(person);
            return person;
        }

        //------------ Deleting Person ---------------//
        public bool Delete(Person person)
        {
            var personTodelete = Read(person.Id);
            if(personTodelete == null)
            {
                return false;
            }
            people.Remove(personTodelete);
            return true;
        }

        //------------ Read List of Persons ---------------//

        public List<Person> Read()
        {
            return people;  
        }

        //------------ Read List of Persons by ID---------------//
        public Person Read(int id)
        {
            return people.FirstOrDefault(p => p.Id == id);
        }

        //------------ update Persons info ---------------//
        public bool Update(Person person)
        {
            var personIndex = people.FindIndex(p => p.Id == person.Id);
            if(personIndex == -1)
            {
                return false ;
            }
            people[personIndex] = person;
            return true;
        }
    }
}
