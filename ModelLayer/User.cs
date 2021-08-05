using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class Users
    {
        public string Key { get; set; } = new Guid().ToString();
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Passworld { get; set; }
        public string CPassworld { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
