using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BodyFat : ContentPage
    {
     

        public BodyFat()
        {
            //Debug.WriteLine("CHILD ONE");
            InitializeComponent();
            setDefaultSettings();
            //VisibleFields();
        }

        private void setDefaultSettings()
        {
            var assembly = typeof(MainPage);

            List<string> cmList = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                cmList.Add(i.ToString("00"));
            }
           
        }
         private void VisibleFields()
        {
            
        }

        private void EntHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test = ((Entry)sender).ClassId;
        }

        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
            //ref:
            double leanBodyWeight;
            double bodyFatPercentage;

            string Gender = Convert.ToString(pckgender.SelectedItem);
            if (Gender.Equals("F"))
            {
                leanBodyWeight = (0.732 * Convert.ToDouble(entWeight.Text)) - (0.157 * Convert.ToDouble(entWaist.Text)) - (0.249 * Convert.ToDouble(entHip.Text)) + (0.434 * Convert.ToDouble(entForearm.Text)) + (Convert.ToDouble(entWrist.Text) / 3.14) + 8.987;
                bodyFatPercentage = (Convert.ToDouble(entWeight.Text) - leanBodyWeight) / Convert.ToDouble(entWeight.Text)*100  ;
                lblAnswer.Text = "Your lean Body Weight is: " + leanBodyWeight.ToString("0.00");
                lblAnswer2.Text = "Your Body Fat is: " + bodyFatPercentage.ToString("0.00");
            }
            else if (Gender.Equals("M"))
            {
                leanBodyWeight = (1.082 * (Convert.ToDouble(entWeight.Text))) - (4.15 * Convert.ToDouble(entWaist.Text)) + 94.42;
                bodyFatPercentage = (Convert.ToDouble(entWeight.Text) - leanBodyWeight) / Convert.ToDouble(entWeight.Text)*100;
                lblAnswer.Text = "Your lean Body Weight is: " + leanBodyWeight.ToString("0.00");
                lblAnswer2.Text = "Your Body Fat is: " + bodyFatPercentage.ToString("0.00");
            }
        }

        private void pckgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedGender = pckgender.SelectedIndex;
            
            if (pckgender.SelectedIndex == 1)//F
            {
                sHip_measurement.IsVisible = true;
                sForearm_measurement.IsVisible = true;
                sWrist_measurement.IsVisible = true;
            }
            else
            {
                //sWrist_measurement.IsVisible = false;
                sHip_measurement.IsVisible = false;
                sForearm_measurement.IsVisible = false;
                sWrist_measurement.IsVisible = false;
            }
        }

        
        //public event EventHandler pckgenderHandle_PickerSelectedIndexChanged (object sender, EventArgs e) 
        //{
        //    if (pckgender.SelectedItem.equals("M")
        //    {
        //        entHip.Text.IsVisible = false;
        //        entForearm.Text.IsVisible = false;
        //        entWrist.Text.Text.IsVisible = false;
        //    }
        //    else
        //    {
        //        entHip.Text.IsVisible = true;
        //        entForearm.Text.IsVisible = true;
        //        entWrist.Text.Text.IsVisible = true;
        //    }
        //}

        //    pckgender.SelectedIndexChanged += (sender, args) =>
        //        {
        //            if (pckgender.SelectedIndex == 1)
        //            {
        //                 entHip.Text.IsVisible = true;
        //                entForearm.Text.IsVisible = true;
        //                entWrist.Text.Text.IsVisible = true;


        //            }
        //            else
        //            {
        //               entHip.Text.IsVisible = false;
        //            entForearm.Text.IsVisible = false;
        //            entWrist.Text.Text.IsVisible = false;
        //            }
        //        };
    }
}