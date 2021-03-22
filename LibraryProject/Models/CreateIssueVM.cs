using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Models
{
    public class CreateIssueVM
    {
        public int CustomerId { get; set; }
        public int ManagerId { get; set; }
        public string IssueDescription { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueStatus { get; set; }
        public DateTime ResolveDate { get; set; }
    }
}
 
 
 
 
 
 