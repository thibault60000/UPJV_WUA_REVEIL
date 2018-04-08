using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System.Threading;
using Windows.Data.Xml.Dom;
using TD7.ViewModels;

/* Thibault JEANPIERRE / Vacandard Clément / Boivin Jérémy */

namespace TD7.Views
{

    // MAIN PAGE
    public sealed partial class MainPage : Page
    {
        // Déclaration d'un Dispatcher Timer
        DispatcherTimer timer = new DispatcherTimer();


        // CONSTRUCTEUR
        public MainPage()
        {
            this.InitializeComponent();

            Loaded += async delegate { await ViewModel.CallOnLoaded(); };

            // Attribut un interval d'une seconde avant d'appeler la fonction Timer_Tick
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

           
        }

        // Déclaration ViewModel
        private ViewModels.MainViewModel ViewModel
        {
            get { return ((ViewModels.MainViewModel)Resources["ViewModel"]); }
        }


        // Fonction modifiant l'input de la date courante 
        private void Timer_Tick(object sender, object e)
        {
            current_time.Text = DateTime.Now.ToString();
        }


       


    }
}

