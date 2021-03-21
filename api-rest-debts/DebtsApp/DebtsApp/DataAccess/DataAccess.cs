using debts_app.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace debts_app.DataAccess
{
    public class DataAccess
    {
        const string baseUrl = "http://localhost:8080/api/v1";

        public async Task<IEnumerable<Debts>> GetDebts()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync($"{baseUrl}/debts");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Debts>>(json);

                return data;
            }
            catch (System.Exception)
            {

                return null;
            }
           
        }
    }
}
