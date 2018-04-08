using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7.Models
{
    class AlarmDataService : Models.Interfaces.IAlarmDataService
    {
        // List d'alarmes 
        private List<Alarm> alarmes = null;
        private int arraySize;

        public async Task<Alarm[]> GetAlarmAsync()
        {             
            return await Task.Run(() =>
            {
                alarmes = new List<Alarm>();
                DateTime Date = new DateTime(2008, 3, 1, 7, 0, 0);
                AddAlarmSync("Mon Alarme", Date, 2);

                // console.WriteLine(date1.ToString("F", new System.Globalization.CultureInfo("fr-FR")));
                // Displays samedi 1 mars 2008 07:00:00
                return alarmes.ToArray();
            });
        }


        public async Task<Alarm> GetAlarmAsync(int cleAlarm)
        {
            return await Task.Run(() =>
            {
                return alarmes.ToArray().FirstOrDefault(i => i.Cle == cleAlarm);
            });
        }

        public async void AddAlarmSync(string titre, DateTime date, int repetition)
        {
            if (alarmes.ToArray().Length == 0)
            {
                this.arraySize = 1;
            }
            else
            {
                this.arraySize = alarmes.ToArray().Length + 1;
            }
            await Task.Run(() =>
            {

                alarmes.Add(new Alarm()
                {
                    Cle = arraySize,
                    Titre = titre,
                    Date = date,
                    Repetition = repetition
                });
            });
        }

    }
}
