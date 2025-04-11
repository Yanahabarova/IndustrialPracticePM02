namespace ClassLibrary
{
    public class Operations
    {
        public static string AddAuthor(string Surname, string Name, string Patronymic)
        {
            return $"{Surname} {Name} {Patronymic}";
        }
        
        public static Author _author;

        public static Author AddAuthorModel(Author _author)
        {
            return _author;
        }
    }
    
    public partial class Author
    {
        public int Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }
    }
}
