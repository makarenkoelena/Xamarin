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
	public partial class TabbedPage1 : TabbedPage
    {
		public TabbedPage1 ()
		{
			InitializeComponent ();
            this.CurrentPage = this.Children[1];//when tabbed pages open start from this page
        }
	}
}