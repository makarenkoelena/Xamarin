using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BMIPage : ContentPage
    {
      
        public BMIPage()
        {
            InitializeComponent();
            setDefaultSettings();
        }

        private void setDefaultSettings()
        {
            //bW =  false;
            // Add image to screen
            var assembly = typeof(MainPage);
            string fileName = "FitnessApp.Data.bmi.jfif";
            imgBMIChart.Source = ImageSource.FromResource(fileName, assembly);

            List<string> cmList = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                cmList.Add(i.ToString("00"));
            }
            pckCM.ItemsSource = cmList;
            pckCM.SelectedIndex = 75;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // reset the values to 0
            //bH = bW = false;
            //entHeight.Text = "";
            //entWeight.Text = "";
            //btnCalculate.IsEnabled = false;
            //lblAnswer.Text = "Your BMI is: ";
        }

        private void BtnCalculate_Clicked(object sender, EventArgs e)
        {
            //Picker picker = new Picker();
            //double bmi = (Convert.ToDouble(entWeight.Text) / (Convert.ToDouble(entHeight.Text) * Convert.ToDouble(entHeight.Text)));
            // Calculate BMI
            // lblAnswer.Text = "Your BMI is: " + bmi.ToString("0.00");

            // Create tap gestrure object
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            tapGestureRecognizer.NumberOfTapsRequired = 2;

            // Add to image
            imgBMIChart.GestureRecognizers.Add(tapGestureRecognizer);

            double height = 0.01;
            height = Convert.ToDouble(pckHM.SelectedItem + "." + pckCM.SelectedItem);
            double dblBMI = Convert.ToDouble(entWeight.Text) / (height * height);
            lblAnswer.Text = "Your BMI is: " + dblBMI.ToString("0.00");
        }

        private void EntHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test = ((Entry)sender).ClassId;
            // Verify it's a number and something has been entered
            //    if (entHeight.Text == "")
            //    {
            //        bH = false;
            //        btnCalculate.IsEnabled = false;
            //        lblAnswer.Text = "Your BMI is: ";
            //    }
            //    else
            //    {
            //        bH = true;
            //    }

            //    if (entWeight.Text == "")
            //    {
            //        bW = false;
            //        btnCalculate.IsEnabled = false;
            //        lblAnswer.Text = "Your BMI is: ";
            //    }
            //    else
            //    {
            //        bW = true;
            //    }

            //    if (bH && bW) btnCalculate.IsEnabled = true;
        }
    }//end of class
}//namespace