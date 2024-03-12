using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Domain.Entities
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate Id
        public int Id { get; set; }

        [Required]
        [StringLength(100)] // Set max length for Name
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)] // Set max length for EmailAddress
        public string? EmailAddress { get; set; }

        [Phone]
        [StringLength(20)] // Set max length for PhoneNumber
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(500)] // Set max length for MessageContent
        public string? MessageContent { get; set; }

        [Required]
        public DateTime DateSent { get; set; }
    }
}
