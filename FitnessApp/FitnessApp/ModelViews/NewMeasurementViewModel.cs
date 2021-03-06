﻿using Android.Webkit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitnessApp.ModelViews
{
    class NewMeasurementViewModel : BaseViewModel
    {
        private PersonViewModel _newMeasurements = new PersonViewModel();

        public PersonViewModel NewMeasurements
        {
            get { return _newMeasurements; }
            set { SetValue(ref _newMeasurements, value); }
        }

        public ICommand AddNewMeasurements { get; private set; }
        public ICommand CameraCommand { get; private set; }

        public NewMeasurementViewModel()
        {
            
            AddNewMeasurements = new Command<PersonViewModel>(AddMeasurement);
            // NewMeasurements = new PersonViewModel();
            CameraCommand = new Command<PersonViewModel>(CameraButton_Clicked);
           
        }

        
        private async void CameraButton_Clicked(PersonViewModel obj)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            //if (photo != null)
            //    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
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
