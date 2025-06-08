using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Checklists
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Models.Checklist Checklist { get; set; }

        public void OnGet()
        {
            // Apenas exibe o formulário vazio
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var response = await _httpClient.PostAsJsonAsync("api/checklist", Checklist);
            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Erro ao cadastrar checklist.");
            return Page();
        }
    }
}