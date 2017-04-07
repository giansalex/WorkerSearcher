using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace WorkerSearcher.Computrabajo.Tests
{
    [TestClass]
    public class ComputrabajoSearcherTests
    {
        private readonly ComputrabajoSearcher _searcher = new ComputrabajoSearcher();
        [TestMethod]
        public void SearchTest()
        {
            var links = _searcher.Search("Net", ".Net", "NET", ".NET");
            Assert.IsNotNull(links);
            foreach (var link in links)
            {
                Assert.IsTrue(link.IsAbsoluteUri);
                Trace.WriteLine(link.AbsoluteUri);
            }
        }
    }
}