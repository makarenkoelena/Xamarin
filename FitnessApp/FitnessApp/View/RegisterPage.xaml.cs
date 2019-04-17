using FitnessApp.Models;
using FitnessApp.ModelViews;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
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

            BindingContext = new UserViewModel();
        }
        //ref:https://social.msdn.microsoft.com/Forums/en-US/7364a191-15cc-453e-8007-65a83e717410/password-complexity-in-c?forum=csharpgeneral
        public async Task btnRegister_Clicked(object sender, EventArgs e)
        {
            string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$";
            try
            {
                if (App.app.isRegistered(email.Text, password.Text))
                {
                    await DisplayAlert("Alert", "User already exists", "OK");
                }
                else
                {
                    if (!email.Text.Contains("@"))
                    {
                        await DisplayAlert("Alert", "Email doesnt contain @ symbol", "OK");
                    }
                    else if (!Regex.IsMatch(password.Text, patternPassword))
                    {
                        await DisplayAlert("Alert", "Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.", "OK");
                    }

                    else
                    {
                        App.app.addUser(new User(email.Text, username.Text, password.Text));
                        await DisplayAlert("Alert", "Successful registration", "OK");
                        await Navigation.PopAsync();//when registered go back to the main page
                    }
                }
            }


            catch (NullReferenceException)
            {
                await DisplayAlert("Alert", "Fields can't be empty", "OK");
            }
        }
    }
}