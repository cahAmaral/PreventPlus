using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PreventPlus.Models; // Ajuste conforme o namespace do seu projeto

namespace PreventPlus.Pages.Checklists
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Models.Checklist> Checklists { get; set; }

        public async Task OnGetAsync()
        {
            Checklists = await _httpClient.GetFromJsonAsync<List<Models.Checklist>>("api/checklist");
        }
    }
}