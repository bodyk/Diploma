using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.DTOs
{
    public class QuoteDto : IDtoEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public WordDto CurrentWord { get; set; }
        public string Author { get; set; }
    }
}
