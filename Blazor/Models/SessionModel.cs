using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Models
{
    public class SessionModel
    {
        public int ManagerId { get; set; }
        public string AccessToken { get; set; }
    }
}
