using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2Book.Web.Api.Models
{
    public class Task
    {
        private List<Link> _links;

        public virtual long? TaskId { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual DateTime? CompletedDate { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual List<User> Assignees { get; set; }

        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value;  }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
