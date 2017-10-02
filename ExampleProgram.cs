using System.Text;
using System.Threading.Tasks;
using Datab;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace DatabTesting
{
    class Program
    {
        enum Examples { Basic, Excel };
        static Examples whichExample = Examples.Excel; //Change the value to one of the words given between the {}s
        public static void Main(string[] args)
        {
            switch (whichExample)
            {
                case Examples.Basic:
                    BasicExample.EMain(args);
                    break;
                case Examples.Excel:
                    DatabWithExcel.EMain(args);
                    break;
            }
        }
    }

    class BasicExample
    {
        public static Database database = new Database();
        public static void EMain(string[] args)
        {
            database.Init();
            while (database == null)
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
            foreach (List<string> secondaryList in database.GetAllContent())
            {
                foreach (string s in secondaryList)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }

    class DatabWithExcel
    {
        public static Database database = new Database();
        public static void EMain(string[] args)
        {
            database.Init();
            while (database == null)
            {
                GC.Collect();
            }
            database.SetLabel(0, "Username");
            database.SetLabel(1, "Password");
            database.NewEntry(new List<string> { "niorg2606", "password123" });
            database.NewEntry(new List<string> { "SixBeeps", "anotherPassword321" });
            database.NewEntry(new List<string> { "JohnDoe", "JaneIsMyLover" });
            database.NewEntry(new List<string> { "IHeartUnicode", "│ ♥ ṳṆỉכּ∆₯∑" }); //This user made to show off unicode support
            GenerateFromExcel(database);
        }

        public static void GenerateFromExcel(Database db)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            //Excel.Range oRng;

            Console.WriteLine("Starting Excel...");
            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                for (int i = 0; i < db.GetLabels().Count; i++)
                {
                    oSheet.Cells[1, i + 1] = db.GetLabels()[i];
                }
                oSheet.get_Range("A1", "ZZ1").Font.Bold = true;
                oSheet.get_Range("A1", "ZZ1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "ZZ1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                for (int y = 0; y < db.GetAllContent().Count; y++)
                {
                    for (int x = 0; x < db.GetAllContent()[y].Count; x++)
                    {
                        oSheet.Cells[y+2, x+1] = db.GetAllContent()[y][x];
                    }
                }
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: ");
                Console.Write(e);
            }
        }
    }
}
