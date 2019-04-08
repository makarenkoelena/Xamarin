using FitnessApp.ModelViews;
using FitnessApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        //for debugging
        public ExercisePage()
        {
            InitializeComponent();
            BindingContext = new ExerciseCollectionViewModel();
            //((ExerciseCollectionViewModel)this.BindingContext).ExerciseList = ExerciseViewModel.ReadExerciseListData();
           
            //test in console if it loads the file
            //ObservableCollection<ExerciseViewModel> myList = ExerciseViewModel.ReadExerciseListData();

            //foreach (ExerciseViewModel i in myList)
            //{
            //    Debug.WriteLine(i.Type);
            //}
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ExerciseCollectionViewModel)this.BindingContext).SelectedDay = (ExerciseViewModel)e.SelectedItem;
        }

        private void saveNew_Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new InputPage());
        }
    }//end of class
}//namespace