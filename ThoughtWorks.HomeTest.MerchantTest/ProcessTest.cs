using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThoughtWorks.HomeTest.Merchant;
using ThoughtWorks.HomeTest.Merchant.Parameters;
using ThoughtWorks.HomeTest.Merchant.Metals;
using ThoughtWorks.HomeTest.Merchant.Questions;
using ThoughtWorks.HomeTest.Merchant.Roman;

namespace ThoughtWorks.HomeTest.MerchantTest
{
    [TestClass]
    public class ProcessTest
    {
        private Context context;

        [TestInitialize]
        public void SetUp()
        {
            context = new Context();
        }
        [TestMethod]
        public void RomanProcessTest()
        {
            var roman = new RomanProcess();
            Assert.AreEqual(2006, roman.ToInt("MMVI"));
            Assert.AreEqual(1903, roman.ToInt("MCMIII"));
        }

        [TestMethod]
        public void CanMatchMetalTransferQuestion()
        {
            var processor = new MetalTransferProcessor(context);

            context.MetalData.AddMetal("Silver", 17);
            context.MetalData.AddMetal("Gold", 24);
            context.ParameterData.AddParameter("glob", "I");

            Assert.IsTrue(processor.IsMatch("How many Silver is glob Gold ?"));
            Assert.IsTrue(processor.IsMatch("How many Gold is glob Silver ?"));
            Assert.IsFalse(processor.IsMatch("glob is I"));
        }




        [TestMethod]
        public void ParameterProcessTest()
        {
            var parameterProcess = new ParameterProcess(context);

            Assert.IsTrue(parameterProcess.IsMatch("gold is I"));
            Assert.IsFalse(parameterProcess.IsMatch("prok is Q"));

            parameterProcess.Process("glob is I");
            Assert.IsTrue(context.ParameterData.IsExist("glob"));
            Assert.IsTrue(context.ParameterData.GetParameterValueByName("glob") == "I");

        }
        [TestMethod]
        public void MetalProcessTest()
        {
            var metalProcess = new MetalProcess(context);

            context.ParameterData.AddParameter("glob", "I");

            Assert.IsTrue(metalProcess.IsMatch("glob glob Silver is 34 Credits"));

            metalProcess.Process("glob glob Silver is 34 Credits");
            Assert.IsTrue(context.MetalData.IsExist("Silver"));
            Assert.IsTrue(context.MetalData.GetMetalPriceByMetalName("Silver") ==17);
        }
        [TestMethod]
        public void QuestionProcessTest()
        {
            var questionProcess = new QuestionProcess(context);
            context.MetalData.AddMetal("Silver", 17);
            context.ParameterData.AddParameter("glob", "I");
            context.ParameterData.AddParameter("prok", "V");

            Assert.IsTrue(questionProcess.IsMatch("how many Credits is glob prok Silver ?"));
            Assert.IsFalse(questionProcess.IsMatch("how much is pish tegj glob glob ?"));
        }
        [TestMethod]
        public void ParameterQuestionProcessTest()
        {
            var parameterQuestionProcess = new ParameterQuestionProcess(context);
            context.ParameterData.AddParameter("pish", "X");
            context.ParameterData.AddParameter("tegj", "L");
            context.ParameterData.AddParameter("glob", "I");
            Assert.IsTrue(parameterQuestionProcess.IsMatch("how much is pish tegj glob glob ?"));
            Assert.IsFalse(parameterQuestionProcess.IsMatch("how many Credits is glob prok Gold ?"));
        }

    }
}
