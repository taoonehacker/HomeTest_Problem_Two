using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.HomeTest.Merchant.Parameters
{
    /// <summary>
    /// Mapping parameter data.
    /// </summary>
    public class ParameterData
    {
        private Dictionary<string, string> _parameterData;

        public ParameterData()
        {
            _parameterData = new Dictionary<string, string>();
        }

        public void AddParameter(string parameterName, string parameterValue)
        {
            if (!IsExist(parameterName))
                _parameterData.Add(parameterName, parameterValue);
            else
                _parameterData[parameterName] = parameterValue;
        }

        public string GetParameterValueByName(string parameterName)
        {
            return _parameterData[parameterName];
        }

        public bool IsExist(string parameterName)
        {
            return _parameterData.ContainsKey(parameterName);
        }

    }
}
