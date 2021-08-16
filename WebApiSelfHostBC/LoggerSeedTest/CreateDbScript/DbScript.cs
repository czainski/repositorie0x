using WebApiSelfHostBC.Context;
using WebApiSelfHostBC.LoggerSeedTest.Logger;
using System;

namespace WebApiSelfHostBC.LoggerSeedTest.CreateDbScript
{
    public static class DbScript
    {
        //DbScript.Generate(new Db()); return;
        static public void Generate(Context.Context context)
            {
                try
                {
                    Console.WriteLine("Datebase is creating! ");
                    context.Database.Delete();

                    context.Database.Log = logInfo => 
							FileLogger.Log("SQL_CREATE_DATABASE.txt", logInfo);
                    context.Database.Create();
                    context.Database.Log = Console.Write;

                    context.Database.Delete();
                    Console.WriteLine("Datebase has deleted! ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Date Base not done! ");
                    Console.ReadLine();
                    throw;
                }
            }
    }
}


