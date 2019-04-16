using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FitnessApp.Models
{
   public class User
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public User() {  }

        //public User(string Email) {
        //    this.Email = Email;
        //}

        public User(string Email, string Username, string Password)
        {
            this.Email = Email;
            this.Username = Username;
            this.Password = Password;  
        }   
    }
}

