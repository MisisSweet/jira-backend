using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jira_api_serv.Models
{
    public class Content
    {
        /// <summary>
        /// Type
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public List<ContentT> content { get; set; }
    }
}
