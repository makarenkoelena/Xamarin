using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitnessApp.ModelViews
{
    class ExerciseCollectionViewModel:BaseViewModel
    {
        #region == private fields ==
        private ObservableCollection<ExerciseViewModel> _exerciseList;
        private ExerciseViewModel _selectedDay;
        #endregion

        #region == Public Properties ==
        public ObservableCollection<ExerciseViewModel> ExerciseList
        {
            get { return _exerciseList; }
            set { SetValue(ref _exerciseList, value); }
        }
        public ExerciseViewModel SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                SetValue(ref _selectedDay, value);

            }
        }
        #endregion
        public ExerciseCollectionViewModel() {
            ReadExercise();
            SaveListCommand = new Command(SaveList);
        }

        private void SaveList(object obj)
        {
            ExerciseViewModel.WriteExerciseListData(ExerciseList);
        }

        private void ReadExercise()
        {
            ExerciseList = ExerciseViewModel.ReadExerciseListData();
        }

        public ICommand SaveListCommand { get; private set; }                  
    }
}
