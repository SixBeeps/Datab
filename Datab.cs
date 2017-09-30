namespace Datab { //T h i s n a m e s p a c e c a n n o t b e r u n i n c o m p i l e r m o d e
  public static class Database {
    private static List<string> Labels;
    private static List<List<string>> Contents;
    public static void Init() {
      //Initialize the contents table
      Contents = new List<List<string>>();
    }
    public static void SetLabel(int at, string name) {
      Labels[at] = name;
    }
    public static string GetLabel(int at) {
      return Labels[at];
    }
    public static int GetLabelID(string name) {
      int temp = 0;
      foreach (string s in Labels) {
        if (s == name) {
          return temp;
        } else {
          temp++;
        }
      }
      return 0;
    }
    public static string GetContent(int labelID, int entry) {
      return Contents[labelID][entry];
    }
    public static string GetContent(string label, int entry) {
      return Contents[GetLabelID(label)][entry];
    }
    public static void NewEntry(List<string> content) {
      Contents.Insert(Contents.Count-1, content);
    }
    public static List<List<string>> GetAllContent() {
      return Contents;
    }
  }
}
