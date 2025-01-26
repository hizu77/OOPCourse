using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStatus;
using Itmo.ObjectOrientedProgramming.Lab3.Users.ReadResult;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    private readonly Dictionary<Message, Status> _messages = [];

    public User(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        _messages[message] = new Status.UnRead();
    }

    public MessageCheckStatusResult CheckMessageStatus(Message message)
    {
        return !_messages.TryGetValue(message, out Status? value)
            ? new MessageCheckStatusResult.MessageNotFound()
            : new MessageCheckStatusResult.Success(value);
    }

    public MessageReadResult ReadMessage(Message message)
    {
        if (!_messages.TryGetValue(message, out Status? value) || value is not Status.UnRead)
        {
            return new MessageReadResult.MessageAlreadyRead();
        }

        _messages[message] = new Status.Read();

        return new MessageReadResult.Success();
    }
}