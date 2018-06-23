using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Glob.Tests
{
    [TestClass]
    public class GlobTest
    {
        List<string> list = new List<string>
        {
            "admin.panel.org",
            "account.domain.tld",
            "admin.google.com",
            "admin.site.ru",
            "info.test.com",
            "awdawd"
        };

        [TestMethod]
        public void FindList_List_ItemListReturned()
        {
            //arange
            List<string> resList = new List<string>();
            string pattern = "ad*";

            resList.Add("admin.panel.org");
            resList.Add("admin.google.com");
            resList.Add("admin.site.ru");

            //act
            GlobPattern globPattern = new GlobPattern();
            var resFindList = globPattern.FindList();


            //assert
            Assert.IsTrue(resList.SequenceEqual(resFindList));
        }

        [TestMethod]
        public void IsMatch_String_True()
        {
            //arange
            string str = "house";
            string pattern = "ho*";

            //act
            GlobPattern globPattern = new GlobPattern();
            var result = globPattern.IsMatch(str, pattern);

            //assert
            Assert.IsTrue(result);
        }
    }
}
