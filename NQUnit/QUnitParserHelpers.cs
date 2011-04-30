using System;
using System.Xml.Linq;

namespace NQUnit
{
    /// <summary>
    /// Contains extension methods to help the QUnitParser
    /// </summary>
    public static class QUnitParserHelpers
    {
        /// <summary>
        /// Provides a case-insensitive comparison between an XName element and a string.
        /// </summary>
        /// <param name="xname">The XName to compare</param>
        /// <param name="name">The string to compare</param>
        /// <returns>Whether or not the XName and the string where the same (case-insensitive)</returns>
        public static bool Is(this XName xname, string name)
        {
            return xname.ToString().Equals(name, StringComparison.OrdinalIgnoreCase);
        }
    }
}