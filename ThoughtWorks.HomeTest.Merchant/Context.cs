using ThoughtWorks.HomeTest.Merchant.Parameters;
using ThoughtWorks.HomeTest.Merchant.Metals;
using ThoughtWorks.HomeTest.Merchant.Roman;

namespace ThoughtWorks.HomeTest.Merchant
{
    public class Context
    {
        public ParameterData ParameterData { get; set; }
        public MetalData MetalData { get; set; }
        public RomanProcess RomanProcess { get; set; }

        public Context()
        {
            ParameterData = new ParameterData();
            MetalData = new MetalData();
            RomanProcess = new RomanProcess();
        }

    }
}
