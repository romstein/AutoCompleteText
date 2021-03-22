using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            HashSet<string> set = new HashSet<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i=0;i<text.Count;i++)
            {
                for (int j=0;j<text[i].Count-2;j++)
                {
                    string s = text[i][j] + " " + text[i][j + 1];
                    if (text[i].Count > 2)
                    {
                        string s1 = text[i][j] + " " + text[i][j + 1] + " " + text[i][j + 2];
                        if (!dict.ContainsKey(s))
                        {
                            dict.Add(s, 1);
                        }
                        else
                        {
                            dict[s]++;
                        }
                        if (!dict.ContainsKey(s1))
                        {
                            dict.Add(s1, 1);
                        }
                        else
                        {
                            dict[s1]++;
                        }
                    }
                }
            }

            return result;
        }
   }
}