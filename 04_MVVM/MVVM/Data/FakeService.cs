using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Person
    {
        // Init name and age for Person
        public String Name { get; set; }
        public int Age { get; set; }
    }
    public class FakeService
    {
        // Imitating a service, not really *doing* anything
        public static String Name = "Fake Data Service.";
        public static List<Person> GetPeople()
        {
            Debug.WriteLine("GET for people.");
            return new List<Person>(){
                new Person() { Name="Chris Cole", Age=10 },
                new Person() { Name="Kelly Kale", Age=32 },
                new Person() { Name="Dylan Durbin", Age=18 }
            };
        }
        public static void Write(Person person)
        {
            // Output to console, imitating saving a person's details
            Debug.WriteLine("INSERT person with name " + person.Name);
        }
        public static void Delete(Person person)
        {
            // Imitating deleting a person's details
            Debug.WriteLine("DELETE person with name " + person.Name);
        }
    }
}