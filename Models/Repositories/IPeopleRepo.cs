using Assignment_01.Models.Entities;

namespace Assignment_01.Models.Repositories
{
    public interface IPeopleRepo
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        bool Update(Person person);
        bool Delete(Person person);
    }
}
