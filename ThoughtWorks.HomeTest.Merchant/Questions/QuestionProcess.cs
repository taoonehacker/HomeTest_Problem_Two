using System;
using System.Text;
using System.Linq;
using ThoughtWorks.HomeTest.Merchant.Roman;
using ThoughtWorks.HomeTest.Merchant.Parameters;
using ThoughtWorks.HomeTest.Merchant.Metals;
using ThoughtWorks.HomeTest.Merchant.Extensions;

namespace ThoughtWorks.HomeTest.Merchant.Questions
{
    /// <summary>
    /// Process question data.
    /// </summary>
    public class QuestionProcess: IProcess
    {
        private Context _context;

        public QuestionProcess(Context context)
        {
            this._context = context;
        }

        public void Process(string symbols)
        {
            symbols = symbols.Substring(0, symbols.Length - 1);

            var parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            var secondParts = parts[1].Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

            var  metalName= secondParts[secondParts.Length - 1];
            var unitIndex = parts[0].IndexOfAny("Credits".ToCharArray());

            var sb = new StringBuilder();
            for (int i = 0; i < secondParts.Length - 1; i++)
            {
                sb.Append(_context.ParameterData.GetParameterValueByName(secondParts[i]));
            }

            var total = _context.RomanProcess.ToInt(sb.ToString());
            if (total.HasValue)
                Console.WriteLine(String.Format("{0} is {1}"+(unitIndex > 0? " Credits" : "") , parts[1].Substring(0,parts[1].Length-1), total.Value * _context.MetalData.GetMetalPriceByMetalName(metalName)));
        }


        public bool IsMatch(string symbols)
        {
            symbols = symbols.Substring(0, symbols.Length - 1);

            bool isQuestion = (symbols.StartsWith("how many", StringComparison.OrdinalIgnoreCase));
            if (!isQuestion) return false;

            string[] parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;

            string[] secondParts = parts[1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (secondParts.Length < 1) return false;

            return _context.ParameterData.IsExistInParameterData(secondParts.Take(secondParts.Length - 1).ToArray()) &&
                       _context.MetalData.IsExistInMetalData(secondParts.Skip(secondParts.Length - 1).ToArray());
        }

    }
}
