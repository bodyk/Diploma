namespace Verbarium.BLL.DTOs
{
    public class QuoteDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public WordDto CurrentWord { get; set; }
    }
}
