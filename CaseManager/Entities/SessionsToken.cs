using System;
using System.Collections.Generic;

#nullable disable

namespace CaseManager.Entities
{
    public partial class SessionsToken
    {
        public int ManagerId { get; set; }
        public string AccessToken { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
