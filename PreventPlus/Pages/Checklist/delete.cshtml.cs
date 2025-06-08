using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Checklists
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Models.Checklist Checklist { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Checklist = await _httpClient.GetFromJsonAsync<Models.Checklist>($"api/checklist/{id}");
            if (Checklist == null)
                return RedirectToPage("Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/checklist/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Erro ao excluir checklist.");
            return Page();
        }
    }
}