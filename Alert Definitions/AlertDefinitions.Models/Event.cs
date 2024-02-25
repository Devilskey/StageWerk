using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AlertDefinitions.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Column("AlertDefinitionId")]
        public AlertDefinition? AlertDefinition { get; set; }

        [Column("LogLevelId")]
        public LogLevels? LogLevel { get; set; }

        public string Message { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public string Platform { get; set; } = string.Empty;

        public string ExceptionType { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        [NotNull]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
