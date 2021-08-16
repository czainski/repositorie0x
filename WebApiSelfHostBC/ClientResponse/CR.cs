using WebApiSelfHostBC.CompanyCriterions;
using WebApiSelfHostBC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiSelfHostBC.ClientResponse
{
    public static class CR
    {
        static void Exception(Exception ex, string place)
        {
            Console.WriteLine("\nException in: " + place);
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message+"\n"); 
        }
        static HttpResponseMessage response = null;
        public static async Task GetCompanys(string address, HttpClient client)
        {
           try
            {
                response = await client.GetAsync(address + "api/company/all");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Exception(ex, "CR.GetCompanys");
                return;
            }
            Console.WriteLine( response.Content.ReadAsStringAsync().Result);
        }
        public static async Task GetCompany(long Id, string address, HttpClient client)
        {
            try
            {
                response = await client.GetAsync(address + string.Format("api/company/any/{0}", Id));
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Exception(ex, "CR.GetCompany");
                return;
            }
            //var company = response.Content.ReadAsAsync<Company>().Result;
            //Console.WriteLine("{0} (Id={1}) is found!",  company.Name,Id);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
        public static async Task CompanysSearcher(Criterion criterion, string address, HttpClient client)
        {
            if (criterion == null) {
                Console.WriteLine("Error:  CR.CompanysSearcher :  criterion == null  ") ;
                return; 
            }
            try
            {
                response = await client.PostAsJsonAsync(address + "api/company/search", criterion);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Exception(ex, "CR.CompanysSearcher");
                return;
            }
            Console.WriteLine(response.Content.ReadAsAsync<object>().Result);
        }
        public static async Task CreateCompany(Company company, string address, HttpClient client)
        {
            try
            {
                response = await client.PostAsJsonAsync(address + "api/company/create", company);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Exception(ex, "CR.CreateCompany");
                return;
            }
            Console.WriteLine(response.Content.ReadAsAsync<string>().Result);
        }
        //
        public static async Task UpdateCompany(long id, Company category, string address, HttpClient client)
        {
            try
            {
                response = await client.PutAsJsonAsync(address + string.Format("api/company/update/{0}", id), category);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Exception(ex, "CR.UpdateCompany");
                return;
            }
        }
        //
        public static async Task DeleteCompany(long Id, string address, HttpClient client)
        {
            try
            {
                response = await client.DeleteAsync(address + string.Format("api/company/delete/{0}", Id));
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Exception(ex, "CR.DeleteCompany");
                return;
            }
        }
    }
}
