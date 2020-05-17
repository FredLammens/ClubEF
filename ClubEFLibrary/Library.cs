using libraryClubEF;
using System;
using System.Linq;

namespace ClubEFLibrary
{
    public class Library
    {
        ClubContext context = new ClubContext();
        public void VoegSpelerToe(Speler speler)
        {
            Console.WriteLine("Adding speler...");
            context.Add(speler);
            context.SaveChanges();
            Console.WriteLine($"speler: {speler.SpelerNaam} added.");
        }
        public void VoegTeamToe(Team team)
        {
            Console.WriteLine("Adding Team...");
            context.Add(team);
            context.SaveChanges();
            Console.WriteLine($"Team: {team.TeamNaam} added.");
        }
        public void VoegTransferToe(Transfer transfer)
        {
            Console.WriteLine("Adding transfer...");
            context.Add(transfer);
            context.SaveChanges();
            Console.WriteLine(transfer + " added.");
        }
        public void UpdateSpeler(Speler speler)
        {
            //object opvragen aanpassen en SaveChanges oproeopen
            using (context)
            {
                #region update
                //speler object opvragen
                /*Speler spelerItem = context.Spelers.SingleOrDefault(spelerDB => spelerDB.SpelerId == speler.SpelerId);
                //
                if (spelerItem != null)
                {
                    //setvalues spelerITem
                    //SaveChanges
                }*/
                #endregion
                context.Update(speler);
                context.SaveChanges();
            }
        }
        public void UpdateTeam(Team team) { }
        /*#region ryan
        public Speler SelecteerSpeler(int spelerID) { }
        public Team SelecteerTeam(int stamnummer) { }
        public Transfer SelecteerTransfer(int transferID) { }
        #endregion*/
    }
}
