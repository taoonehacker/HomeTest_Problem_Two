using System;
using System.Text;
using ThoughtWorks.HomeTest.Merchant.Extensions;
using ThoughtWorks.HomeTest.Merchant.Roman;

namespace ThoughtWorks.HomeTest.Merchant.Questions
{
    /// <summary>
    /// Process parameter question data.
    /// </summary>
    public class ParameterQuestionProcess: IProcess
    {
        private Context _context;

        public ParameterQuestionProcess(Context context)
        {
            this._context = context;
        }


        public void Process(string symbols)
        {
            symbols = symbols.Substring(0, symbols.Length - 1);

            var sb = new StringBuilder();
            var parts = symbols.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            var secondParts = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in secondParts)
            {
                if (!_context.ParameterData.IsExist(word))
                {
                    Console.WriteLine(String.Format("Error while processing this input: {0}", symbols));
                    return;
                }
                sb.Append(_context.ParameterData.GetParameterValueByName(word));
            }

            Console.WriteLine(String.Format("{0} is {1}", parts[1].Substring(0, parts[1].Length - 1), _context.RomanProcess.ToInt(sb.ToString())));
        }

        public bool IsMatch(string symbols)
        {
            symbols = symbols.Substring(0, symbols.Length - 1);

            bool isQuestion = (symbols.StartsWith("how much", StringComparison.OrdinalIgnoreCase));
            if (!isQuestion) return false;

            string[] parts = symbols.Split(" is ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;

            string[] secondParts = parts[1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (secondParts.Length < 1) return false;

            return _context.ParameterData.IsExistInParameterData(secondParts);
        }
    }
}
