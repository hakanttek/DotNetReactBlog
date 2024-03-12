using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactWebBlogger.Domain.Entities
{

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "TEXT")]
        public string? Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Description { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string? Url { get; set; }

        [Column(TypeName = "TEXT")]
        public string? ImageSource { get; set; }
    }

}
