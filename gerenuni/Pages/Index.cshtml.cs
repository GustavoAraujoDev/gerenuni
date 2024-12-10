using Microsoft.AspNetCore.Mvc.RazorPages;
using gerenuni.Models; // Namespace onde est� a classe Produto
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace gerenuni.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Produto> Products { get; set; } = new List<Produto>();

        public async Task OnGetAsync()
        {
            string apiUrl = "https://localhost:7053/api/Produto";
            try
            {
                var productsResponse = await _httpClient.GetFromJsonAsync<List<Produto>>(apiUrl);
                Products = productsResponse ?? new List<Produto>();
            }
            catch (Exception ex)
            {
                Products = new List<Produto>();
                Console.WriteLine($"Erro ao buscar produtos: {ex.Message}");
            }
        }

        // Handler para Adicionar Produto
        public async Task<IActionResult> OnPostCreateAsync(Produto produto)
        {
            string apiUrl = "https://localhost:7053/api/Produto";

            var response = await _httpClient.PostAsJsonAsync(apiUrl, produto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // Redireciona para a mesma p�gina ap�s adicionar
            }

            // Caso haja falha
            return Page();
        }

        // Handler para Deletar Produto
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            string apiUrl = $"https://localhost:7053/api/Produto/{id}";

            var response = await _httpClient.DeleteAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // Redireciona para a mesma p�gina ap�s excluir
            }

            // Caso haja falha
            return Page();
        }

        // Handler para Atualizar Produto (opcional, se necess�rio)
        // Para a p�gina de atualiza��o (Update.cshtml), o m�todo seria semelhante
        public async Task<IActionResult> OnPostUpdateAsync(Produto produto)
        {
            string apiUrl = $"https://localhost:7053/api/Produto/{produto.Id}";

            var response = await _httpClient.PutAsJsonAsync(apiUrl, produto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // Redireciona ap�s atualizar
            }

            // Caso haja falha
            return Page();
        }
    }
}
