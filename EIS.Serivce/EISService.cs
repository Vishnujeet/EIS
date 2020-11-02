using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EIS.Common;
using EIS.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ESI.Service
{
    public class EISService : IEISService
    {
        public async Task<EmployeeData> GetEmployees()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"https://gorest.co.in/public-api/users");
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EmployeeData>(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task AsyncPost(EmployeeInfo employeeInfo)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer",
                        "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                var payload = JsonConvert.SerializeObject(employeeInfo);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://gorest.co.in/public-api/users", content);
                var returnValue = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"Failed to POST data: ({response.StatusCode}): {returnValue}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<EmployeeData> SearchEmployees(string firstName)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response =
                        await client.GetAsync($"https://gorest.co.in/public-api/users?first_name={firstName}");
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EmployeeData>(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}