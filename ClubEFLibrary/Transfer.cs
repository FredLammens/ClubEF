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

        //simpele constructor
        public Transfer(decimal transferPrijs)
        {
            TransferPrijs = transferPrijs;
        }

        public Transfer(decimal transferPrijs, Speler speler) : this(transferPrijs)
        {
            Speler = speler;
        }

        public override string ToString()
        {
            return $"Transfer : {TransferId} met speler: {Speler.SpelerNaam} en prijs: {TransferPrijs}";
        }
    }
}
