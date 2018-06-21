using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob
{
    public class GlobPattern
    {
        private List<string> _list;
        private string[] _pattern;

        public GlobPattern(List<string> list, string pattern)
        {
            _list = list;
            _pattern = pattern.Split('*', '?');
        }

        public List<string> FindList()
        {
            List<string> findedList = null;

            foreach (var str in _list)
            {
                var a = str.StartsWith(_pattern[1]);
            }

            return findedList;
        }
    }
}
