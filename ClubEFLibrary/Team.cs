using System;
using System.Collections.Generic;
using System.Text;

namespace libraryClubEF
{
    class Team
    {
        public int StamNummer { get; set; } //niet automatisch te genereren
        public string TeamNaam { get; set; }
        public string TeamBijnaam { get; set; }
        public string Trainer { get; set; }//enkel naam
        public ICollection<Speler> spelers { get; set; }

    }
}
