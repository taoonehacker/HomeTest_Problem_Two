using System;
using System.Linq;
using System.Collections.Generic;

namespace ThoughtWorks.HomeTest.Merchant
{
    public class Parser
    {
        private List<IProcess> _processes;

        //TODO 把获取IProcess接口的实现分离出去
        public Parser(Context context)
        {
            _processes = new List<IProcess>();
            
            //利用反射找到所有实现IProcess的接口的实现类
            var type = typeof(IProcess);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(type)));

            foreach (var v in types)
            {
                if (v.IsClass)
                {
                    object[] parameters = new object[1];
                    parameters[0] = context;
                    _processes.Add((Activator.CreateInstance(v, parameters) as IProcess));
                }
            }
            
            //移除这种实例化的方式
            //_processes.Add(new ParameterQuestionProcess(parameterMapper,romanProcess));
            //_processes.Add(new MetalProcess(metalMapper, parameterMapper, romanProcess));
            //_processes.Add(new QuestionProcess(parameterMapper,metalMapper,romanProcess));
        }


        public void Parse(string[] symbols)
        {
            foreach(var symbol in symbols)
            {
                var matchProcesses = _processes.FirstOrDefault(e => e.IsMatch(symbol));
                if (matchProcesses == null) Console.WriteLine("I have no idea what you are talking about");
                else matchProcesses.Process(symbol);
            }
        }

    }
}
