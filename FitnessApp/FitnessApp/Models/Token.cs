using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    class Token
    {
        public string Id { get; set; }
        public string Access_token { get; set; }
        public string Error_description { get; set; }
        public DateTime expire_date { get; set; }


        public Token() { }
    }
}
