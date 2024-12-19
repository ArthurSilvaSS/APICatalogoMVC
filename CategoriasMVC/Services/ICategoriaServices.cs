using CategoriasMVC.Models;

namespace CategoriasMVC.Services
{
    public interface ICategoriaServices
    {
        Task<IEnumerable<CategoriaViwerModel>> GetCategorias();
        Task<CategoriaViwerModel> GetCategoriaPorId(int id);
        Task<CategoriaViwerModel> CriaCategoria(CategoriaViwerModel categoriaVM);
        Task<bool> AtualizaCategoria(int id, CategoriaViwerModel categoriaVM);
        Task<bool> DeletaCategoria(int id);
    }
}
