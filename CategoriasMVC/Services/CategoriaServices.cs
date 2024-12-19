using System.Text;
using System.Text.Json;
using CategoriasMVC.Models;

namespace CategoriasMVC.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private const string apiEndpoint = "/Categorias?api-version=1";

        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;

        private CategoriaViwerModel categoriaVM;
        private IEnumerable<CategoriaViwerModel> categoriasVM;

        public CategoriaServices(IHttpClientFactory clientFactory)
        {
            _options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
            _clientFactory = clientFactory;
            
        }
        //PUT <<ATUALIZA A CATEGORIA>>
        public async Task<bool> AtualizaCategoria(int id, CategoriaViwerModel categoriaVM)
        {
            var client = _clientFactory.CreateClient("CategoriasApi");
            using (var response = await client.PutAsJsonAsync(apiEndpoint + id, categoriaVM))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //POST <<CRIA A CATEGORIAS>>
        public async Task<CategoriaViwerModel> CriaCategoria(CategoriaViwerModel categoriaVM)
        {
            var client = _clientFactory.CreateClient("CategoriasApi");
            var categoria = JsonSerializer.Serialize(categoriaVM);

            StringContent content = new StringContent(categoria, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    categoriaVM = JsonSerializer
                        .Deserialize<CategoriaViwerModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return categoriaVM;
        }

        //DELETE <<DELETA A CATEGORIA>>
        public async Task<bool> DeletaCategoria(int id)
        {
            var client = _clientFactory.CreateClient("CategoriasApi");
            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;

            }
        }

        //GET <<CATEGORIAS POR ID>>
        public async Task<CategoriaViwerModel> GetCategoriaPorId(int id)
        {
            var client = _clientFactory.CreateClient("CategoriasApi");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    categoriaVM = JsonSerializer
                        .Deserialize<CategoriaViwerModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return categoriaVM;
        }

        //GET <<CATEGORIAS>>
        public async Task<IEnumerable<CategoriaViwerModel>> GetCategorias()
        {
            var client = _clientFactory.CreateClient("CategoriasApi");

            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    categoriasVM = JsonSerializer.Deserialize<IEnumerable<CategoriaViwerModel>>(apiResponse, _options);

                }
                else
                {
                    return null;
                }
            }

            return categoriasVM;
        }
    }
}
