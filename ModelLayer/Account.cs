using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class Account
    {
        #region default

        /// <summary>
        /// local id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// key firebase or temporaly local guid key 
        /// </summary>
        public string Key { get; set; }

        public string UserKey { get; set; }
        public DateTime LastUpdate { get; set; }

        #endregion


        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

    }
}
