using System;
using NUnit.Framework;

namespace QUnit.NUnit.JavaScript
{
    public static class NUnitQUnitHelpers
    {
        public static void ShouldPass(this QUnitTest theTest)
        {
            if(theTest.InitializationException!=null)
                throw new Exception("The QUnit initialization failed.", theTest.InitializationException);
            Assert.That(theTest.Result, Is.EqualTo("pass"), "Test: " + theTest.TestName + Environment.NewLine + theTest.Message);
        }
    }
}
