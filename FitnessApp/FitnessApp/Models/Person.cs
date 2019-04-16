using System;

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
        public float Waist { get; set; }
        public float Hip { get; set; }
        public float Forearm { get; set; }

        public Person(string photo, string name, Gender gender, float weight, float bMI, float bodyFat, float waist, float hip, float forearm)
        {
            Photo = photo;
            Name = name;
            Date = DateTime.Now;
            Gender = gender;
            Weight = weight;
            BMI = bMI;
            BodyFat = bodyFat;
            Waist = waist;
            Hip = hip;
            Forearm = forearm;
        }

        public Person(string photo, string name, DateTime date, Gender gender, float weight, float bMI, float bodyFat, float waist, float hip, float forearm)
        {
            Photo = photo;
            Name = name;
            Date = date;
            Gender = gender;
            Weight = weight;
            BMI = bMI;
            BodyFat = bodyFat;
            Waist = waist;
            Hip = hip;
            Forearm = forearm;
        }
        public Person() { }

    }
}
