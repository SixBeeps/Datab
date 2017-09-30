using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datab;

namespace DatabTesting
{
    class Program
    {
        public static Database database = new Database();
        public static void Main(string[] args)
        {
            database.Init();
            while(database == null)
            {
                GC.Collect();
            }
            database.SetLabel(5, "Username");
            database.SetLabel(6, "Password");
            OutputAllContent();
            database.NewEntry(new List<string> { "niorg2606", "password123" });
            database.NewEntry(new List<string> { "SixBeeps", "anotherPassword321" });
            OutputAllContent();
        }

        static void OutputAllContent()
        {
            foreach(List<string> secondaryList in database.GetAllContent())
            {
                foreach(string s in secondaryList)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
