using System.Collections.Generic;
using NUnit.Framework;

namespace NQUnit.NUnit.JavaScript
{
    [TestFixture]
    public class JavaScriptTests
    {
        [Test, TestCaseSource("GetQUnitTests")]
        public void QUnitTests(QUnitTest test)
        {
            test.ShouldPass();
        }

        public IEnumerable<QUnitTest> GetQUnitTests()
        {
            return NQUnit.GetTests("test.html");
        }
    }
}