using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project
{
    internal class Program
    {
        public static Task1 task1 = new Task1();
        public static Task2 task2 = new Task2();
        public static Task3 task3 = new Task3();
        public static Task4 task4 = new Task4();

        static void Main(string[] args)
        {
         //while(true)
         //   {
                Work();
            //}
        }

        public static void Work()
        {
            Environment.GetCommandLineArgs().ToList().ForEach(x =>
            {
                if (x.EndsWith("/1"))
                {
                    string _input1 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) +1];
                    string _input2 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) +2];
                    task1.Work(_input1, _input2);
                }
                if (x.EndsWith("/2"))
                {
                    string _input1 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) + 1];
                    string _input2 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) + 2];
                    task2.Work(_input1, _input2);
                }
                if (x.EndsWith("/3"))
                {
                    string _input1 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) + 1];
                    string _input2 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) + 2];
                    string _input3 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) + 3];
                    task3.Work(_input1, _input2, _input3);
                }
                if (x.EndsWith("/4"))
                {
                    string _input1 = Environment.GetCommandLineArgs().ToList()[Environment.GetCommandLineArgs().ToList().IndexOf(x) + 1];
                    task4.Work(_input1);
                }
            });
        }
    }
}
