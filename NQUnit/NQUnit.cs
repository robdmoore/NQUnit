using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NQUnit
{
    public class NQUnit
    {
        /// <summary>
        /// Returns an array of QUnitTest objects that encapsulate the QUnit tests within the passed in files to test.
        /// </summary>
        /// <param name="filesToTest">A list of one or more files to run tests on relative to the root of the test project.</param>
        /// <returns>An array of QUnitTest objects encapsulating the QUnit tests in the given files</returns>
        public static IEnumerable<QUnitTest> GetTests(params string[] filesToTest)
        {
            var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            var tests = default(IEnumerable<QUnitTest>);
            var exception = default(Exception);

            // WatiN requires STA to run so rather than making the whole assembly
            //  run with STA, which causes trouble when running with TeamCity we create
            //  an STA thread in which to run the WatiN tests.
            var t = new Thread(() =>
            {
                var qUnitParser = default(QUnitParser);
                try
                {
                    qUnitParser = new QUnitParser();
                    tests = filesToTest.SelectMany(qUnitParser.GetQUnitTestResults).ToArray();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                finally
                {
                    if (qUnitParser != null)
                        qUnitParser.Dispose();
                    waitHandle.Set();
                }

            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            waitHandle.WaitOne();

            if (exception != null)
                return new []{ new QUnitTest { InitializationException = exception } };

            return tests;
        }
    }
}