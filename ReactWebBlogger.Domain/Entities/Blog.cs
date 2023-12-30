using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactWebBlogger.Domain.Entities
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Description { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Title { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Author { get; set; }
    }
}
