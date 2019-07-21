using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.HomeTest.Merchant.Metals;

namespace ThoughtWorks.HomeTest.Merchant.Extensions
{
    /// <summary>
    /// metal data extension method.
    /// </summary>
    public static class MetalDataExtension
    {
        public static bool IsExistInMetalData(this MetalData metalData, string[] symbols)
        {
            return symbols.Any(a => metalData.IsExist(a));
        }
    }
}
