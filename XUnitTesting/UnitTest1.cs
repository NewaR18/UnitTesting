using Newtonsoft.Json;
using System.Net.Http.Headers;
using Xunit;
using XUnitTesting.Models;

namespace XUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public async Task PassingTest()
        {
            Assert.Equal(77, CallIT());
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(0, CallIT());
        }

        public int CallIT()
        {
            int noOfDistrict = 0;
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJJbmZvRGV2IE9ubGluZSBLWUMgQVBJIiwianRpIjoiNDE5Yzc2MjctOTVhMC00YzMxLWI5MmEtYWE5ODM3NWUwNTAyIiwiQ2xpZW50SWQiOiJtaXEySk1uL3ovakZ0N3ZyUmhibXRRPT0iLCJVc2VySWQiOiJWeHJWekpsdktTL1lpNDBPcXJwTU1RPT0iLCJleHAiOjE2OTYzMDgyMzYsImlzcyI6IkluZm9EZXYuT25saW5lS1lDLkFwaSIsImF1ZCI6IkluZm9EZXYuT25saW5lS1lDLkFwaSJ9.mc3UobMlU7gH88te1EGo2fLYGXKSrpd6c52uUbcp-X4";
            string baseURL = "http://192.168.50.43:8087/api/v1/";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = baseURL + "SetupData/DistrictList";
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        ResponseResult responseResult = JsonConvert.DeserializeObject<ResponseResult>(content);
                        Console.WriteLine(responseResult.data.Count());
                        noOfDistrict = responseResult.data.Count();
                        Console.WriteLine(responseResult.data[0].name);
                        Console.WriteLine("API Response:");
                        Console.WriteLine(responseResult);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            return noOfDistrict;
        }

    }
}