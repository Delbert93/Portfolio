using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        //TODO This might change to an image later.
        public string Design { get; set; }

        public DateTime CompletionDate { get; set; }
    }
}
