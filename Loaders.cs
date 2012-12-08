using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace kfouwels.lib.SentimentAnalysis
{
    public class loader
    {
        public Dictionary<string,sbyte> loadDictionaryFromTxt(string pathToWordListFile)
        {
            StreamReader sr = new StreamReader(pathToWordListFile);

            char[] SeparatorChars = new char[] {' ', '\r', '\n'};     //BROKEN? - CHECK THIS FIRST!                
            string justReadInLine = null;
            int lengthOfFile = Convert.ToInt32(sr.ReadLine());

            Dictionary<string, sbyte> loadedWordList = new Dictionary<string, sbyte>();

            while (sr.Peek() != '~')
            {
                justReadInLine = sr.ReadLine().ToLower();
                loadedWordList.Add(justReadInLine.Split(SeparatorChars)[0].ToString(), Convert.ToSByte(justReadInLine.Split(SeparatorChars)[1].ToString()));
            }

            sr.Close();
            return loadedWordList;        
        }
        public Dictionary<string, sbyte> loadDictionaryFromTxt(string pathToWordListFile, char[] separatorChars)
        {
            StreamReader sr = new StreamReader(pathToWordListFile);
       
            string justReadInLine = null;
            int lengthOfFile = Convert.ToInt32(sr.ReadLine());

            Dictionary<string, sbyte> loadedWordList = new Dictionary<string, sbyte>();

            while (sr.Peek() != '~')
            {
                justReadInLine = sr.ReadLine().ToLower();
                loadedWordList.Add(justReadInLine.Split(separatorChars)[0].ToString(), Convert.ToSByte(justReadInLine.Split(separatorChars)[1]));
            }

            sr.Close();
            return loadedWordList;
        }
        public String loadStringFromTxt(string pathToWordListFile)
        {
            StreamReader sr2 = new StreamReader(pathToWordListFile);
            string tempstring2 = sr2.ReadToEnd().ToLower();
            sr2.Close();

            return tempstring2;            
        }
        public String[] loadStringArrayFromTxt(string pathToWordListFile)
        {
            StreamReader sr2 = new StreamReader(pathToWordListFile);
            char[] separators = new char[] {' ', '\r', '\n'};
            string tempString = sr2.ReadToEnd().ToLower();

            return tempString.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        }
        public String[] loadStringArrayFromTxt(string pathToWordListFile, char[] separatorChars)
        {
            StreamReader sr2 = new StreamReader(pathToWordListFile);
            string tempString = sr2.ReadToEnd().ToLower();

            return tempString.Split(separatorChars);
        }
    }
}
