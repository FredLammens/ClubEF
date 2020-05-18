using libraryClubEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;

namespace ClubEFLibrary
{
    public class Library
    {
        ClubContext context = new ClubContext();
        #region voegToe
        public void VoegSpelerToe(Speler speler)
        {
            Console.WriteLine("Adding speler...");
            context.Add(speler);
            context.SaveChanges();
            Console.WriteLine($"{speler} added.");
        }
        public void VoegTeamToe(Team team)
        {
            Console.WriteLine("Adding Team...");
            context.Add(team);
            context.SaveChanges();
            Console.WriteLine($"{team} added.");
        }
        public void VoegTransferToe(Transfer transfer)
        {
            Console.WriteLine("Adding transfer...");
            context.Add(transfer);
            //transfer uitvoeren
            Speler spelerItem = context.Spelers.Single(s => s.Equals(transfer.Speler));
            Team oudTeam = context.Teams.Single(t => t.Equals(transfer.oudTeam));
            Team nieuwTeam = context.Teams.Single(t => t.Equals(transfer.nieuwTeam));
            oudTeam.spelers.Remove(spelerItem);
            nieuwTeam.spelers.Add(spelerItem);
            //save changes
            context.SaveChanges();
            Console.WriteLine(transfer + " added.");
        }
        #endregion
        #region update
        public void UpdateSpeler(Speler speler)
        {
            Console.WriteLine("Start updating speler");
            //speler object opvragen
            Speler spelerItem = context.Spelers.SingleOrDefault(spelerDB => spelerDB.SpelerId == speler.SpelerId);//indien niets teruggevonden => null object weer
            if (spelerItem != null)
            {
                //setvalues spelerITem
                spelerItem.RugNummer = speler.RugNummer;
                spelerItem.SpelerId = speler.SpelerId;
                spelerItem.SpelerNaam = speler.SpelerNaam;
                spelerItem.Waarde = speler.Waarde;
                //SaveChanges
                context.SaveChanges();
                Console.WriteLine($"{speler} updated");
            }
            else
            {
                Console.WriteLine($"{speler} niet gevonden");
            }
        }
        public void UpdateTeam(Team team)
        {
            Console.WriteLine("Start updating team");
            //Team object opvragen
            Team teamItem = context.Teams.Include(t => t.spelers).SingleOrDefault(teamDB => teamDB.StamNummer == team.StamNummer);//include om spelers mee te nemen
            if (teamItem != null)
            {
                //setvalues TeamItem
                //teamItem.spelers = team.spelers;

                // door alle spelers van teamItem 
                for (int i = 0; i < teamItem.spelers.Count; i++)
                {
                    int spelerIndex = team.spelers.IndexOf(teamItem.spelers.);
                    if (team.spelers.Contains(teamItem.spelers[i])) ;// zit de speler niet in het team
                }
                
                // zoja verwijder speler uit teamItem

                //door alle spelers van team 
                // zit speler nog niet in teamItem
                // is speler al in databank zoja
                // speler uit databank halen
                // speler in teamItem steken 
                // zonee 
                // voeg speler toe 

                teamItem.TeamBijnaam = team.TeamBijnaam;
                teamItem.TeamNaam = team.TeamNaam;
                teamItem.Trainer = team.Trainer;
                //SaveChanges
                context.SaveChanges();
                Console.WriteLine($"Team: {team} updated");
            }
            else
            {
                Console.WriteLine($"Team: {team} is niet gevonden");
            }
        }
        #endregion
        #region Selectie
        public Speler SelecteerSpeler(int spelerID)
        {
            return context.Spelers.FirstOrDefault(s => s.SpelerId == spelerID);
        }
        public Team SelecteerTeam(int stamnummer)
        {
            return context.Teams.FirstOrDefault(t => t.StamNummer == stamnummer);
        }
        public Transfer SelecteerTransfer(int transferID)
        {
            return context.Transfers.FirstOrDefault(transfer => transfer.TransferId == transferID);
        }
        #endregion
        #region InitialiseerDB
        public void InitialiseerDatabank(string path)
        {
            List<Team> teams = GetTeamsFromFile(path);
            Console.WriteLine("Inserting teams");
            using (context)
            {
                context.Teams.AddRange(teams);
                context.SaveChanges();
            }
            Console.WriteLine("Teams inserted");
        }
        /// <summary>
        /// Leest lijn per lijn en geeft lijst van lijnen terug opgesplitst door delimeter
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimeter">indien niets standaard ;</param>
        /// <returns></returns>
        private List<string[]> FileReader(string path, char delimeter = ';')
        {
            List<string[]> lines = new List<string[]>();
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                Console.WriteLine("Loading File : ");
                int teller = 0;
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] splitted = s.Split(delimeter);
                    lines.Add(splitted);
                    teller++;
                    if (teller == 1)
                    {
                        Console.Write("*");
                        teller = 0;
                    }
                }
            }
            Console.WriteLine("\nFile read");
            return lines;
        }
        private List<Team> GetTeamsFromFile(string path)
        {
            Console.WriteLine("Loading Teams from file");
            List<string[]> file = FileReader(path, ',');
            string spelerNaam; int rugNummer; int waarde; //spelerinfo
            string teamNaam; int stamNummer; string trainer; string teamBijnaam;  //teaminfo
            List<Team> teams = new List<Team>();
            foreach (string[] fileLine in file.Skip(1))
            {
                spelerNaam = fileLine[0];
                rugNummer = int.Parse(fileLine[1]);
                teamNaam = fileLine[2];
                string temp = fileLine[3].Replace(" ", String.Empty);
                waarde = int.Parse(temp);
                stamNummer = int.Parse(fileLine[4]);
                trainer = fileLine[5];
                teamBijnaam = fileLine[6];
                Speler speler = new Speler(spelerNaam, rugNummer, waarde);
                Team team = new Team(stamNummer, teamNaam, teamBijnaam, trainer);
                int teamIndex = teams.IndexOf(team);
                if (teamIndex != -1)
                {
                    teams[teamIndex].spelers.Add(speler);
                }
                else
                {
                    team.spelers.Add(speler);
                    teams.Add(team);
                }
            }
            Console.WriteLine("Teams loaded");
            return teams;
        }
        #endregion
    }
}
