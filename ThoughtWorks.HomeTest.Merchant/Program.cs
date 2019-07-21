using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ThoughtWorks.HomeTest.Merchant
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.GetFullPath("../../..") + "\\problemTwo.txt";

            Console.WriteLine("--- Problem Two: Merchant's Guide to the Galaxy ---");

            //using (TextReader reader = new StreamReader("problemTwo.txt"))
            using (TextReader reader = new StreamReader(path))
            {
                var lines = new List<string>();
                string line = null;
                do
                {
                    line = reader.ReadLine();
                    if (line == null)
                        break;
                    Console.WriteLine(line);
                    lines.Add(line);
                }
                while (line != null);

                Console.WriteLine("--- Thinking ---");

                Context context = new Context();


                var parser = new Parser(context);
                var parseTask = Task.Run(() => parser.Parse(lines.ToArray()));
                //parser.Parse(lines.ToArray());
            }
            Console.ReadLine();
        }
    }
}
