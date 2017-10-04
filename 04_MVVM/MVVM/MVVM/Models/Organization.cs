using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
// Model only depends on Data layer - calls the fake cloud service to load / update people in the organization

namespace Models
{
    public class Organization
    {
        public List<Person> People { get; set; } // List of people in organisation
        public String Name { get; set; } // Name of database being used

        public Organization(String databaseName)
        {
            Name = databaseName;
            People = FakeService.GetPeople(); // Get list of people from the fake service
        }

        public void Add(Person person)
        {
            /* If person to be added is not already in the list of people,
             * add them to the list of people in this class, and write/add them in the fake service class. */

            if (!People.Contains(person))
            {
                People.Add(person);
                FakeService.Write(person);
            }
        }

        public void Delete(Person person)
        {
            /* If the person to be deleted is in the list, 
             * remove them from the list of people and from the fake service. */

            if (People.Contains(person))
            {
                People.Remove(person);
                FakeService.Delete(person);
            }
        }

        public void Update(Person person)
        {
            // Write person to the existing entry in the fake service.
            FakeService.Write(person);
        }
    }
}