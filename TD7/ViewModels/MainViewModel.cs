using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD7.Models;
using GalaSoft.MvvmLight.Command;

namespace TD7.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        // CONSTRUCTEUR 
        public MainViewModel()
        {
            this.NavigationRegistering<int>();
            this.GoToAlarmCommand = new RelayCommand(GoToAlarmExecute, CanGoToAlarmExecute);
        }

        protected async override Task OnLoadedAsync()
        {
            this.alarm = await this.DataService.GetAlarmAsync();
        }

        private Models.Alarm[] _alarm = null;
        public Models.Alarm[] alarm
        {
            get
            {
                return _alarm;
            }
            set
            {
                Set(() => alarm, ref _alarm, value);
            }
        }

        private Alarm _selectedAlarm = null;
        public Alarm SelectedAlarm
        {
            get
            {
                return _selectedAlarm;
            }
            set
            {
                Set(() => SelectedAlarm, ref _selectedAlarm, value);
            }
        }

        /* POUR LE BOUTON CREATION D'ALARME */

        public RelayCommand GoToAlarmCommand { get; private set; }

        public void GoToAlarmExecute()
        {
            this.NavigationService.NavigateTo(ViewModelLocator.CREER_ALARME_PAGE);
        }

        public bool CanGoToAlarmExecute()
        {
            return true;
        }
    }
}
