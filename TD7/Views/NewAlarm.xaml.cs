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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace TD7.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class NewAlarm : Page
    {

        public NewAlarm()
        {
            this.InitializeComponent();
            Loaded += async delegate { await ViewModel.CallOnLoaded(); };
        }

        private ViewModels.NewAlarmViewModel ViewModel
        {
            get { return ((ViewModels.NewAlarmViewModel)Resources["ViewModel"]); }
        }



        /* ***************** PARTIE GESTION DU FORMULAIRE ************* */
        // Bouton ADD ALARM ON CLICK
        private async void add_alarm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // VARIABLES
                int snooze;
                string audioSrc;
                // Date
                int year = datepicker.Date.Year;
                int month = datepicker.Date.Month;
                int day = datepicker.Date.Day;
                // Heure
                int hour = timepicker.Time.Hours;
                int min = timepicker.Time.Minutes;
                int sec = timepicker.Time.Seconds;
                //  string audioSrc = alrm_sound.SelectionBoxItem.ToString();

                // Modificaction du nombre de répétition
                try
                {
                    snooze = Convert.ToInt16(CustomSnoozeTime.SelectionBoxItem.ToString());
                }
                // Par default : 2 
                catch
                {
                    snooze = 5;
                }

                // Modification de l'alarm e
                try
                {
                    audioSrc = alrm_sound.SelectionBoxItem.ToString();
                }
                // Par default : Default
                catch
                {
                    audioSrc = "Default";
                }

                // Date de l'alarme
                DateTime myDate1 = new DateTime(year, month, day, hour, min, sec);

                // Date courante
                DateTime myDate2 = DateTime.Now;

                // Intervalle de temps 
                TimeSpan myDateResult = new TimeSpan();
                // Prend comme valeur la différence entre les deux dates
                myDateResult = myDate1 - myDate2;

                // Si la date actuelle est plus supérieur à la date de l'alarme : Affiche une erreur
                if (myDate2 > myDate1)
                {
                    var x = new MessageDialog("Date ou Heure invalide");
                    await x.ShowAsync(); // Affiche l'alerte "x"
                }

                // Si la date est correcte
                else
                {
                    string alarmeTitle = alm_title.Text;
                    // Déclaration du toast
                    string title = alarmeTitle;
                    string message = alm_title.Text;
                    string imgURL = "ms-appx:///Assets/clock-alert.png";

                    string xml = @"<toast>
                            <visual>
                            <binding template='ToastImageAndText02'>
                                <text id='1'>" + message + "</text>"
                               + "<image id='1' src='" + imgURL + "'/>" +
                             "</binding></visual>\n" +
                             "<commands scenario=\"alarm\">\n" +
                             "<command id=\"snooze\"/>\n" +
                             "<command id=\"dismiss\"/>\n" +
                             "</commands>\n" +
                             "<audio src='ms-winsoundevent:Notification." +
                             audioSrc + "'/>" + "</toast>";

                    // DATA du Toast en XML
                    XmlDocument toastDOM = new XmlDocument();

                    // Charge le XML
                    toastDOM.LoadXml(xml);
                    // Création de la notification numéro 1 
                    var toastNotifier1 = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();

                    // Préparation futurs toasts
                    double x1 = myDateResult.TotalSeconds;

                    // Texte pour le Nombre de seconds avant la prochaine répétition
                    int customSnoozeSeconds = snooze * 60;

                    // Nombre de seconds avant la prochaine répétition
                    TimeSpan snoozeInterval = TimeSpan.FromSeconds(customSnoozeSeconds);

                    var customAlarmScheduledToast = new Windows.UI.Notifications.ScheduledToastNotification(toastDOM, DateTime.Now.AddSeconds(x1), snoozeInterval, 0);

                    // Ajouter une alarm
                    toastNotifier1.AddToSchedule(customAlarmScheduledToast);
                    var x = new MessageDialog("Alarme créée");
                    await x.ShowAsync();

                    ViewModel.AddAlarmList(title, myDate1, snooze);


                }

            }

            catch
            { }

        }







    }






}
