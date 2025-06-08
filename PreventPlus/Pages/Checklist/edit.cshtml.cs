using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Checklists
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(HttpClient httpClient)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var response = await _httpClient.PutAsJsonAsync($"api/checklist/{Checklist.IdChecklist}", Checklist);
            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Erro ao editar checklist.");
            return Page();
        }
    }
}