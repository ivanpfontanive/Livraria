namespace Livraria.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }

        public override string ToString()
        {
            return $"Id-#-{Id}";
        }
    }
}