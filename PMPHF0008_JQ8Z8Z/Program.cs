using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF8
{
    internal class Program
    {
        class LogicalGate
        {
            public string name { get; }
            public string signal { get; }

            public LogicalGate(string input)
            {
                string[] tmpArray = input.Split(' ');
                name = tmpArray[0];
                string signal = tmpArray[1];
                string result = "";
                string tempString = "";

                for (int i = 0; i < signal.Length; i++)
                {
                    tempString += signal[i];
                    if ((i + 1) % 2 == 0)
                    {
                        if ((double.Parse(tempString) / 10) >= 0 && (double.Parse(tempString) / 10) <= 0.8) result += "0";
                        else if ((double.Parse(tempString) / 10) >= 2.7 && (double.Parse(tempString) / 10) <= 5) result += "1";
                        else if ((double.Parse(tempString) / 10) > 0.8 && (double.Parse(tempString) / 10) < 2.7) result += "E";
                        tempString = "";
                    }
                }
                this.signal = result;
            }
            public static string NOT(string src1)
            {
                string signal = src1;
                string result = "";
                for (int i = 0; i < signal.Length; i++)
                {
                    if (signal[i] == 'E') result += "E";
                    else if (signal[i] == '0') result += "1";
                    else if (signal[i] == '1') result += "0";
                }
                return result;
            }
            public static string AND(string src1, string src2)
            {
                string signal1 = src1;
                string signal2 = src2;
                string result = "";
                for (int i = 0; i < signal1.Length; i++)
                {
                    if (signal1[i] == 'E' || signal2[i] == 'E') result += "E";
                    else if (signal1[i] == '1' && signal2[i] == '1') result += "1";
                    else result += "0";
                }
                return result;
            }
            public static string OR(string src1, string src2)
            {
                string signal1 = src1;
                string signal2 = src2;
                string result = "";
                for (int i = 0; i < signal1.Length; i++)
                {
                    if (signal1[i] == 'E' || signal2[i] == 'E') result += "E";
                    else if (signal1[i] == '1' || signal2[i] == '1') result += "1";
                    else result += "0";
                }
                return result;
            }
            public static string NAND(string src1, string src2)
            {
                string signal1 = src1;
                string signal2 = src2;
                string result = "";
                for (int i = 0; i < signal1.Length; i++)
                {
                    if (signal1[i] == 'E' || signal2[i] == 'E') result += "E";
                    else if (signal1[i] == '1' && signal2[i] == '1') result += "0";
                    else result += "1";
                }
                return result;
            }
            public static string NOR(string src1, string src2)
            {
                string signal1 = src1;
                string signal2 = src2;
                string result = "";
                for (int i = 0; i < signal1.Length; i++)
                {
                    if (signal1[i] == 'E' || signal2[i] == 'E') result += "E";
                    else if (signal1[i] == '1' || signal2[i] == '1') result += "0";
                    else result += "1";
                }
                return result;
            }
            public static string XOR(string src1, string src2)
            {
                string signal1 = src1;
                string signal2 = src2;
                string result = "";
                for (int i = 0; i < signal1.Length; i++)
                {
                    if (signal1[i] == 'E' || signal2[i] == 'E') result += "E";
                    else if (signal1[i] == '1' && signal2[i] == '1') result += "0";
                    else if (signal1[i] == '1' || signal2[i] == '1') result += "1";
                    else result += "0";
                }
                return result;
            }
            public static string XNOR(string src1, string src2)
            {
                string signal1 = src1;
                string signal2 = src2;
                string result = "";
                for (int i = 0; i < signal1.Length; i++)
                {
                    if (signal1[i] == 'E' || signal2[i] == 'E') result += "E";
                    else if (signal1[i] == '1' && signal2[i] == '1') result += "1";
                    else if (signal1[i] == '1' || signal2[i] == '1') result += "0";
                    else result += "1";
                }
                return result;
            }
        }
        static void Main(string[] args)
        {
            List<LogicalGate> logicalGates = new List<LogicalGate>();
            string firstLine = Console.ReadLine();
            string line = " ";

            while (line != "")
            {
                line = Console.ReadLine();
                if (line != "") logicalGates.Add(new LogicalGate(line));
            }

            if (firstLine.Split(' ')[0] == "NOT")
            {
                int index = 0;
                for (int i = 0; i < logicalGates.Count; i++) if (logicalGates[i].name == firstLine.Split(' ')[1]) index = i;
                Console.WriteLine(LogicalGate.NOT(logicalGates[index].signal));
            }
            else
            {
                int[] index = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < logicalGates.Count; j++) if (logicalGates[j].name == firstLine.Split(' ')[1 + i]) index[i] = j;
                }
                if (firstLine.Split(' ')[0] == "AND") Console.WriteLine(LogicalGate.AND(logicalGates[index[0]].signal, logicalGates[index[1]].signal));
                else if (firstLine.Split(' ')[0] == "OR") Console.WriteLine(LogicalGate.OR(logicalGates[index[0]].signal, logicalGates[index[1]].signal));
                else if (firstLine.Split(' ')[0] == "NAND") Console.WriteLine(LogicalGate.NAND(logicalGates[index[0]].signal, logicalGates[index[1]].signal));
                else if (firstLine.Split(' ')[0] == "NOR") Console.WriteLine(LogicalGate.NOR(logicalGates[index[0]].signal, logicalGates[index[1]].signal));
                else if (firstLine.Split(' ')[0] == "XOR") Console.WriteLine(LogicalGate.XOR(logicalGates[index[0]].signal, logicalGates[index[1]].signal));
                else if (firstLine.Split(' ')[0] == "XNOR") Console.WriteLine(LogicalGate.XNOR(logicalGates[index[0]].signal, logicalGates[index[1]].signal));
            }
            Console.ReadLine();
        }
    }
}
