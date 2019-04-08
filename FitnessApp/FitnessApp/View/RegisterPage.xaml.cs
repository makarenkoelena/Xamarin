using FitnessApp.Models;
using FitnessApp.ModelViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        public RegisterPage()
        {
            InitializeComponent();
            //test in console if it loads the file
            BindingContext = new UserViewModel();   
        }
        
        public async Task btnRegister_Clicked(object sender, EventArgs e)
        {
            App.app.addUser(new User(email.Text, username.Text, password.Text));
            await Navigation.PopAsync();//when registered go back to the main page
        }

       
    }
}