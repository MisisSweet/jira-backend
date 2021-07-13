using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jira_api_serv.Models
{
    public class Comment
    {
        /// <summary>
        /// Type
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public List<Content> content { get; set; }
    }
}
