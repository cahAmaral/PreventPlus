using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Checklists
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Models.Checklist Checklist { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Checklist = await _httpClient.GetFromJsonAsync<Models.Checklist>($"api/checklist/{id}");
            if (Checklist == null)
                return RedirectToPage("Index");

            return Page();
        }
    }
}