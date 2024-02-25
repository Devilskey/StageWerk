using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertDefinitions.Models
{
    public class LogLevelExpression
    {
        public int LogLevelExpressionId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [NotNull]
        public int Operator { get; set; }

        [Column("LogLevelId")]
        public LogLevels? Loglevel { get; set; }

        [NotNull]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
