using System;
using System.Collections.Generic;
using System.Text;

namespace libraryClubEF
{
    class Speler
    {
        public int SpelerID { get; set; }
        public string SpelerNaam { get; set; }
        public int RugNummer { get; set; }
        public double Waarde { get; set; } // geschatte transferwaarde
        public Team Team { get; set; }
        public Speler()
        {

        }

    }
}
