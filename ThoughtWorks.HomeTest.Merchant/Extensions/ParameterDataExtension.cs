using System;
using System.Collections.Generic;
using System.Text;
using ThoughtWorks.HomeTest.Merchant.Parameters;

namespace ThoughtWorks.HomeTest.Merchant.Extensions
{
    /// <summary>
    /// parameter data extension method.
    /// </summary>
    public static class ParameterDataExtension
    {
        public static bool IsExistInParameterData(this ParameterData parameterData,string[] symbols)
        {
            foreach (var symbol in symbols)
            {
                if (!parameterData.IsExist(symbol))
                    return false;
            }
            return true;
        }

    }
}
