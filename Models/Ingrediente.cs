using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CoctelesExamen.Models
{
    public class Ingrediente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIngrediente { get; set; }
        [Required,StringLength(30)]
        public string Nombre { get; set; }
        public int CoctelId { get; set; } 
        public Coctel Coctel { get; set; } 
        public bool Status { get; set; }

    }
}
