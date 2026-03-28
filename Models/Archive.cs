using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class Archive
    {
        public int ArchiveId { get; set; }
        public string RequestNumber { get; set; }
        public string StudentNumber { get; set; }
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string InquiryType { get; set; }
        public string FinalStatus { get; set; }
        public string ORNumber { get; set; }
        public DateTime ArchivedAt { get; set; }
    }
}
