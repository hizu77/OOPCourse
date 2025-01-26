using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    public static TopicBuilder Builder => new();

    private readonly IReadOnlyCollection<IAddressee> _recipients;

    private Topic(string topicName, IReadOnlyCollection<IAddressee> recipient)
    {
        Name = topicName;
        _recipients = recipient;
    }

    public string Name { get; }

    public void SendRecipientMessage(Message message)
    {
        foreach (IAddressee recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }

    public class TopicBuilder
    {
        private readonly List<IAddressee> _allRecipients = [];
        private string? _name;

        public TopicBuilder AddRecipient(IAddressee addressee)
        {
            _allRecipients.Add(addressee);
            return this;
        }

        public TopicBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public Topic Build()
        {
            return new Topic(
                _name ?? throw new ArgumentNullException(),
                _allRecipients);
        }
    }
}