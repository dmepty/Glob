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

        //[TestMethod]
        //public void FindList_List_ItemListReturned()
        //{
        //    //arange
        //    List<string> resList = new List<string>();
        //    string pattern = "ad*";

        //    resList.Add("admin.panel.org");
        //    resList.Add("admin.google.com");
        //    resList.Add("admin.site.ru");

        //    //act
        //    GlobPattern globPattern = new GlobPattern();
        //    var resFindList = globPattern.FindList();


        //    //assert
        //    Assert.IsTrue(resList.SequenceEqual(resFindList));
        //}

        [TestMethod]
        public void IsMatch_Question_True()
        {
            //arange
            string str = "h";
            string pattern = "?";

            //act
            var result = globPattern.IsMatch(str, pattern);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_Star_True()
        {
            //arange
            string str = "house";
            string pattern = "h*us*";

            //act
            var result = globPattern.IsMatch(str, pattern);

            //assert
            Assert.IsTrue(result);
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

    }
}
