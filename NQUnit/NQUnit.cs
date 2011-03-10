using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NQUnit
{
    public class NQUnit
    {
        public static IEnumerable<QUnitTest> GetTests(params string[] filesToTest)
        {
            var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            var tests = default(IEnumerable<QUnitTest>);
            var exception = default(Exception);

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
                return new []{new QUnitTest {InitializationException = exception}};
            return tests;
        }
    }
}