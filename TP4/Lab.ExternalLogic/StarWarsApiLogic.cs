using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Lab.External.Models;

namespace Lab.External.Logic
{
    public class StarWarsApiLogic
    {
        public async Task<PeopleResponse> GetPeopleAsync(string pageUrl)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var responseTask = await httpClient.GetStringAsync(pageUrl);

                    var peopleResponse = JsonConvert.DeserializeObject<PeopleResponse>(responseTask);
                    return peopleResponse;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error while trying to connect to the API. \n\n {e.Message}");
            }
        }
    }
}
