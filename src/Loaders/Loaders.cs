using System;
using System.Collections.Generic;
using System.IO;

namespace kfouwels.lib.Loaders
{
    public static class Loaders
    {
        //Load Dictionary from txt
        //Load Dictionary from txt with separators
        //Load String from txt
        //Load String arra from txt
        //Load String arra from txt with separators

        public static Dictionary<string, sbyte> LoadDictionaryFromTxt(string pathToFile)
        {
            var loadedWordList = new Dictionary<string, sbyte>();
            char[] separatorChars = new char[] { ' ', '\r', '\n' };     //BROKEN? - CHECK THIS FIRST! 

            if (File.Exists(pathToFile))
            {
                var sr = new StreamReader(pathToFile);

                string justReadInLine;

                while (sr.Peek() != '~')
                {
                    justReadInLine = sr.ReadLine().ToLower();
                    if (justReadInLine != "") { loadedWordList.Add(justReadInLine.Split(separatorChars)[0], Convert.ToSByte(justReadInLine.Split(separatorChars)[1])); }
                }


                sr.Close();
            }

            return loadedWordList;
        }
        public static Dictionary<string, sbyte> LoadDictionaryFromTxt(string pathToFile, char[] separatorChars)
        {
            var loadedWordList = new Dictionary<string, sbyte>();

            if (File.Exists(pathToFile))
            {
                var sr = new StreamReader(pathToFile);

                string justReadInLine;

                while (sr.Peek() != '~')
                {
                    justReadInLine = sr.ReadLine().ToLower();
                    if (justReadInLine != "") { loadedWordList.Add(justReadInLine.Split(separatorChars)[0], Convert.ToSByte(justReadInLine.Split(separatorChars)[1])); }
                }


                sr.Close();
            }

            return loadedWordList;
            
        }
        public static String LoadStringFromTxt(string pathToFile)
        {
            string tempstring = null;
            if (File.Exists(pathToFile))
            {
                var sr2 = new StreamReader(pathToFile);
                tempstring = sr2.ReadToEnd().ToLower();
                sr2.Close();
            }
            return tempstring;            
        }

        public static String[] LoadStringArrayFromTxt(string pathToFile)
        {
            string[] tempString = null;
            if (File.Exists(pathToFile))
            {
                var sr2 = new StreamReader(pathToFile);
                char[] separators = new char[] {' ', '\r', '\n'};
                tempString = sr2.ReadToEnd().ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                sr2.Close();
            }
            return tempString;
        }
        public static String[] LoadStringArrayFromTxt(string pathToFile, char[] separatorChars)
        {
            string[] tempString = null;
            if (File.Exists(pathToFile))
            {
                var sr2 = new StreamReader(pathToFile);
                tempString = sr2.ReadToEnd().ToLower().Split(separatorChars);
                sr2.Close();
            }
            return tempString;
        }
    }
}
