using System.Collections.Generic;
using NQUnit.NUnit.NUnit;
using NUnit.Framework;

namespace NQUnit.NUnit
{
    [TestFixture]
    public class QUnitTests
    {
        [Test, TestCaseSource("GetQUnitTests")]
        public void Test(QUnitTest test)
        {
            test.ShouldPass();
        }

        public IEnumerable<QUnitTest> GetQUnitTests()
        {
            return NQUnit.GetTests(@"JavaScript\test.html");
        }
    }
}