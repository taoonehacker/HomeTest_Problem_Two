using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.HomeTest.Merchant.Metals
{
    /// <summary>
    /// Mapping metal data.
    /// </summary>
    public class MetalData
    {
        private Dictionary<string, double> _metalData;

        public MetalData()
        {
            this._metalData = new Dictionary<string, double>();
        }

        public void AddMetal(string metalName,double unitPrice)
        {
            if (!IsExist(metalName))
                _metalData.Add(metalName, unitPrice);
            _metalData[metalName] = unitPrice;
        }

        public double GetMetalPriceByMetalName(string metalName)
        {
            return _metalData[metalName];
        }

        public bool IsExist(string metalName)
        {
            return _metalData.ContainsKey(metalName);
        }


    }
}
