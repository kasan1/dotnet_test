using System.Collections.Generic;

namespace Agro.Shared.Logic.Extensions
{
    public static class StringExtensions
    {
        private static readonly Dictionary<char, string> _cyrillic = new Dictionary<char, string>
        {
            ['а'] = "a",
            ['б'] = "b",
            ['в'] = "v",
            ['г'] = "g",
            ['д'] = "d",
            ['е'] = "e",
            ['ё'] = "yo",
            ['ж'] = "zh",
            ['з'] = "z",
            ['и'] = "i",
            ['й'] = "y",
            ['к'] = "k",
            ['л'] = "l",
            ['м'] = "m",
            ['н'] = "n",
            ['о'] = "o",
            ['п'] = "p",
            ['р'] = "r",
            ['с'] = "s",
            ['т'] = "t",
            ['у'] = "u",
            ['ф'] = "f",
            ['х'] = "kh",
            ['ц'] = "ts",
            ['ч'] = "ch",
            ['ш'] = "sh",
            ['щ'] = "shch",
            ['ы'] = "y",
            ['ъ'] = "",
            ['ь'] = "",
            ['э'] = "e",
            ['ю'] = "yu",
            ['я'] = "ya",
            
            ['ә'] = "a",
            ['ғ'] = "g",
            ['қ'] = "q",
            ['ң'] = "n",
            ['ө'] = "o",
            ['ұ'] = "u",
            ['ү'] = "y",
            ['һ'] = "h",
            ['і'] = "i",


            ['А'] = "A",
            ['Б'] = "B",
            ['В'] = "V",
            ['Г'] = "G",
            ['Д'] = "D",
            ['Е'] = "E",
            ['Ё'] = "Yo",
            ['Ж'] = "Zh",
            ['З'] = "Z",
            ['И'] = "I",
            ['Й'] = "Y",
            ['К'] = "K",
            ['Л'] = "L",
            ['М'] = "M",
            ['Н'] = "N",
            ['О'] = "O",
            ['П'] = "P",
            ['Р'] = "R",
            ['С'] = "S",
            ['Т'] = "T",
            ['У'] = "U",
            ['Ф'] = "F",
            ['Х'] = "Kh",
            ['Ц'] = "Ts",
            ['Ч'] = "Ch",
            ['Ш'] = "Sh",
            ['Щ'] = "Shch",
            ['Ы'] = "Y",
            ['Ъ'] = "",
            ['Ь'] = "",
            ['Э'] = "E",
            ['Ю'] = "Yu",
            ['Я'] = "Ya",

            ['Ә'] = "A",
            ['Ғ'] = "G",
            ['Қ'] = "Q",
            ['Ң'] = "N",
            ['Ө'] = "O",
            ['Ұ'] = "U",
            ['Ү'] = "Y",
            ['Һ'] = "H",
            ['І'] = "I"
        };

        private static readonly Dictionary<char, string> _latin = new Dictionary<char, string>
        {
            ['a'] = "а",
            ['b'] = "б",
            ['c'] = "с",
            ['d'] = "д",
            ['e'] = "е",
            ['f'] = "ф",
            ['g'] = "г",
            ['h'] = "х",
            ['i'] = "и",
            ['j'] = "ж",
            ['k'] = "к",
            ['l'] = "л",
            ['m'] = "м",
            ['n'] = "н",
            ['o'] = "о",
            ['p'] = "п",
            ['q'] = "қ",
            ['r'] = "р",
            ['s'] = "с",
            ['t'] = "т",
            ['u'] = "у",
            ['v'] = "в",
            ['w'] = "в",
            ['x'] = "х",
            ['y'] = "ы",
            ['z'] = "з",

            ['A'] = "А",
            ['B'] = "Б",
            ['C'] = "С",
            ['D'] = "Д",
            ['E'] = "Е",
            ['F'] = "Ф",
            ['G'] = "Г",
            ['H'] = "Х",
            ['I'] = "И",
            ['J'] = "Ж",
            ['K'] = "К",
            ['L'] = "Л",
            ['M'] = "М",
            ['N'] = "Н",
            ['O'] = "О",
            ['P'] = "П",
            ['Q'] = "Қ",
            ['R'] = "Р",
            ['S'] = "С",
            ['T'] = "Т",
            ['U'] = "У",
            ['V'] = "В",
            ['W'] = "В",
            ['X'] = "Х",
            ['Y'] = "Ы",
            ['Z'] = "З"
        };

        public static string ToCyrillic(this string str)
        {
            var newStr = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                newStr += _latin.ContainsKey(str[i]) ? _latin[str[i]] : str[i].ToString();
            }

            return newStr;
        }

        public static string ToLatin(this string str)
        {
            var newStr = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                newStr += _cyrillic.ContainsKey(str[i]) ? _cyrillic[str[i]] : str[i].ToString();
            }

            return newStr;
        }
    }
}
