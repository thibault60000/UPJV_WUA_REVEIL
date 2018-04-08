using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace TD7.ViewModels
{
    class NewAlarmViewModel : ViewModelBase
    {
        
        public NewAlarmViewModel()
        {
            this.BackMainCommand = new RelayCommand(BackMainExecute, CanBackMainExecute);
        }

        public void AddAlarmList(string title, DateTime date, int repetition)
        {
            this.DataService.AddAlarmSync(title, date, repetition);
        }
    

        public RelayCommand BackMainCommand { get; private set; }

        public void BackMainExecute()
        {
            this.NavigationService.NavigateTo(ViewModelLocator.MAIN_PAGE);
        }

        public bool CanBackMainExecute()
        {
            return true;
        }
    }
}
