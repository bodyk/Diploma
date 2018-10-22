using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Verbarium.DAL.Models
{
    public class Quote
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public Word CurrentWord { get; set; }
    }
}
