using MimeKit;

namespace MallorCarApplication.Dtos;

public class Message
{
    public List<MailboxAddress> To { get; set; }

    public string Subject { get; set; } = default!;

    public string Content { get; set; } = default!;

    public Message(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(x => new MailboxAddress("email",x)));
        Subject = subject;
        Content = content;
    }
}