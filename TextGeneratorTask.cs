using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            
            StringBuilder result = new StringBuilder();
            result.Append(phraseBeginning);
            result.Append(' ');
            if (nextWords.Count == 0)
            {
                return phraseBeginning;
            }
            while (wordsCount > 0)
            {
                StringBuilder cur = new StringBuilder();
                string[] spl = phraseBeginning.Split(' ');

                if (spl.Length > 1)
                {
                    cur.Append(spl[spl.Length - 1]);
                    cur.Append(' ');
                    cur.Append(spl[spl.Length - 2]);
                    if (nextWords.ContainsKey(cur.ToString()))
                    {
                        result.Append(nextWords[phraseBeginning]);
                        result.Append(' ');
                        cur = null;
                        cur.Append(spl[spl.Length - 1]);
                        cur.Append(' ');
                        cur.Append(nextWords[phraseBeginning]);
                        phraseBeginning = cur.ToString();
                        wordsCount--;
                    }
                    else
                    {
                        cur = null;
                        cur.Append(spl[spl.Length - 1]);
                        if (nextWords.ContainsKey(cur.ToString()))
                        {
                            result.Append(nextWords[phraseBeginning]);
                            result.Append(' ');
                            cur = null;
                            cur.Append(spl[spl.Length - 1]);
                            cur.Append(' ');
                            cur.Append(nextWords[phraseBeginning]);
                            phraseBeginning = cur.ToString();
                            wordsCount--;
                        }
                        else
                        {
                            //нет продолжения;
                            break;
                        }
                    }
                }
                else if (spl.Length == 1)
                {
                    cur.Append(phraseBeginning);
                    if (nextWords.ContainsKey(cur.ToString()))
                    {
                        result.Append(nextWords[phraseBeginning]);
                        result.Append(' ');
                        cur = null;
                        cur.Append(phraseBeginning);
                        cur.Append(' ');
                        cur.Append(nextWords[phraseBeginning]);
                        phraseBeginning = cur.ToString();
                        wordsCount--;
                    }
                    else
                    {
                        //нет продолжения;
                        break;
                    }
                }
            }
            phraseBeginning = result.ToString();
            phraseBeginning=phraseBeginning.Remove(phraseBeginning.Length - 1, 1);
            return phraseBeginning;
        }
    }
}