namespace LibraryAPI.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
    }
}
