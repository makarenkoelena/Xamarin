using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitnessApp.ModelViews
{
    class NewMeasurementViewModel : BaseViewModel
    {

        //public PersonViewModel NewMeasurements
        //{
        //    get; set;
        //}
        private PersonViewModel _newMeasurements = new PersonViewModel();

        public PersonViewModel NewMeasurements
        {
            get { return _newMeasurements; }
            set { SetValue(ref _newMeasurements, value); }
        }

        public ICommand AddNewMeasurements { get; private set; }

        public NewMeasurementViewModel()
        {
            
            AddNewMeasurements = new Command<PersonViewModel>(AddMeasurement);
           // NewMeasurements = new PersonViewModel();
        }

        private void AddMeasurement(object obj)
        {
            ObservableCollection<PersonViewModel> measurementList = PersonViewModel.ReadPersonListData();

            //measurementList.Add((PersonViewModel)obj);
            measurementList.Add(NewMeasurements);
            
            PersonViewModel.WritePersonListData(measurementList);
        }

    }
}
