using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TD7.Views
{
    class AlarmNavigationService : GalaSoft.MvvmLight.Views.NavigationService, Models.Interfaces.IAlarmNavigationService
    {
        public void NavigateTo<T>(string pageKey, T parameter)
        {
            base.NavigateTo(pageKey, parameter);
            Messenger.Default.Send<T>(parameter);
        }

        public new void NavigateTo(string pageKey, object parameter)
        {
            this.NavigateTo<object>(pageKey, parameter);
        }

    }



}
