using System;
using System.Collections.Generic;
using System.Text;

namespace libraryClubEF
{
    public class Speler
    {
        public int SpelerId { get; set; } // wordt door DB gegenerate
        public string SpelerNaam { get; set; }
        public int RugNummer { get; set; }
        public double Waarde { get; set; } // geschatte transferwaarde

        //simpele constructor met geen verwijzing naar andere klassen voor EF
        public Speler(string spelerNaam, int rugNummer, double waarde)
        {
            SpelerNaam = spelerNaam;
            RugNummer = rugNummer;
            Waarde = waarde;
        }
    }
}
