namespace CoctelesExamen.Models
{
    public abstract class CoctelAbstract
    {
        public string Nombre { get; set; }
        public List<string> Ingredientes { get; set; }

        public abstract string Preparar();
    }
}
