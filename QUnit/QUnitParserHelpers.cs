using System;
using System.Xml.Linq;

namespace QUnit
{
    public static class QUnitParserHelpers
    {
        public static bool Is(this XName xname, string name)
        {
            return xname.ToString().Equals(name, StringComparison.OrdinalIgnoreCase);
        }
    }
}