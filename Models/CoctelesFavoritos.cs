using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoctelesExamen.Models
{
    public class CoctelesFavoritos
    {
        
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int IdFavorito { get; set; }
       
        public int IdCoctel { get; set; }

    }
}
