using System;
using System.Linq;
using System.Text;
using ThoughtWorks.HomeTest.Merchant.Roman;
using ThoughtWorks.HomeTest.Merchant.Parameters;
using ThoughtWorks.HomeTest.Merchant.Extensions;

namespace ThoughtWorks.HomeTest.Merchant.Metals
{
    /// <summary>
    /// process metal data.
    /// </summary>
    public class MetalProcess:IProcess
    {
        private Context _context;

        public MetalProcess(Context context)
        {
            this._context = context;
        }

        public void Process(string symbols)
        {
            var parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            var firstParts = parts[0].Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var secondParts = parts[1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            double price = 0;
            price = Convert.ToDouble(secondParts[0].ToString());
            var metalName = firstParts[firstParts.Length - 1];
            var sb = new StringBuilder();
            for (int i = 0; i < firstParts.Length - 1; i++)
            {
                sb.Append(_context.ParameterData.GetParameterValueByName(firstParts[i]));
            }
            var total = _context.RomanProcess.ToInt(sb.ToString());
            if (total.HasValue)
                _context.MetalData.AddMetal(metalName, price / total.Value);
            else
                Console.WriteLine("Error in calculating metal unit price");
        }

        public bool IsMatch(string symbols)
        {
            var parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;
            var firstParts = parts[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var secondParts = parts[1].Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            return symbols.EndsWith("credits", StringComparison.OrdinalIgnoreCase) &&
                            !symbols.StartsWith("how many", StringComparison.OrdinalIgnoreCase) && parts.Length == 2 &&
                             secondParts.Length == 2&& _context.ParameterData.IsExistInParameterData(firstParts.Take(firstParts.Length-1).ToArray());
        }
    }
}
