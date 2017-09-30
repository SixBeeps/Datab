using System;
using System.Collections;
using System.Collections.Generic;
namespace Datab
{ //T h i s n a m e s p a c e c a n n o t b e r u n i n c o m p i l e r m o d e
    public class Database
    {
        private List<string> Labels;
        private List<List<string>> Contents;
        public void Init()
        {
            //Initialize the contents table
            Contents = new List<List<string>> { };
            Labels = new List<string> { };
            
        }
        public void SetLabel(int at, string name)
        {
            if (at > Labels.Count)
            {
                for (int i = Labels.Count; i < at; i++)
                {
                    Labels.Add("");
                }
                Labels.Add(name);
            }
            else
            {
                Labels.Insert(at, name);
            }
        }
        public string GetLabel(int at)
        {
            return Labels[at];
        }
        public int GetLabelID(string name)
        {
            int temp = 0;
            foreach (string s in Labels)
            {
                if (s == name)
                {
                    return temp;
                }
                else
                {
                    temp++;
                }
            }
            return 0;
        }
        public string GetContent(int labelID, int entry)
        {
            return Contents[labelID][entry];
        }
        public string GetContent(string label, int entry)
        {
            return Contents[GetLabelID(label)][entry];
        }
        public void NewEntry(List<string> content)
        {
            Contents.Add(content);
        }
        public List<List<string>> GetAllContent()
        {
            return Contents;
        }
    }
}
