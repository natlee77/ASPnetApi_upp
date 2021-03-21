using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManager.Entities
{
    public partial class Issue
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ManagerId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ResolveDate { get; set; }
        public string IssueDescription { get; set; }
        public string IssueStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
