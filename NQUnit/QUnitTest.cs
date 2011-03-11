using System;

namespace NQUnit
{
    /// <summary>
    /// Encapsulates the information about a QUnit test, including the pass or fail status.
    /// </summary>
    public class QUnitTest
    {
        /// <summary>
        /// The file name the QUnit test was run from.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The name of the test.
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// The result of the test ("pass" or "fail").
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// If the test failed this contains more information explaining why.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Will be thrown if there was a problem initializing the QUnit test.
        /// </summary>
        public Exception InitializationException { get; set; }

        /// <summary>
        /// Provides a concise string representation of the test so that unit testing libraries can show a reasonable description of the test.
        /// </summary>
        /// <returns>A concise string representation of the test</returns>
        public override string ToString()
        {
            return string.Format("[{0}] {1}", FileName, TestName);
        }
    }
}