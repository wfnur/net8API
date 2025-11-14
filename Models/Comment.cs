using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net8API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }= string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public int? StockId { get; set; }
        
        //Navigation Property
        public Stock? Stock { get; set; }
    }
}