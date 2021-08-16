using System;
using System.IO;

namespace WebApiSelfHostBC.LoggerSeedTest.BCRedirect
{
    public static class Redirect
    {
        static FileStream ostrm;
        static StreamWriter writer;

        static TextWriter oldOut = Console.Out;
        public static void Open(string name = "_bcRedirect")
        {
            String _name = name;
            try
            {
                ostrm = new FileStream("../../" + _name + ".txt", FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open " + _name + ".txt for writing!!!");
                Console.WriteLine(e.Message);
            }
            Console.SetOut(writer);
        }
        public static void Close()
        {
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine();
        }
    }
}
