using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class SkippedQueue
    {
        public int SkippedId { get; set; }
        public int QueueId { get; set; }
        public int WindowNumber { get; set; }
        public DateTime SkippedAt { get; set; }
        public DateTime DateSkipped { get; set; }
    }
}
