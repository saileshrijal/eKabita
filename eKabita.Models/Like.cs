namespace eKabita.Models
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid? PoemId { get; set; }
        public Poem? Poem { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
