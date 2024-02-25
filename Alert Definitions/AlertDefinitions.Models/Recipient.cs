using AlertDefinitions.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertDefinitions.Models
{
    public class Recipient
    {
        public int RecipientId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Column("TeamId")]
        public Team? Team { get; set; }

        [Column("WebhookId")]
        public Webhook? Webhook { get; set; }

        [Column("EmployeeId")]
        public Employee? Employee { get; set; }

        [NotNull]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
