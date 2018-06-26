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
        GlobPattern globPattern = new GlobPattern();

        [TestMethod]
        public void FindList_List_ItemListReturned()
        {
            //arange
            List<string> resList = new List<string>
            {
                "admin.panel.org",
                "admin.google.com",
                "admin.site.ru"
            };
            string pattern = "ad*";

            List<string> resList1 = new List<string>
            {
                "admin.google.com",
                "info.test.com"
            };
            string pattern1 = "*.com";

            //act
            var resFindList = globPattern.FindList(list, pattern);
            var resFindList1 = globPattern.FindList(list, pattern1);


            //assert
            Assert.IsTrue(resList.SequenceEqual(resFindList));
            Assert.IsTrue(resList1.SequenceEqual(resFindList1));
        }

        [TestMethod]
        public void IsMatch_Question_True()
        {
            //arange
            string str = "house";
            string pattern = "?ouse";
            string pattern1 = "ho?se";
            string pattern2 = "hous?";
            string pattern3 = "ho??e";

            //act
            var result = globPattern.IsMatch(str, pattern);
            var result1 = globPattern.IsMatch(str, pattern1);
            var result2 = globPattern.IsMatch(str, pattern2);
            var result3 = globPattern.IsMatch(str, pattern3);

            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void IsMatch_Star_True()
        {
            //arange
            string str = "house";
            string pattern = "h*us*";
            string pattern1 = "*se";
            string pattern2 = "h**se";

            //act
            var result = globPattern.IsMatch(str, pattern);
            var result1 = globPattern.IsMatch(str, pattern1);
            var result2 = globPattern.IsMatch(str, pattern2);

            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void IsMatch_StarQuestion_True()
        {
            //arange
            string str = "house";
            string pattern = "?ou*";
            string pattern1 = "*us?";

            //act
            var result = globPattern.IsMatch(str, pattern);
            var result1 = globPattern.IsMatch(str, pattern1);

            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void IsMatch_BracketsDash_True()
        {
            //arange
            string str = "house";
            string pattern = "[g-i]ouse";
            string pattern1 = "ho[r-w]se";
            string pattern2 = "hous[d-f]";

            //act
            var result = globPattern.IsMatch(str, pattern);
            var result1 = globPattern.IsMatch(str, pattern1);
            var result2 = globPattern.IsMatch(str, pattern2);

            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void IsMatch_Brackets_True()
        {
            //arange
            string str = "house";
            string pattern = "[Hh]ouse";
            string pattern1 = "ho[uS]se";
            string pattern2 = "hous[eG]";

            //act
            var result = globPattern.IsMatch(str, pattern);
            var result1 = globPattern.IsMatch(str, pattern1);
            var result2 = globPattern.IsMatch(str, pattern2);

            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void IsMatch_Compare_True()
        {
            //arange
            string str = "house";
            string pattern = "house";

            //act
            var result = globPattern.IsMatch(str, pattern);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_NotCompare_True()
        {
            //arange
            string str = "house";
            string pattern = "hoseeeeee";

            //act
            var result = globPattern.IsMatch(str, pattern);

            //assert
            Assert.IsFalse(result);
        }

    }
}
