using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;


namespace FitnessApp.ModelViews
{
    public class ExerciseViewModel : BaseViewModel
    {
        public const string JSON_EXERCISE_FILE = "myExercises.txt";

        #region attributes
        private string _day;
        public string Day
        {
            get { return _day; }
            set { SetValue(ref _day, value); }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { SetValue(ref _type, value); }
        }

        private int _setNumber;
        public int SetNumber
        {
            get { return _setNumber; }
            set { SetValue(ref _setNumber, value); }
        }

        private int _repetitionNumber;
        public int RepetitionNumber
        {
            get { return _repetitionNumber; }
            set { SetValue(ref _repetitionNumber, value); }
        }
        #endregion

        #region == Methods ==
        public static ObservableCollection<ExerciseViewModel> ReadExerciseListData()
        {
            ObservableCollection<ExerciseViewModel> myList = new ObservableCollection<ExerciseViewModel>();
            string jsonText;

            try  // reading the localApplicationFolder first
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, JSON_EXERCISE_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    // need json library
                }
            }
            catch // fallback is to read the default file
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(
                                                typeof(MainPage)).Assembly;
                // create the stream
                Stream stream = assembly.GetManifestResourceStream(
                                    "FitnessApp.Data.myExercises.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    // include JSON library now
                }
            }
            myList = JsonConvert.DeserializeObject<ObservableCollection<ExerciseViewModel>>(jsonText);
            return myList;
        }

        public static void WriteExerciseListData(ObservableCollection<ExerciseViewModel> saveList)
        {
            // need the path to the file
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, JSON_EXERCISE_FILE);
            // use a stream writer to write the list
            using (var writer = new StreamWriter(filename, false))
            {
                // stringify equivalent
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }

        public static void AddExercise()
        {
            //Exercise ex = new Exercise(Day, Type, SetNumber, repetitionNumber);

            //ExerciseViewModel
        }
        #endregion


    }
}


