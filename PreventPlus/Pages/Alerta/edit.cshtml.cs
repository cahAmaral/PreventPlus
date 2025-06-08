using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Alertas
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Models.Alerta Alerta { get; set; }

        public List<SelectListItem> RegiaoOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Alerta = await _httpClient.GetFromJsonAsync<Models.Alerta>($"api/alerta/{id}");
            if (Alerta == null)
                return RedirectToPage("Index");

            var regioes = await _httpClient.GetFromJsonAsync<List<Models.Regiao>>("api/regiao");
            RegiaoOptions = new List<SelectListItem>();

            foreach (var r in regioes)
            {
                RegiaoOptions.Add(new SelectListItem { Value = r.IdRegiao.ToString(), Text = r.NomeRegiao });
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var regioes = await _httpClient.GetFromJsonAsync<List<Models.Regiao>>("api/regiao");
                RegiaoOptions = new List<SelectListItem>();

                foreach (var r in regioes)
                {
                    RegiaoOptions.Add(new SelectListItem { Value = r.IdRegiao.ToString(), Text = r.NomeRegiao });
                }
                return Page();
            }

            var response = await _httpClient.PutAsJsonAsync($"api/alerta/{Alerta.IdAlerta}", Alerta);
            if (response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Erro ao editar alerta.");
            return Page();
        }
    }
}
