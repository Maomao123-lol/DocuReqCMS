using System.Windows.Markup;

public class BaseTransaction
{
    public string StudentNumber { get; private set; }
    public string Name { get; private set; }
    public int DocumentId { get; private set; }
    public string InquiryType { get; private set; }

    public BaseTransaction(string studentNumber, string name, int documentId, string inquiryType)
    {
        StudentNumber = studentNumber;
        Name = name;
        DocumentId = documentId;
        InquiryType = inquiryType;
    }
}