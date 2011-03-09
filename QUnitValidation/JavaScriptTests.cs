﻿using System.Collections.Generic;
using NUnit.Framework;
using WatiN.Core;

namespace QUnitValidation
{

    [TestFixture]
    
    public class JavaScriptTests
    {
        [Test, TestCaseSource("GetQUnitTests")]
        public void QUnit(QUnitTest test)
        {
            test.ShouldPass();
        }

        public IEnumerable<QUnitTest> GetQUnitTests()
        {
            IEnumerable<QUnitTest> tests;
            using (var n = new NUnitQUnit())
            {
                tests = n.GetTests("test.html");
            }
            return tests;
            //yield return new QUnitTest {FileName = "asdf", Message = "asdf", Result = "pass", TestName = "adsf"};
        }
    }
}