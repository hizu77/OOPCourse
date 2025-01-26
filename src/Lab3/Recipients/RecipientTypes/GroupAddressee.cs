using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.RecipientTypes;

public class GroupAddressee : IAddressee
{
    public static GroupRecipientBuilder Builder => new();

    private readonly IReadOnlyCollection<IAddressee> _recipients;

    private GroupAddressee(IReadOnlyCollection<IAddressee> recipients)
    {
        _recipients = recipients;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }

    public class GroupRecipientBuilder
    {
        private readonly List<IAddressee> _allRecipients = [];

        public GroupRecipientBuilder AddRecipient(IAddressee addressee)
        {
            _allRecipients.Add(addressee);

            return this;
        }

        public GroupAddressee Build()
        {
            return new GroupAddressee(_allRecipients);
        }
    }
}