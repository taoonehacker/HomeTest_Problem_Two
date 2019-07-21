using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.HomeTest.Merchant
{
    public interface IProcess
    {
        bool IsMatch(string symbols);
        void Process(string symbols);
    }
}
