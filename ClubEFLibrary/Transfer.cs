using System;
using System.Collections.Generic;
using System.Text;

namespace libraryClubEF
{
    public class Transfer
    {
        public int TransferId { get; set; } // automatisch te genereren
        public Speler Speler { get; set; }
        public decimal TransferPrijs { get; set; }
        public Team oudTeam { get; set; }
        public Team nieuwTeam { get; set; }

        //simpele constructor
        public Transfer(decimal transferPrijs)
        {
            TransferPrijs = transferPrijs;
        }

        public Transfer(decimal transferPrijs, Speler speler, Team oud, Team nieuw) : this(transferPrijs)
        {
            Speler = speler;
            this.oudTeam = oud;
            this.nieuwTeam = nieuw;
        }

        public override string ToString()
        {
            return $"Transfer : {TransferId} met speler: {Speler.SpelerNaam} en prijs: {TransferPrijs} gaat van {oudTeam} naar {nieuwTeam}";
        }
    }
}
