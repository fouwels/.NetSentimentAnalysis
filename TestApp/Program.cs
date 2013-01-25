using System;
using System.Collections.Generic;
using kfouwels.lib.SentimentAnalysis;

//Load wordlist >> Dictionary[]
//Load inverters >> Dictionary[]
//Load intensifiers >> Dictionary[]
//Load inputData>> string[]

//Pass all to sentiment calculator

//Calculate
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRoutine2();
        }
        static void TestRoutine2()
        {
            loader loader1 = new loader();
            char[] separators = new char[] {' '};

            Dictionary<string,sbyte> wordList = loader1.loadDictionaryFromTxt("E:/Dropbox/projects/SentimentAnalysisWin32Library/Data/wordList1.txt", separators);
            Dictionary<string,sbyte> intensifiers = loader1.loadDictionaryFromTxt("E:/Dropbox/projects/SentimentAnalysisWin32Library/Data/intensifiers1.txt", separators);
            Dictionary<string,sbyte> inverters = loader1.loadDictionaryFromTxt("E:/Dropbox/projects/SentimentAnalysisWin32Library/Data/inverters1.txt", separators);
            string[] inputData = loader1.loadStringArrayFromTxt("E:/Dropbox/projects/SentimentAnalysisWin32Library/Data/inputData1.txt");

            Console.WriteLine("Loaded ALL");

            SentimentAnalyser sentimentAnalyser1 = new SentimentAnalyser(wordList, inverters, intensifiers);

            
            Console.WriteLine(sentimentAnalyser1.Analyse(inputData).ToString()); //<---------
            Console.WriteLine("++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("DONE");
            Console.ReadKey();
        
        }
       // static void TestRoutine1()
       // {
       //     SentimentAnalyser SentimentAnalyser1 = new SentimentAnalyser();
       //     loader Loader1 = new loader();

       //     FakeDictionary[] testdictionary1;

       //     char[] separators2 = new char[] { ':', ' ' };

       //     testdictionary1 = Loader1.loadFakeDictionaryFromTxt("H:/Dropbox/projects/SentimentAnalysisWin32Library/Data/wordList1OLDTEST.txt", separators2);

       //     for (int z = 0; z < testdictionary1.Length; z++)
       //     {
       //         Console.Write(testdictionary1[z].key + " >> ");
       //         Console.WriteLine(testdictionary1[z].value);
       //     }
       //     Console.ReadKey();

       //     string[] testArray1;

       //     testArray1 = Loader1.loadStringArrayFromTxt("H:/Dropbox/projects/SentimentAnalysisWin32Library/Data/inputData1.txt");

       //     for (int j = 0; j < testArray1.Length; j++)
       //     {
       //         Console.WriteLine(testArray1[j]);
       //     }
       //     Console.ReadKey();
        
       // }
    }
}
