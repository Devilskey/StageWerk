using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertDefinitions.Models
{
    public class AlertDefinition
    {
        public int AlertDefinitionId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [AllowNull]
        [Column("MessageRegexId")]
        public Regex? Message { get; set; }

        [AllowNull]
        [Column("SourceRegexId")]
        public Regex? Source { get; set; }

        [AllowNull]
        [Column("ExceptionTypeRegexId")]
        public Regex? ExceptionType { get; set; }

        [AllowNull]
        [Column("UrlRegexId")]
        public Regex? Url { get; set; }

        [AllowNull]
        [Column("RecipientId")]
        public Recipient? Recipient { get; set; }

        [AllowNull]
        [Column("LoglevelExpressionId")]
        public LogLevelExpression? LoglevelExpression { get; set; }

        [NotNull]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
