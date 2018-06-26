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
        public List<string> FindList(List<string> list, string pattern)
        {
            List<string> findedList = new List<string>();

            foreach (var str in list)
            {
                if (IsMatch(str, pattern))
                    findedList.Add(str);
            }

            return findedList;
        }

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

            try
            {
                while (i != str.Length)
                {
                    switch (pattern[i])
                    {
                        case '?': break;
                        case '*':
                            if (pattern.Length == i + 1)
                                return true;

                            while (k != str.Length)
                            {
                                if (IsMatch(str.Substring(k + 1), pattern.Substring(i + 1)))
                                    return true;

                                k++;
                            }

                            return false;

                        case '[':
                            if (pattern[i + 2] == '-')
                            {
                                var pat = pattern.Substring(i + 1, 3).Replace("-", "");

                                for (var j = pat[0]; j <= pat[1]; j++)
                                {
                                    if (j == str[k])
                                        return true;
                                }
                            }
                            else
                            {
                                var pat = pattern.Substring(i + 1, pattern.IndexOf("]") - (i + 1));

                                for (var j = 0; j < pat.Length; j++)
                                {
                                    if (pat[j] == str[k])
                                        return true;
                                }
                            }

                            break;

                        default:
                            if (pattern[i] != str[k])
                                return false;

                            break;
                    }

                    i++;
                    k++;
                }

                if (k == str.Length)
                {
                    if (i == pattern.Length || pattern[i] == '*')
                        return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;
        }
    }
}
