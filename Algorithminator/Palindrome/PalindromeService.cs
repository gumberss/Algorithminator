using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithminator.Palindrome
{
    public class PalindromeService
    {
        //O(n)
        public bool Palindrome(string text)
        {
            int middle = text.Length / 2;

            for (int i = 0; i < middle; i++)
            {
                if (text[i] != text[text.Length - 1 - i]) return false;
            }

            return true;
        }
    }
}
