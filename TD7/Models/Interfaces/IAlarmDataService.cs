using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7.Models.Interfaces
{
    interface IAlarmDataService
    {
        Task<Alarm[]> GetAlarmAsync();
        Task<Alarm> GetAlarmAsync(int cleAlarm);
    }
}
