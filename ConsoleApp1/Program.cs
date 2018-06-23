using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glob;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> list = new List<string>();
            //string pattern = "*";

            //list.Add("admin.panel.org");
            //list.Add("account.domain.tld");
            //list.Add("admin.google.com");
            //list.Add("admin.site.ru");
            //list.Add("info.test.com");
            //list.Add("awdawd");

            GlobPattern globPattern = new GlobPattern();
            globPattern.IsMatch("house", "hous*");
            Console.ReadKey();
        }
    }
}
