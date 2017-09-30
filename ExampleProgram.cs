using System;
using System.Collections.Generic;
using System.Collections;
using Datab;

namespace Code {
  public static class DatabExample {
    public static Datab.Database database;
    public static void Main(String[] args) {
      database.Init();
      foreach (List<string> secondaryList in database.GetAllContent()) {
        foreach (string s in secondaryList) {
          Console.WriteLine(s);
        }
      }
      database.SetLabel(0,"Username");
      database.SetLabel(1,"Password");
      database.NewEntry(new List<string> {"niorg2606", "password"});
      foreach (List<string> secondaryList in database.GetAllContent()) {
        foreach (string s in secondaryList) {
          Console.WriteLine(s);
        }
      }
    }
  }
}
