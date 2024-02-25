using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertDefinitions.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Function { get; set; } = string.Empty;

        [NotNull]
        public string Email { get; set; } = string.Empty;

        public string PhoneNum { get; set; } = string.Empty;

        [NotNull]
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime DeletedAt { get; set; }
    }
}
