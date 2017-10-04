using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using Models;

/* Core of the application - ViewModel for the Organisation Class. Inherits 
 * from NotificationBase to provide default implementation of INotifyPropertyChanged. */

namespace ViewModels
{
    public class OrganizationViewModel : NotificationBase
    {
        Organization organization;

        public OrganizationViewModel(String name)
        {
            organization = new Organization(name);
            _SelectedIndex = -1;
            // Load the database
            foreach (var person in organization.People)
            {
                var np = new PersonViewModel(person);
                np.PropertyChanged += Person_OnNotifyPropertyChanged;
                _People.Add(np);
            }
        }

        /* ObservableCollection property (_People) provides a XAML-bindable implementation of
         * the List<Person>. Doesn't do much outside of being loaded through the underlying model.
         * Initialise collection in constructor, when we make changes to the ObservableCollection,
         * we update the Model. */

        ObservableCollection<PersonViewModel> _People = new ObservableCollection<PersonViewModel>();
        public ObservableCollection<PersonViewModel> People
        {
            get { return _People; }
            set { SetProperty(ref _People, value); }
        }

        String _Name;
        public String Name
        {
            get { return organization.Name; }
        }

        /* SelectedIndex and SelectedPerson are interconnected.
         * SIndex gets and sets from XAML, SPerson corresponds to SIndex. 
         * User interface View will move SelectedIndex when user clicks on list.
         * Once user has selected a Person, the View enables the user to update the properties of the SelectedPerson.
         * When the SelectedIndex is updated, a property changed notification is fired on the SelectedPerson. */

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set { if (SetProperty(ref _SelectedIndex, value)) { RaisePropertyChanged(nameof(SelectedPerson)); } }
        }

        public PersonViewModel SelectedPerson
        {
            get { return (_SelectedIndex >= 0) ? _People[_SelectedIndex] : null; }
        }

        /* Add and Delete are just normal functions on OrganisationViewModel.
         * View will be able to bind these actions in response to user input - send 
         * changes to the collection and underlying Model. 
         * When a property is changed on one of the PersonViewModel objects, an event is fired,
         * which is caught in the OrganisationViewModel and used to send update to underlying model
         * and finally the data service (fake service) - enabled with following code:
         * person.PropertyChanged += Person_OnNotifyPropertyChanged. */
        public void Add()
        {
            var person = new PersonViewModel();
            person.PropertyChanged += Person_OnNotifyPropertyChanged;
            People.Add(person);
            organization.Add(person);
            SelectedIndex = People.IndexOf(person);
        }

        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var person = People[SelectedIndex];
                People.RemoveAt(SelectedIndex);
                organization.Delete(person);
            }
        }

        void Person_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            organization.Update((PersonViewModel)sender);
        }
    }
}