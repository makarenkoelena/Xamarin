using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitnessApp.ModelViews
{
    class MeasurementCollectionViewModel : BaseViewModel
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
        //public ICommand NavigateToNewCommand { get; private set; }


       
        #endregion
        public MeasurementCollectionViewModel()
        {
            ReadData();

            SaveCommand = new Command(SaveList);
            //NavigateToNewCommand = new Command(NavigateToNew);
        }

       
        private void SaveList(object obj)
        {
            //   PersonViewModel.ReadPersonListData(PersonsData);
        }

        private void ReadData()
        {
            PersonsData = PersonViewModel.ReadPersonListData();
        }
       
        //public void SelectOnePersons(PersonViewModel p)
        //{
        //    SelectedPerson = p;
        //}


    }
}