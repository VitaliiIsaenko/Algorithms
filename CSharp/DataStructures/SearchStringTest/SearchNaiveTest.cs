using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchString;
using System.Collections;
using System.Linq;
using System.Diagnostics;

namespace SearchStringTest
{
    [TestClass]
    public class SearchNaiveTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void SearchCountTest()
        {
            IStringSearchAlgorithm searchString = new NaiveSearch();
            var result = searchString.Search("don", "That is donCorleon");
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void SearchSymbolsCountTest()
        {
            IStringSearchAlgorithm searchString = new NaiveSearch();
            var result = searchString.Search("don", "That is donCorleon");
            Assert.AreEqual(result.First().MatchCount, 3);
        }

        [TestMethod]
        public void SearchStartIndexTest()
        {
            IStringSearchAlgorithm searchString = new NaiveSearch();
            var result = searchString.Search("don", "That is donCorleon");
            Assert.AreEqual(result.First().StartIndex, 8);
        }
    }
}
