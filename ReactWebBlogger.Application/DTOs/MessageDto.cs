using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Application.DTOs
{
    public class MessageDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate Id
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? EmailAddress { get; set; }

        [Required]
        [StringLength(500)]
        public string? MessageContent { get; set; }

        public DateTime DateSent { get; set; } = DateTime.Now;
    }
}
