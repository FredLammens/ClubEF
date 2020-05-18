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
            //lib.InitialiseerDatabank(@"C:\Users\Biebem\Google Drive\School\hbO5\Semester2\hbo5_Programmeren4\5.Entity framework\foot.csv");
            Speler testSpeler = new Speler("Johnathany David", 16, 20000000);
            Team testTeam = new Team(16, "testTeam", "tt", "Trainer John");
            Transfer testTransfer;
            lib.VoegSpelerToe(testSpeler);

            Console.WriteLine(lib.SelecteerSpeler(10).SpelerNaam);
        }
    }
}
