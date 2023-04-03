using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.DecodeString
{
    public class DecodeString1
    {
        public string Decode(string coded)
        {
            return Recursive(coded, 0, 0).decoded;
        }

        private (string decoded, int position) Recursive(string coded, int startPosition, int depth)
        {
            String result = "";
             
            for (int i = startPosition; i < coded.Length; i++)
            {
                if (char.IsDigit(coded[i]))
                {
                    int index = 0;

                    for (int j = 0; j < coded[i] - '0'; j++)
                    {
                        (string decoded, int idx) = Recursive(coded, (i + 1), depth + 1);
                        result += decoded;
                        index = idx;

                    }

                    i += index;
                }
                else if (coded[i] == ']' && depth != 0)
                {
                    return (result, i);
                }
                else if (coded[i] != '[' && coded[i] != ']')
                {
                    result += coded[i];
                }
            }

            return (result, coded.Length);
        }

        //private (string decoded, int position) Recursive(string coded, int depth)
        //{
        //    String result = "";

        //    for (int i = 0; i < coded.Length; i++)
        //    {
        //        if (char.IsDigit(coded[i]))
        //        {
        //            var next = coded[(i + 1)..];
        //            int index = 0;

        //            for (int j = 0; j < coded[i] - '0'; j++)
        //            {
        //                (string decoded, int idx) = Recursive(next, depth + 1);
        //                result += decoded;
        //                index = idx;

        //            }

        //            i += index;
        //        }
        //        else if (coded[i] == ']' && depth != 0)
        //        {
        //            return (result, i);
        //        }
        //        else if (coded[i] == '[' || coded[i] == ']')
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            result += coded[i];
        //        }
        //    }

        //    return (result, coded.Length);
        //}
    }
}
