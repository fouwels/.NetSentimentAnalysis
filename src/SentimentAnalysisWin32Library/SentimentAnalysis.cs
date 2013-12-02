using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace kfouwels.lib.SentimentAnalysis
{
    public class SentimentAnalyser
    {
		private readonly Dictionary<string, sbyte> _wordlist;
		private readonly Dictionary<string, sbyte> _inverters;
        private readonly Dictionary<string, sbyte> _intensifiers;
	    private readonly bool _verbose;
		//Local Copies

		/// <summary>
		/// Main function - Analyses the input string array. load it up with lists using the Loaders helper class, then call .Analyse
		/// </summary>
		/// <param name="wordlistIn">The dictionary of sentiment-words to compare string array to, use the relavent Loader</param>
		/// <param name="invertersIn">The registered inverters, use the relavent Loader</param>
		/// <param name="intensifiersIn">The registered intensifiers, use the relavent Loader</param>
		/// <param name="verbose">Boolean flag to enable verbose, debug output</param>
        public SentimentAnalyser(Dictionary<string, sbyte> wordlistIn, Dictionary<string, sbyte> invertersIn, Dictionary<string, sbyte> intensifiersIn, bool verbose)
        {
            _wordlist = wordlistIn;
            _inverters = invertersIn;
            _intensifiers = intensifiersIn;
			_verbose = verbose;
        }

        public double Analyse(string[] words)
        {
            double sentimentValue = 0; //Master value of awesomeness
	        Int64 wordsFound = 0;
	        float v; //Temp value for calculations
            float w; //Temp value for calculations

            for (Int64 wordCycler = 0; wordCycler < words.Length; wordCycler++) //Cycle word
            {
	            if (_verbose)
	            {
		            Debug.WriteLine("processing {0}", words[wordCycler]);
	            }

	            if (_wordlist.ContainsKey(words[wordCycler]))
                {
                    wordsFound++;
                    if (_inverters.ContainsKey(words[wordCycler - 1]))
                    {
                        if (_intensifiers.ContainsKey(words[wordCycler - 2]))
                        {
                            //intensifiers - inverters - word
                            w = _wordlist[words[wordCycler]];
                            v = _intensifiers[words[wordCycler - 2]];

                            sentimentValue += ((w + (w*v/100))*-1);
                        }
                        else
                        {
                            //inverters - word
                            sentimentValue += (_wordlist[words[wordCycler]]*-1); // -1 inverts
                        }
                    }
                    else
                    {
                        if (_intensifiers.ContainsKey(words[wordCycler - 1]))
                        {
                            if (_inverters.ContainsKey(words[wordCycler - 2]))
                            {
                                //inverters - intensifiers - word

                                w = _wordlist[words[wordCycler]];
                                v = _intensifiers[words[wordCycler - 1]];

                                sentimentValue += ((w + (w*v/100))*-1);
                            }
                            else
                            {
                                // intensifiers - word
                                //+= (w + (w * v /100))

                                w = _wordlist[words[wordCycler]];
                                v = _intensifiers[words[wordCycler - 1]];

                                sentimentValue += (w + (w*v/100));
                            }
                        }
                        else
                        {
                            //word
                            sentimentValue += _wordlist[words[wordCycler]];
                        }
                    }
                }
            } // end For

			return (sentimentValue / (wordsFound == 0 ? 1 : wordsFound));
        }
    }
}