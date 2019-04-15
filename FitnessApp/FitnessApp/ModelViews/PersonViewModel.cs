using FitnessApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;


namespace FitnessApp.ModelViews
{
    class PersonViewModel : BaseViewModel
    {
        public const string JSON_MEASUREMENTS_FILE = "myMeasurements.txt";
        #region == Attributes ==
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { SetValue(ref _photo, value); }

        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetValue(ref _date, value); }
        }

        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { SetValue(ref _gender, value); }
        }

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set { SetValue(ref _weight, value); }
        }


        private float _bmi;
        public float BMI
        {
            get { return _bmi; }
            set { SetValue(ref _bmi, value); }

        }

        private bool _bodyfat;
        public bool BodyFat
        {
            get { return _bodyfat; }
            set { SetValue(ref _bodyfat, value); }

        }
        #endregion
        #region == Methods ==
        
        public static ObservableCollection<PersonViewModel> ReadPersonListData()
        {
           
            ObservableCollection<PersonViewModel> myList = new ObservableCollection<PersonViewModel>();
            string jsonText;

            try  // reading the localApplicationFolder first
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, JSON_MEASUREMENTS_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    // need json library
                }
            }
            catch (JsonReaderException)// fallback is to read the default file
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(
                                                typeof(MainPage)).Assembly;
                // create the stream
                Stream stream = assembly.GetManifestResourceStream(
                                    "FitnessApp.Data.myMeasurements.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    // include JSON library now
                }
            }
            myList = JsonConvert.DeserializeObject<ObservableCollection<PersonViewModel>>(jsonText);
            return myList;
        }

        public static void WritePersonListData(ObservableCollection<PersonViewModel> saveList)
        {
            // need the path to the file
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, JSON_MEASUREMENTS_FILE);
            // use a stream writer to write the list
            using (var writer = new StreamWriter(filename, false))
            {
                // stringify equivalent
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }
        #endregion
    }
}
