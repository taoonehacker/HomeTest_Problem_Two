using System;
using System.Collections.Generic;
using System.Linq;

namespace ThoughtWorks.HomeTest.Merchant.Roman
{
    /// <summary>
    /// Process Roman symbol. 
    /// </summary>
    public class RomanProcess
    {
        Dictionary<string, int> _romanMapper;

        public RomanProcess()
        {
            _romanMapper = new Dictionary<string, int>();
            _romanMapper.Add("I", 1);
            _romanMapper.Add("V", 5);
            _romanMapper.Add("X", 10);
            _romanMapper.Add("L", 50);
            _romanMapper.Add("C", 100);
            _romanMapper.Add("D", 500);
            _romanMapper.Add("M", 1000);
        }


        public int? ToInt(string symbols)
        {
            if (!CanTransformate(symbols)) return null;
            return TransformateToInt(symbols);
        }

        private bool CanTransformate(string symbols)
        {
            return IsRepeate(symbols)&& IsRepeateFourTimes(symbols)&& IsSubtraction(symbols);
        }

        private int TransformateToInt(string symbols)
        {
            int current = 0,next = 0,total = 0;

            for(var i=0;i< symbols.Length;i++)
            {
                current = _romanMapper[symbols[i].ToString()];
                if (i < symbols.Length - 1)
                    next = _romanMapper[symbols[i + 1].ToString()];

                if (current < next)
                {
                    total += next - current;
                    i++;
                }
                else
                    total += current;
            }
            return total;
        }

        private bool IsRepeate(string symbols)
        {
            var result = (symbols.Length < 2) || (symbols.Count(s => s == 'D') <= 1 && symbols.Count(s => s == 'L') <= 1 && symbols.Count(s => s == 'V')<=1);
            if (!result)
                Console.WriteLine("the rule of can be repeated is broken");
            return result;
        }

        private bool IsRepeateFourTimes(string symbols)
        {
            bool result = (symbols.Length < 4) || !(symbols.Contains("IIII") || symbols.Contains("XXXX") || symbols.Contains("CCCC") || symbols.Contains("MMMM"));
            if (!result)
                Console.WriteLine("the rule of can be repeated 4 times is broken"); 
            return result;
        }

        private bool IsSubtraction(string symbols)
        {
            bool result = (symbols.Length < 2) || !(symbols.Contains("IL") || symbols.Contains("IC") || symbols.Contains("ID") || symbols.Contains("IM") || symbols.Contains("XD") || symbols.Contains("XM"));
            if (!result)
                Console.WriteLine("the rule of subtraction is broken");
            return result;
        }

    }
}
