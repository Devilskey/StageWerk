using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AlertDefinitions.Models
{
    public class UpdateLog
    {
        public int UpdateLogId { get; set; }

        [NotNull]
        public string UpdateTable { get; set; } = string.Empty;

        [Column("EmployeeId")]
        public Employee? Employee { get; set; }

        [NotNull]
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
