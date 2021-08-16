using Microsoft.Owin.Hosting;
using WebApiSelfHostBC.ClientResponse;
using WebApiSelfHostBC.Seed;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiSelfHostBC.ConsoleRead;
using WebApiSelfHostBC.Seed.TestsFactory;
using WebApiSelfHostBC.LoggerSeedTest.BCRedirect;

namespace WebApiSelfHostBC
{
    internal class Program
    {
         static async Task  Main(string[] args)
        {
            string address = "" ;
            string authorization = "";
            (address, authorization) = await Task.Run(() => ConsoleParam.Param());

            Console.WriteLine("\n\n\t"+address+"\n");
            using (WebApp.Start<Startup>(url: address))
            {
                HttpClient client = new HttpClient();
                await Task.Run(() => client.DefaultRequestHeaders.Accept.Clear());
                await Task.Run(() => client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")));
                string authInfo = await Task.Run(() => Convert.ToBase64String(Encoding.Default.GetBytes(authorization))); //("Username:Password")  
                await Task.Run(() => client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo));

                Console.WriteLine("\n\tThe database: \"_WebApiSelfHostBC\" was created in LocalDB !!!\n");
                //await CR.GetCompanys(address, client);
                
                Console.WriteLine("\tStart a test. ");
                Console.WriteLine("\n\n\tResultats of  the test will be writing into a file: TEST_OUTPUT.txt\nlocated in the directory: WebApiSelfHostBC .");
                Console.WriteLine("\n\n\tPlease wait !!!");
                
                Redirect.Open("TEST_OUTPUT");
                Console.WriteLine("\nTest 1. POST: /company/create ");
                await  CR.CreateCompany(new NewCompany().Get(), address, client);
                await  CR.CreateCompany(new NewCompany().Get(), address, client);
                await  CR.CreateCompany(null, address, client);

                Console.WriteLine("\nTest 2. POST: /company/search ");
                Console.WriteLine("Criterion:  \"Name\":  ...\"Alfa\"... || \n\"EstablishmentYear\": [2 - 7]"+
                    "|| \"FirstName\":  ...\"Alfa\"... || \"LastName\":  ...\"Alfa\"... " +
                    "|| JobTitle :   Developer(1) or Architect(2)  ||  \"DateOfBirth\":  [1980.01.01 - 1980.12.31]\n");
                await CR.CompanysSearcher(TestCriterion.Get(), address, client);
               
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("\nTest 3. Update Id=1 ");
                Console.WriteLine("Befor:");
                await CR.GetCompany(1, address, client);
                await CR.UpdateCompany(1, new NewCompany().Get(), address, client);
                Console.WriteLine("After:");
                await CR.GetCompany(1, address, client);

                Console.WriteLine("\nTest 4. Delete Id=1 ");
                Console.WriteLine("Befor:");
                await CR.GetCompany(1, address, client);
                await CR.DeleteCompany(1, address, client);
                Console.WriteLine("After:");
                await CR.GetCompany(1, address, client);
                                
                Redirect.Close();
                Console.WriteLine("\tThe end of the test :) \n\n\tSee the resultats in file: \"TEST_OUTPUT.txt\"  in catalog: \"WebApiSelfHostBC\" !!!");
                Console.WriteLine("\n\t\t*** The End ***");
            }
            //
            Console.ReadLine();
        }
    }
}
