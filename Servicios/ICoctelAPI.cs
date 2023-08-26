using CoctelesExamen.Models;
namespace CoctelesExamen.Servicios
{
    public interface ICoctelAPI
    {
        Task<List<Coctel>> ListaPorCoctel(string coctel);
        Task<List<Coctel>> ListaPorIngrediente(string ingrediente);
        Task<List<Coctel>> ListaPorId(string id);
    }
}
