namespace GameStore.Api.Entities
{
    public abstract class EntityProduct{
        public int Id { get; set; } // PK
        public required string Name { get; set; }
    }
}