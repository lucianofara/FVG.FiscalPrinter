using FVG.FiscalPrinter.Domain.Core.Infraestructure;
using FVG.FiscalPrinter.Domain.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FVG.FiscalPrinter.Domain.Core.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        public async Task<string> PrintAsync(string url, PrintDocument document)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(document, Formatting.Indented), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, stringContent);
            var result = await response.Result.Content.ReadAsStringAsync();
            return result;
        }
    }
}