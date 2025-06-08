using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Alertas
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Models.Alerta Alerta { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Alerta = await _httpClient.GetFromJsonAsync<Models.Alerta>($"api/alerta/{id}");
            if (Alerta == null)
                return RedirectToPage("Index");

            return Page();
        }
    }
}