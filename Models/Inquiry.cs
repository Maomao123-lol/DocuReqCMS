using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class Inquiry : BaseTransaction
    {
        public string InquiryId { get; private set; }
        public string Status { get; private set; }

        public Inquiry(string studentNumber, string name, int documentId, string inquiryType, string InquiryId, string Status)
            : base(studentNumber, name, documentId, inquiryType)
        {
            InquiryId = Convert.ToString(Math.Abs(new Guid().GetHashCode()) % 90000 + 10000);
            Status = "Pending";
        }

        public void Approve()
        {
            Status = "Approved";
        }

        public void Reject()
        {
            Status = "Rejected";
        }
    }
}
