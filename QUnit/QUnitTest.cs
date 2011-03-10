using System;

namespace QUnit
{
    public class QUnitTest
    {
        public string FileName { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }

        public Exception InitializationException { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", FileName, TestName);
        }
    }
}