using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsPOC.ViewModel;
using Xamarin.Forms;

namespace FormsPOC
{
    /// <summary>
    /// Main page.This class used to initialize components of Mainpage
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the MainPage class.
        /// </summary>

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
    }
}
