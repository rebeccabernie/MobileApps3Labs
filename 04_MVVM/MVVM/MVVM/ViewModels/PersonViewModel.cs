using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

/* This is the ViewModel for a Person. It maintains a reference to an underlying
 * person, the class creates gets and sets for each of the properties that rely
 * on the underlying person for storage, and it sends INotifyPropertyChanged events
 * when the property is set. */

namespace ViewModels
{

    public class PersonViewModel : NotificationBase<Person>
    {
        public PersonViewModel(Person person = null) : base(person) { }

        // Handling getting / setting name and age
        public String Name
        {
            get { return This.Name; }
            set { SetProperty(This.Name, value, () => This.Name = value); }
        }
        public int Age
        {
            get { return This.Age; }
            set { SetProperty(This.Age, value, () => This.Age = value); }
        }
    }
}