using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Alertas
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Models.Alerta Alerta { get; set; }

        public List<SelectListItem> RegiaoOptions { get; set; }

        public async Task OnGetAsync()
        {
            var regioes = await _httpClient.GetFromJsonAsync<List<Models.Regiao>>("api/regiao");
            RegiaoOptions = new List<SelectListItem>();

            foreach (var r in regioes)
            {
                RegiaoOptions.Add(new SelectListItem { Value = r.IdRegiao.ToString(), Text = r.NomeRegiao });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            var response = await _httpClient.PostAsJsonAsync("api/alerta", Alerta);
            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Erro ao cadastrar alerta.");
            await OnGetAsync();
            return Page();
        }
    }
}