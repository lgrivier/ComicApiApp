using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApiApp
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInfo()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=42.4092&lng=-82.8919&date=today";



            using (System.Net.Http.HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();


                    return result.results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
