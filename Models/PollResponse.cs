using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cb2wled.Models
{
    public class PollResponse
    {


        public List<Event> Events { get; set; } = new ();
        public Uri? NextUrl { get; set; }
    }
}
