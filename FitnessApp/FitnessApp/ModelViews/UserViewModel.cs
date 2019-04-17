using FitnessApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace FitnessApp.ModelViews
{
    public class UserViewModel
    {
        private const string USERS_SAVE_FILE = "users.txt";
        List<User> userList = new List<User>();

        public UserViewModel()
        {
            userList = ReadUsers();
        }
        public static List<User> ReadUsers()
        {
            //App myapp = (App)Xamarin.Forms.Application.Current;
            List<User> myList = new List<User>();
            string jsonText;

            try  // reading the localApplicationFolder first
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, USERS_SAVE_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    // need json library
                }
            }
            catch// fallback is to read the default file
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(
                                                typeof(MainPage)).Assembly;
                // create the stream
                Stream stream = assembly.GetManifestResourceStream(
                                    "FitnessApp.Data.localusers.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    // include JSON library now
                }
            }

            myList = JsonConvert.DeserializeObject<List<Models.User>>(jsonText);
            return myList;
        }
        public static void SaveUsersData(List<Models.User> userList)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);//breakpoint here f10
            string fileName = Path.Combine(path, USERS_SAVE_FILE);//name of the file

            using (var writer = new StreamWriter(fileName, false))
            {
                string stringifiedText = JsonConvert.SerializeObject(userList);

                writer.WriteLine(stringifiedText);
            }
        }

        public void addUser(User user)
        {
            userList.Add(user);
            SaveUsersData(userList);
        }

        public bool checkInfo(String email, String password)
        {
            foreach (User u in userList)
            {
                if (email.Equals(u.Email) && password.Equals(u.Password))
                {
                   return true;
                }
            }
            return false;
        }

        public bool isRegistered(String email, String password)
        {
            foreach (User u in userList)
            {
                if (email.Equals(u.Email) && password.Equals(u.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
