#Sentiment Analysis Libary
####Win32 Libary

Runs language processing on string input to determine a score based on key combinations of words and rudimentary phrases

The algorithm runs through the statement until it encounters a word relating to sentiment, this is then compared with the surrounding words to determine the context, and calculate how much it should influence the overall sentiment "score"

- Hitting a marked word, such as __"good"__, in a statement would add it's assigned value to the counter
- However in the context of __"very good"__, this value would be increased due to being prefixed by __"very"__ - a marked intensifier. 
- Likewise, if it were to encounter __"not very good"__, the value would be negative, due to being in the context of __"not"__ - a marked inverter.

This allows for rudimentary phrases to be interpreted, rather than simply looking for key words.

See /bin/ for built .DLL binarys

Example Usage
```csharp
using kfouwels.lib.SentimentAnalysis;

static void TestRoutine()
{
    char[] separators = {' '};

    Dictionary<string,sbyte> wordList = Loaders.LoadDictionaryFromTxt("wordList1.txt", separators);
    Dictionary<string,sbyte> intensifiers = Loaders.LoadDictionaryFromTxt("intensifiers1.txt", separators);
    Dictionary<string,sbyte> inverters = Loaders.LoadDictionaryFromTxt("inverters1.txt", separators);

    var sentimentAnalyser1 = new SentimentAnalyser(wordList, inverters, intensifiers, true);

    string[] inputData = Loaders.LoadStringArrayFromTxt("inputData1.txt");

    var result = sentimentAnalyser1.Analyse(inputData).ToString());        
}
```

#####Kaelan Fouwels 2012

######This was initially hacked together for use with a hackday project - code is still a little hacky.
