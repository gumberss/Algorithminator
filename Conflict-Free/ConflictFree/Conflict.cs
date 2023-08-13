using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictFree
{
    public class Character
    {
        public Character(string key, string val, string? nearCharacterKey)
        {
            Key = key;
            Val = val;
            NearCharacterKey = nearCharacterKey;
        }

        public String Key { get; set; }
        public String Val { get; set; }
        public String? NearCharacterKey { get; set; }
        public bool Deleted { get; set; }

    }

    public class Conflict
    {
        public static List<Character> ProcessDeletion(List<Character> current, Character deleteVal)
        {
            current.Find(x => x.Key == deleteVal.Key).Deleted = true;

            return current;
        }

        public static List<Character> ProcessConflict(List<Character> current, Character newVal)
        {
            var near = current.Find(x => x.Key == newVal.NearCharacterKey);
            var nearIndex = current.FindIndex(x => x.Key == newVal.NearCharacterKey);

            var index = FindCorrectIndex(current, newVal, nearIndex);

            current.Insert(index + 1, newVal);

            return current;
        }

        private static int FindCorrectIndex(List<Character> current, Character newVal, int index)
        {
            if (index + 1 < current.Count)
            {
                var comparisonResult = string.Compare(current[index + 1].Key, newVal.Key, comparisonType: StringComparison.OrdinalIgnoreCase);
                if (comparisonResult > 0 || current[index + 1].Deleted)
                    return FindCorrectIndex(current, newVal, index + 1);
            }

            return index;
        }
    }
}
