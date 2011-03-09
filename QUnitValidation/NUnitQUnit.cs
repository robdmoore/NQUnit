using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace QUnitValidation
{
    public class NUnitQUnit : IDisposable
    {
        private readonly QUnitParser _qUnitParser;

        public NUnitQUnit()
        {
            _qUnitParser = new QUnitParser();
        }

        public IEnumerable<QUnitTest> GetTests(params string[] filesToTest)
        {
            return filesToTest.SelectMany(file => _qUnitParser.GetQUnitTestResults(file)).ToArray();
        }

        public void Dispose()
        {
            _qUnitParser.Dispose();
        }
    }

    public static class NUnitQUnitHelpers
    {
        public static void ShouldPass(this QUnitTest theTest)
        {
            Assert.That(theTest.Result.Split(' '), Has.Member("pass"), theTest.Message);
        }
    }
}
