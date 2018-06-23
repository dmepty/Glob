using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Glob
{
    public class GlobPattern
    {
        //public List<string> FindList()
        //{
        //    List<string> findedList = new List<string>();

        //    foreach (var str in _list)
        //    {


        //            findedList.Add(str);
                



        //    }

        //    return findedList;
        //}

        public bool IsMatch(string str, string pattern)
        {
            int i = 0, k = 0;

            //if string and pattern empty
            if (str == String.Empty && pattern == String.Empty)
                return true;

            //if string empty or null and pattern is *
            if (pattern == "*" && !string.IsNullOrEmpty(str))
                return true;

            //if string is 1 symbol and pattern is ?
            if (pattern == "?" && str.Length == 1)
                return true;

            //if string and pattern are equal
            if (String.Compare(str, pattern, true) == 0)
                return true;

            while(i != pattern.Length)
            {
                switch (pattern[i])
                {
                    case '?': break;
                    case '*':
                        if (pattern.Length == ++i)
                            return true;

                        while(k != pattern.Length)
                        {
                            if (IsMatch(str.Substring(k+1), pattern.Substring(i+1)))
                                return true;

                            k++;
                        }

                        return false;

                    default:
                        if (pattern[i] != str[k])
                            return false;

                        break;
                }

                i++;
                k++;
            }

            if (k == pattern.Length)
            {
                if (i == pattern.Length || pattern[i] == '*')
                    return true;
            }


                #region MyRegion
                //if (arrayPat[i] != '*' && arrayPat[i] != '?')
                //{
                //    if (arrayPat[i] == arrayStr[i])
                //    {
                //        result += arrayStr[i];
                //        continue;
                //    }
                //}
                //else if (arrayPat[i] == '*')
                //{
                //    if (arrayPat[i] == arrayPat.Last() && result != null)
                //        return str.StartsWith(result);
                //    if (arrayPat[i] == arrayPat.Last() && result == null)
                //        return true;


                //}
                #endregion

            return false;
        }
    }
}
