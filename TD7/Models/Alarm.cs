using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7.Models
{
    class Alarm
    {
        public int Cle { get; set; }
        public String Titre { get; set; }

        public DateTime Date { get; set; }

        public int Repetition { get; set; }
        public override string ToString()
        {
            return $"{Titre}";
        }
    }
}