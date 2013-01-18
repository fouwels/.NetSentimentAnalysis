using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace kfouwels.lib.SentimentAnalysis
{
    public class SentimentAnalyser
    {
        Dictionary<string, sbyte> wordlist;
        Dictionary<string, sbyte> inverters;
        Dictionary<string, sbyte> intensifiers;

        public SentimentAnalyser(Dictionary<string, sbyte> wordlistIn, Dictionary<string, sbyte> invertersIn, Dictionary<string, sbyte> intensifiersIn)
        {
            wordlist = wordlistIn; 
            inverters = invertersIn;
            intensifiers = intensifiersIn;
        }
        public decimal Analyse(string[] word)
        {
            decimal SentimentValue = 0; //Master value of awesomeness
            decimal wordsFound = 0;
            decimal v = 0;              //Temp value for calculations
            decimal w = 0;              //Temp value for calculations
            
            for (int wordCycler = 0; wordCycler < word.Length; wordCycler++) //Cycle word
            {
                Console.WriteLine("processing {0}", word[wordCycler]);
                if (wordlist.ContainsKey(word[wordCycler]) == true)
                {
                    wordsFound++;
                    if (inverters.ContainsKey(word[wordCycler - 1]) == true)
                    {
                        if (intensifiers.ContainsKey(word[wordCycler - 2]) == true)
                        {
                            //intensifiers - inverters - word
                            w = wordlist[word[wordCycler]];
                            v = intensifiers[word[wordCycler]];

                            SentimentValue += ((w + (w * v / 100)) * -1);
                        }
                        else
                        {
                            //inverters - word
                            SentimentValue += (wordlist[word[wordCycler]] * -1); // -1 inverts
                        }
                    
                    }
                    else
                    {
                        if (intensifiers.ContainsKey(word[wordCycler - 1]) == true)
                        {
                            if (inverters.ContainsKey(word[wordCycler - 2]) == true)
                            {
                                //inverters - intensifiers - word

                                w = wordlist[word[wordCycler]];
                                v = intensifiers[word[wordCycler]];

                                SentimentValue += ((w + (w * v / 100)) * -1);
                            }
                            else
                            {
                                // intensifiers - word
                                //+= (w + (w * v /100))

                                w = wordlist[word[wordCycler]];
                                v = intensifiers[word[wordCycler]];

                                SentimentValue += (w + (w * v / 100));                                
                            }
                        }
                        else
                        {
                            //word
                            SentimentValue += wordlist[word[wordCycler]];
                        }
                    }
                }
            } // end For

            return (SentimentValue / wordsFound);
        }
    }
}
