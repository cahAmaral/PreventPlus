using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Alertas
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Models.Alerta Alerta { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Alerta = await _httpClient.GetFromJsonAsync<Models.Alerta>($"api/alerta/{id}");
            if (Alerta == null)
                return RedirectToPage("Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/alerta/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Erro ao excluir alerta.");
            return Page();
        }
    }
}