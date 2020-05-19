using ClubEFLibrary;
using libraryClubEF;
using System;

namespace ClubEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }
        private static void Test()
        {
            Library lib = new Library();
            #region initialiseerDB
            //lib.InitialiseerDatabank(@"C:\Users\Biebem\Google Drive\School\hbO5\Semester2\hbo5_Programmeren4\5.Entity framework\foot.csv");
            #endregion
            #region AddObjectsDB
            /*Speler testSpeler = new Speler("Johnathany David", 16, 20000000);
            lib.VoegSpelerToe(testSpeler);
            Team testTeamOud = new Team(16, "testTeamOud", "ttO", "Trainer John");
            lib.VoegTeamToe(testTeamOud);
            Team testTeamNieuw = new Team(25, "testTeamNieuw", "ttN", "Trainer Cena");
            lib.VoegTeamToe(testTeamNieuw);
            Transfer testTransfer = new Transfer(1000000.50m, testSpeler, testTeamOud, testTeamNieuw);
            lib.VoegTransferToe(testTransfer);*/
            #endregion
            #region updateDB
            /*Speler testUpdateSpeler = new Speler("UpdatedSpelernaam", 14, 1);
            testUpdateSpeler.SpelerId = 4;
            lib.UpdateSpeler(testUpdateSpeler);
            Team testUpdateTeamOud = new Team(16, "UpdatedTeam", "utO", "Trainer John");
            lib.UpdateTeam(testUpdateTeamOud);*/
            //extra test
            /*Speler testUpdateSpeler = new Speler("UpdatedSpelernaam", 14, 1);
            Team testUpdateTeamOud = new Team(16, "UpdatedTeam", "utO", "Trainer John");
            testUpdateTeamOud.spelers.Add(testUpdateSpeler);
            lib.UpdateTeam(testUpdateTeamOud);*/
            #endregion
            #region SelectionDB
            Console.WriteLine("Selecteer speler 3");
            Console.WriteLine(lib.SelecteerSpeler(3));
            Console.WriteLine("Selecteer team 3");
            Console.WriteLine(lib.SelecteerTeam(3));
            Console.WriteLine("Selecteer transfer 1");
            Console.WriteLine(lib.SelecteerTransfer(1));
            #endregion
        }
    }
}
