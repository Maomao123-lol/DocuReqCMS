using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class StudentDocuments
    {
        public int RecordId { get; set; }
        public string StudentNumber { get; set; }
        public int DocumentId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public bool IsComplete { get; set; }

        public void MarkAsComplete()
        {
            IsComplete = true;
        }

        public void MarkAsIncomplete()
        {
            IsComplete = false;
        }
    }
}
