using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2Book.Web.Api.Models
{
    public class User
    {
        private List<Link> _links;

        public virtual long UserId { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Username { get; set; }

        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
