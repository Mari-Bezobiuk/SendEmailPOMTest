using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailPOMTest
{
    internal class UniqueStringGenerator
    {
        public static string UniqueStringGeneration()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "").Replace("+", "");

            return GuidString;
        }
    }
}
