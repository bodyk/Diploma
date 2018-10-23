using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Verbarium.DAL.Interfaces;

namespace Verbarium.DAL.Models
{
    public class Quote : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public Word CurrentWord { get; set; }
    }
}
