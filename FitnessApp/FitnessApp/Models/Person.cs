using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    public enum Gender
    {
        Female = 0, Male = 1
    }

    public class Person
        {
            public string Photo { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public Gender Gender { get; set; }
            public float Weight { get; set; }
            public float BMI { get; set; }
            public float BodyFat { get; set; }          

            public Person(string photo, string name, DateTime date, Gender gender, float weight, float bmi, float bodyfat)
            {
                Photo = photo;
                Name = name;
                Date = date;
                Gender = gender;
                Weight = weight;
                BMI = bmi;
                BodyFat = bodyfat;       
            }
        }
}
