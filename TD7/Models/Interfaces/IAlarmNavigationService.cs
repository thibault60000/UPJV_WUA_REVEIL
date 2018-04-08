using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7.Models.Interfaces
{
    interface IAlarmNavigationService : GalaSoft.MvvmLight.Views.INavigationService
    {
        void NavigateTo<T>(string pageKey, T parameter);
    }

}
