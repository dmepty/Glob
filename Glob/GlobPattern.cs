using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob
{
    public class GlobPattern
    {
        private string _string;
        private List<string> _list;
        private string _pattern;



        public List<string> FindList()
        {
            List<string> findedList = new List<string>();

            foreach (var str in _list)
            {


                    findedList.Add(str);
                



            }

            return findedList;
        }

        public bool IsMatch(string str, string pattern)
        {
            if (str == String.Empty || pattern == String.Empty)
                return true;

            var arrayStr = str.ToCharArray();
            var arrayPat = pattern.ToCharArray();

            string result = "";

            for (int i = 0; i < arrayPat.Length; i++)
            {
                if (arrayPat[i] != '*' && arrayPat[i] != '?')
                {
                    if (arrayPat[i] == arrayStr[i])
                    {
                        result += arrayStr[i];
                        continue;
                    }
                }
                else if (arrayPat[i] == '*')
                {
                    if (arrayPat[i] == arrayPat.Last())
                    {
                        
                    }
                }

            }

            return false;
        }
    }
}
