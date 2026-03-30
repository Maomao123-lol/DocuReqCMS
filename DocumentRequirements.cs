using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg
{
    internal class DocumentRequirements
    {
        public static Dictionary<string, List<string>> Requirements = new Dictionary<string, List<string>>()
        {
            {
                "TOR 2ND COPY", new List<string>
                {
                    "Photocopy - TOR",
                    "Documentary Stamp for TOR",
                    "Original Receipt"
                }
            },
            {
                "TOR 1ST COPY", new List<string>
                {
                    "TOR - Previous School",
                    "Clearance Form",
                    "Certified True Copy - TOR",
                    "Documentary Stamp for TOR",
                    "Original Receipt",
                    "Original PSA",
                    "Scholastic Record"
                }
            },
            {
                "TOR HONORABLE DISMISSAL", new List<string>
                {
                    "TOR - Previous School",
                    "Mailing Envelope - Long",
                    "Documentary Stamp for HD Form",
                    "Clearance Form",
                    "Certified True Copy - TOR",
                    "Documentary Stamp for TOR",
                    "Original Receipt",
                    "Original PSA"
                }
            },
            {
                "CAV", new List<string>
                {
                    "Mailing Envelope - Long",
                    "Documentary Stamp for CAV Form",
                    "Certified True Copy - TOR",
                    "Certified True Copy - Diploma",
                    "Original Receipt"
                }
            }
        };

        // Add this to your DocumentRequirements static class
        public static List<string> PaidDocuments = new List<string>
        {
            "TOR 1ST COPY",
            "TOR 2ND COPY",
            "TOR HONORABLE DISMISSAL",
            "CAV"
        };
    }
}
