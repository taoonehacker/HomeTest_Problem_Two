using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.HomeTest.Merchant.Roman
{
    /// <summary>
    /// Roman symbol.
    /// </summary>
    public class RomanSymbol
    {
        private static readonly string romanSymbols = "IVXLCDM";

        public char Symbol { get; set; }
        public int Value { get; set; }
        public bool IsRepeat { get; set; }
        public bool IsSubtract { get; set; }
        
        public RomanSymbol(char symbol,int value=0,bool isRepeat=false,bool isSubtract=false)
        {
            this.Symbol = symbol;
            this.Value = value;
            this.IsRepeat = isRepeat;
            this.IsSubtract = isSubtract;
        }

        public static string GetRomanSymbols()
        {
            return romanSymbols;
        }

    }
}
