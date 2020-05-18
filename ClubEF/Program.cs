using ClubEFLibrary;
using System;

namespace ClubEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            lib.InitialiseerDatabank(@"C:\Users\Biebem\Google Drive\School\hbO5\Semester2\hbo5_Programmeren4\5.Entity framework\foot.csv");
        }
    }
}
