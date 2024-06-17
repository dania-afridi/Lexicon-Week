using Assignment_01.Models.Entities;
using Assignment_01.Models.ViewModels;

namespace Assignment_01.Models.Services
{
    public interface IPeopleService
    {
        Person Add(PersonViewModel personModel);
        List<Person> All();
        List<Person> Search(string search);
        Person SearchById(int id);
        bool Edit(int id, PersonViewModel personModel);
        bool Delete(int id);
        
    }
}
