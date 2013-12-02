using System;
using System.Collections.Generic;
using System.Diagnostics;
using kfouwels.lib.Loaders;
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
			var writer = new TextWriterTraceListener(System.Console.Out); //Patch debug output into the console
			Debug.Listeners.Add(writer);

            TestRoutine2();
        }
        static void TestRoutine2()
        {
            char[] separators = {' '};

            Dictionary<string,sbyte> wordList = Loaders.LoadDictionaryFromTxt("wordList1.txt", separators);
            Dictionary<string,sbyte> intensifiers = Loaders.LoadDictionaryFromTxt("intensifiers1.txt", separators);
            Dictionary<string,sbyte> inverters = Loaders.LoadDictionaryFromTxt("inverters1.txt", separators);
            string[] inputData = Loaders.LoadStringArrayFromTxt("inputData2.txt");

            Console.WriteLine("Loaded ALL");

	        var sentimentAnalyser1 = new SentimentAnalyser(wordList, inverters, intensifiers, true);

            Console.WriteLine("\n>>" + sentimentAnalyser1.Analyse(inputData).ToString() + "%"); //<---------
            Console.ReadKey();
        }

	    static void twitter(string hashtag, string handle)
	    {
		    

	    }
    }
}
