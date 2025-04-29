namespace Assignment4_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4_1.Services
{
    public class AddressBook
    {
        private Dictionary<string, Person> _people = new Dictionary<string, Person>();

        public bool AddPerson(Person person)
        {
            if (_people.ContainsKey(person.FullName))
                return false:

            _people.Add(person.FullName, person);
            return true;
        }

        public bool DeletePerson(string fullName)
        {
            return _people.Remove(fullName);
        }

        public Person FindPerson(string fullName)
        {
            _people.TryGetValue(fullName, out Person person);
            return person;
        }

        public List<Person> ListAllPeople()
        {
            return _people.Values.ToList();
        }
    }
}