using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.LongestSubstring
{
    public class WithoutRepeatingCharacters
    {

        public string From(string text)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            Dictionary<char, int> dic2 = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dic.ContainsKey(text[i]))
                    dic.Add(text[i], i);
                else
                {
                    if (dic2.Count < dic.Count)
                    {
                        dic2 = new Dictionary<char, int>(dic);
                    }

                    dic.Clear();
                }
            }

            return new string(dic2.OrderBy(x => x.Value).Select(x => x.Key).ToArray());
        }

        //public string From(string text)
        //{
        //    Dictionary<char, int> dic = new Dictionary<char, int>();
        //    Dictionary<char, int> dic2 = new Dictionary<char, int>();

        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (!dic.ContainsKey(text[i]))
        //            dic.Add(text[i], i);
        //        else
        //        {
        //            if (dic2.Count < dic.Count)
        //            {
        //                dic2 = new Dictionary<char, int>(dic);
        //            }

        //            dic.Clear();
        //        }
        //    }

        //    return new string(dic2.OrderBy(x => x.Value).Select(x => x.Key).ToArray());
        //}
    }
}
