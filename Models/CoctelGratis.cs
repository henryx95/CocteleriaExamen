namespace CoctelesExamen.Models
{
    public class CoctelGratis : CoctelAbstract
    {
        public CoctelGratis()
        {
            Nombre = "Margarita";
            Ingredientes = new List<string> { "Tequila", "Licor de naranja", "Limón", "Sal" };
        }

        public override string Preparar()
        {
            return $"Preparando una {Nombre} con {string.Join(", ", Ingredientes)}...";
        }
    }
}
