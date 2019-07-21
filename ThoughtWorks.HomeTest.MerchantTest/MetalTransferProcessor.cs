using System;
using System.Linq;
using ThoughtWorks.HomeTest.Merchant;
using ThoughtWorks.HomeTest.Merchant.Extensions;
namespace ThoughtWorks.HomeTest.MerchantTest
{
    internal class MetalTransferProcessor : IProcess
    {
        private Context _context;
        public MetalTransferProcessor(Context context)
        {
            this._context = context;
        }

        public bool IsMatch(string symbols)
        {
            symbols = symbols.Substring(0, symbols.Length - 1);

            bool isQuestion = (symbols.StartsWith("how many", StringComparison.OrdinalIgnoreCase));
            if (!isQuestion) return false;
            
            var parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            var partsOne = parts[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var partsTwo = parts[1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return parts.Length == 2 && _context.MetalData.IsExistInMetalData(partsOne.Take(3).Skip(2).ToArray())
                && _context.ParameterData.IsExistInParameterData(partsTwo.Take(partsTwo.Length - 1).ToArray())
                && partsTwo.FirstOrDefault() == "glob";
            
        }

        public void Process(string symbols) 
        {
            throw new System.NotImplementedException();
        }
    }
}