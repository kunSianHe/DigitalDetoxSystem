using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalDetoxSystem.Models
{
    public class UsageLog
    {
        public Guid Id { get; set; }

        [Required]
        public string Reason { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Required]
        public string Type { get; set; }
    }
}
