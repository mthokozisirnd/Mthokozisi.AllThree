namespace ExerciseOne.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string CellPhone { get; set; } = null!;
    }
}
