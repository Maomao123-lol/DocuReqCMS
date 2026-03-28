using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class DocumentData
    {
        public int DocumentId { get; private set; }
        public string DocumentName { get; private set; }
        public string DocumentType { get; private set; }
        public string DocumentRequirements { get; private set; }
        public bool RequiresPayment { get; private set; }
    }
}
