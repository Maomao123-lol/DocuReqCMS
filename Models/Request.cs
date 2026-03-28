using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    internal class Request:BaseTransaction
    {
        public string RequestNumber { get; private set; }
        public string Status { get; private set; }
        public string ORNumber { get; private set; }
        public DateTime? PickupDeadline{get; private set;}        

        public Request(string studentNumber, string name, int documentId, string inquiryType, string requestNumber, string status, string orNumber, DateTime? pickupDeadline)
            : base(studentNumber, name, documentId, inquiryType)
        {
            RequestNumber = requestNumber;
            Status = status;
            ORNumber = orNumber;
            PickupDeadline = pickupDeadline;
        }
    }
}
