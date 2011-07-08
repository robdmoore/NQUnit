using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NQUnit
{
    /// <summary>
    /// Entry class for parsing and returning QUnit tests.
    /// </summary>
    public class NQUnit
    {
        /// <summary>
        /// Clear the browser cache before running tests to ensure you always run against the latest version of a file.
        /// </summary>
        public static bool ClearCacheBeforeRunningTests;
        /// <summary>
        /// Hide the browser window while running tests to stop it from stealing focus.
        /// </summary>
        public static bool HideBrowserWindow;

        /// <summary>
        /// Returns an array of QUnitTest objects that encapsulate the QUnit tests within the passed in files to test.
        /// Will wait for infinity for any asynchronous tests to run.
        /// </summary>
        /// <param name="filesToTest">A list of one or more files to run tests on relative to the root of the test project.</param>
        /// <returns>An array of QUnitTest objects encapsulating the QUnit tests in the given files</returns>
        public static IEnumerable<QUnitTest> GetTests(params string[] filesToTest)
        {
            return GetTests(-1, filesToTest);
        }

        /// <summary>
        /// Returns an array of QUnitTest objects that encapsulate the QUnit tests within the passed in files to test.
        /// </summary>
        /// <param name="maxWaitInMs">The maximum number of milliseconds before the tests should timeout after page load; -1 for infinity, 0 to not support asynchronous tests</param>
        /// <param name="filesToTest">A list of one or more files to run tests on relative to the root of the test project.</param>
        /// <returns>An array of QUnitTest objects encapsulating the QUnit tests in the given files</returns>
        public static IEnumerable<QUnitTest> GetTests(int maxWaitInMs, params string[] filesToTest)
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
                    qUnitParser = new QUnitParser(maxWaitInMs);
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