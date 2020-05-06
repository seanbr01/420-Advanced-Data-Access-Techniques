using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int Priority { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
    }
}