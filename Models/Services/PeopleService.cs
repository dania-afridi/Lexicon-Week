using Assignment_01.Models.Entities;
using Assignment_01.Models.Repositories;
using Assignment_01.Models.ViewModels;
using System;

namespace Assignment_01.Models.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo peopleRepos;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            peopleRepos = peopleRepo;
        }
        //------------- Adding person in repos -------------//
        public Person Add(PersonViewModel personModel)
        {
            var person = new Person
            {
                Name = personModel.Name,
                City = personModel.City,
                PhoneNumber = personModel.PhoneNumber
            };
            return peopleRepos.Create(person);
        }

        //------------- Getting list of persons through repos -------------//
        public List<Person> All()
        {
            return peopleRepos.Read();
        }
        //------------- Search person from repos -------------//
        public List<Person> Search(string search)
        {
            return peopleRepos.Read().Where(p  => p.Name == search).ToList();
        }
        //------------- Search person from repos by id -------------//
        public Person SearchById(int id)
        {
            return peopleRepos.Read(id);
        }
        //------------- Delete person from repos úsing id -------------//
        public bool Delete(int id)
        {
            var person = peopleRepos.Read(id);
            return person != null && peopleRepos.Delete(person);
        }
        //------------- Editing and updating person from repos -------------//
        public bool Edit(int id, PersonViewModel personModel)
        {
            var person = peopleRepos.Read(id);
            if (person == null) 
            {
                return false;
            }
            person.Name = personModel.Name;
            person.City = personModel.City;
            person.PhoneNumber = personModel.PhoneNumber;
            
            return peopleRepos.Update(person);
        }

    }
}
