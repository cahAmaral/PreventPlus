using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PreventPlus.Models;

namespace PreventPlus.Pages.Alertas
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Models.Alerta> Alertas { get; set; }

        public async Task OnGetAsync()
        {
            Alertas = await _httpClient.GetFromJsonAsync<List<Models.Alerta>>("api/alerta");
        }
    }
}