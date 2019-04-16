using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FitnessApp.ModelViews
{
    class PersonPageViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<PersonViewModel> _personsData;

        public ObservableCollection<PersonViewModel> PersonsData
        {
            get
            {
                return _personsData;
            }
            set
            {
                SetValue(ref _personsData, value);
            }
        }

        private PersonViewModel _selectedPersonsData;

        public PersonViewModel SelectedPersonsData
        {
            get
            {
                return _selectedPersonsData;
            }
            set
            {
                SetValue(ref _selectedPersonsData, value);
            }
        }

        #endregion

        #region
        public ICommand SaveCommand { get; private set; }
        public ICommand NavigateToNewCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        #endregion
        public PersonPageViewModel()
        {
            ReadData();
            SaveCommand = new Command(SaveList);
            NavigateToNewCommand = new Command(NavigateToNew);
            DeleteCommand = new Command<PersonViewModel>(DeleteMeasurement);
           
        
    }

        private void DeleteMeasurement(object obj)
        {
            PersonsData.Remove((PersonViewModel)obj);
            SelectedPersonsData = null;
        }

        private async void NavigateToNew(object obj)
        {
          
            await App.Current.MainPage.Navigation.PushAsync(new NewMeasurementPage());//change back to PushAsync!
        }

        private void ReadData()
        {
            try
            {
                PersonsData = PersonViewModel.ReadPersonListData();
            }
            catch(FileNotFoundException)
            {
                Debug.WriteLine("File doesn't exist");
            }
        }
        private void SaveList()
        {
            PersonViewModel.WritePersonListData(PersonsData);
        }
        public void SelectOnePerson(PersonViewModel p)
        {
            SelectedPersonsData = p;
        }
    }
}