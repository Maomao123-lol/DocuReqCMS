using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class Queue
    {
        public int QueueId { get; set; }
        public int WindowNumber { get; set; }
        public int WindowQueueNumber { get; set; }
        public string WindowType { get; set; }

        public void CallNext()
        {
            WindowQueueNumber++;
        }

        public void Skip()
        {
            WindowQueueNumber++;
        }
    }
}
