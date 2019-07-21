using System;
using ThoughtWorks.HomeTest.Merchant.Roman;

namespace ThoughtWorks.HomeTest.Merchant.Parameters
{
    /// <summary>
    /// Process parameter data.
    /// </summary>
    public class ParameterProcess: IProcess
    {
        private Context _context;

        public ParameterProcess(Context context)
        {
            this._context = context;
        }

        public void Process(string symbols)
        {
            var parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            _context.ParameterData.AddParameter(parts[0], parts[1]);
        }

        public bool IsMatch(string symbols)
        {
            var romanSymbols = RomanSymbol.GetRomanSymbols();
            var parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;
            return romanSymbols.Contains(parts[1]);
        }
    }
}
