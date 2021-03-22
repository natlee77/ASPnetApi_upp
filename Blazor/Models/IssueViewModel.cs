using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Models
{
    public class IssueViewModel
    {
        //copy from WebApi /Entities/Issue.cs- ! exact likadant -det vad jag vill se i min web issue
        public int Id { get; set; }
        public CustomerViewModel Customer { get; set; }//ändra

        public ManagerViewModel Manager { get; set; }//ändra
        
        public DateTime IssueDate { get; set; }
        public DateTime? ResolveDate { get; set; }
        public string IssueDescription { get; set; }
        public string IssueStatus { get; set; }

    }
}
