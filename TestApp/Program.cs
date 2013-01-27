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
            Loader loader1 = new Loader();
            char[] separators = new char[] {' '};

            Dictionary<string,sbyte> wordList = loader1.LoadDictionaryFromTxt("E:/User1/SkyDrive/MyDocs/dev/DesktopWin32/2013/CS_SentimentAnalysisWin32Library/TestData/wordList1.txt", separators);
            Dictionary<string,sbyte> intensifiers = loader1.LoadDictionaryFromTxt("E:/User1/SkyDrive/MyDocs/dev/DesktopWin32/2013/CS_SentimentAnalysisWin32Library/TestData/intensifiers1.txt", separators);
            Dictionary<string,sbyte> inverters = loader1.LoadDictionaryFromTxt("E:/User1/SkyDrive/MyDocs/dev/DesktopWin32/2013/CS_SentimentAnalysisWin32Library/TestData/inverters1.txt", separators);
            string[] inputData = loader1.LoadStringArrayFromTxt("E:/User1/SkyDrive/MyDocs/dev/DesktopWin32/2013/CS_SentimentAnalysisWin32Library/TestData/inputData1.txt");

            Console.WriteLine("Loaded ALL");

            SentimentAnalyser sentimentAnalyser1 = new SentimentAnalyser(wordList, inverters, intensifiers);

            
            Console.WriteLine(sentimentAnalyser1.Analyse(inputData).ToString()); //<---------
            Console.WriteLine("++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("DONE");
            Console.ReadKey();
        
        }
    }
}
